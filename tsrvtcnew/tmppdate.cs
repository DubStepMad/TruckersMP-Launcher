using System;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace tsrvtcnew
{
    class Tmppdate
    {
        protected static string MD5(string fileName)
        {
            FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(file);
            file.Close();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            return sb.ToString();
        }

        public static void IntegrityCheck()
        {

            JArray liveFiles = new JArray();
            Dictionary<string, string> localFiles = new Dictionary<string, string>();
            List<string> mismatchedFiles = new List<string>();

            using (WebClient client = new WebClient())
            {
                try
                {
                    JObject requestData = JObject.Parse(client.DownloadString("http://update.ets2mp.com/files.json"));
                    liveFiles = (JArray)requestData["Files"];
                }
                catch (WebException)
                {
                    Console.WriteLine("Unable to connect to TruckersMP Update API. Cannot check TMP integrity!");
                    return;
                }
            }

            int step = 0;

            try
            {
                var files = Directory.GetFiles(Properties.Settings.Default.launcherpath, "*.*", SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    FileInfo info = new FileInfo(file);

                    string key = info.FullName;
                    var checksum = MD5(key);
                    key = key.Replace(Properties.Settings.Default.launcherpath, "");

                    localFiles.Add(key, checksum);
                    step = step + 1;
                }
            }
            catch
            {
                Console.WriteLine("Unable to load local files. Cannot check TMP integrity!");
            }

            try
            {
                foreach (var file in liveFiles)
                {
                    string filePath = ((string)file["FilePath"]).Replace("/", "\\");

                    if (!localFiles.ContainsKey(filePath))
                    {
                        mismatchedFiles.Add(filePath);
                        continue;
                    }
                    else
                    {
                        string localHash = localFiles[filePath];
                        string[] s = filePath.Split('.');
                        string backupFile = s[0] + "_backup." + s[1];

                        if (File.Exists(Properties.Settings.Default.launcherpath + backupFile))
                        {
                            string backupHash = MD5(Properties.Settings.Default.launcherpath + backupFile);

                            if ((string)file["Md5"] != backupHash)
                                mismatchedFiles.Add(backupFile);

                            continue;
                        }
                        else
                        {
                            if ((string)file["Md5"] != localHash)
                                mismatchedFiles.Add(filePath);

                            continue;
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("An error occured comparing files. Cannot check TMP integrity!");
                return;
            }
            Update(mismatchedFiles);
        }

        private static void Update(List<string> mismatchedFiles)
        {
            try
            {
                System.Threading.ThreadPool.QueueUserWorkItem(async delegate
                {
                    foreach (var file in mismatchedFiles)
                    {
                        string downloadFile = (file.Replace("_backup", "")).Replace("\\", "/");
                        string[] s = file.Split('\\');
                        string fileName = s[(s.Length - 1)];

                        if (!Directory.Exists(Properties.Settings.Default.launcherpath))
                        {
                            Directory.CreateDirectory(Properties.Settings.Default.launcherpath);
                        }

                        if (s.Length == 3)
                        {
                            if (!Directory.Exists(Properties.Settings.Default.launcherpath + "\\" + s[1]))
                                Directory.CreateDirectory(Properties.Settings.Default.launcherpath + "\\" + s[1]);
                        }

                        if (s.Length == 4)
                        {
                            if (!Directory.Exists(Properties.Settings.Default.launcherpath + "\\" + s[1] + "\\" + s[2]))
                                Directory.CreateDirectory(Properties.Settings.Default.launcherpath + "\\" + s[1] + "\\" + s[2]);
                        }

                        if (s.Length == 5)
                        {
                            if (!Directory.Exists(Properties.Settings.Default.launcherpath + "\\" + s[1] + "\\" + s[2] + "\\" + s[3]))
                                Directory.CreateDirectory(Properties.Settings.Default.launcherpath + "\\" + s[1] + "\\" + s[2] + "\\" + s[3]);
                        }

                        if (s.Length == 6)
                        {
                            if (!Directory.Exists(Properties.Settings.Default.launcherpath + "\\" + s[1] + "\\" + s[2] + "\\" + s[3] + "\\" + s[4]))
                                Directory.CreateDirectory(Properties.Settings.Default.launcherpath + "\\" + s[1] + "\\" + s[2] + "\\" + s[3] + "\\" + s[4]);
                        }

                        using (WebClient downloadClient = new WebClient())
                        {
                            downloadClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(delegate (object sender, DownloadProgressChangedEventArgs e)
                            {
                            });

                            await downloadClient.DownloadFileTaskAsync(new Uri("http://download.ets2mp.com/files" + downloadFile), Properties.Settings.Default.launcherpath + file);
                        }
                    }
                });
            }
            catch (Exception a)
            {
                string error = a.ToString();
                Loghandling.Logerror(error);
            }
        }
    }
}
