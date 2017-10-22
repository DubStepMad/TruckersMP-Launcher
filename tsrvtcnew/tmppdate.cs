using System;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace tsrvtcnew
{
    class tmppdate
    {
        public static void integrityCheck()
        {
           /* JArray liveFiles = new JArray();
            Dictionary<string, string> localFiles = new Dictionary<string, string>();
            List<string> mismatchedFiles = new List<string>();

            using (System.Net.WebClient client = new WebClient())
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
                var files = System.IO.Directory.GetFiles(Properties.Settings.Default.launcherpath, "*.*", System.IO.SearchOption.AllDirectories);
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

                    string localHash = localFiles[filePath];

                    if (!(filePath.Contains("ui") || filePath.Contains("fonts")))
                    {
                        if ((string)file["Md5"] != localHash)
                            mismatchedFiles.Add(filePath);

                        continue;
                    }
                    else
                    {
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
            }*/
        }
    }
}
