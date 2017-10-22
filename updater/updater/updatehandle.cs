using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows.Forms;

namespace updater
{
    class updatehandle
    {
        //FTP related variables
        public static  string _ftpURL = "ftp://ts3rgc.com";             //Host URL or address of the FTP server
        public static string _UserName = "dub";                 //User Name of the FTP server
        public static string _Password = "tsrvtc";              //Password of the FTP server
        public static string _ftpDirectory = "updatecheck";          //The directory in FTP server where the files are present
        public static string _ftpupdateDirectory = "files";
        public static string _FileName = "updatecheck.txt";             //File name, which one will be downloaded
        public static string _updateFile = "TSR-VTC.exe";

        //checks
        public static bool ftpCheck = false;

        //local variables
        public static string updatecheckfile = "";
        public static string ucpath = "";
        public static string currentversion;
        public static string expectedversion;

        public static void Run()
        {
                string exeFile = (new System.Uri(Assembly.GetEntryAssembly().CodeBase)).AbsolutePath;
                string updatecheckfile = Path.GetDirectoryName(exeFile);

                string _LocalDirectory = updatecheckfile;  //Local directory where the files will be downloaded

                DownloadFile(_ftpURL, _UserName, _Password, _ftpDirectory, _FileName, _LocalDirectory);
        }

        public static void DownloadFile(string ftpURL, string UserName, string Password, string ftpDirectory, string FileName, string LocalDirectory)
        {

            try
            {
                FtpWebRequest requestFileDownload = (FtpWebRequest)WebRequest.Create(ftpURL + "/" + ftpDirectory + "/" + FileName);
                requestFileDownload.Credentials = new NetworkCredential(UserName, Password);
                requestFileDownload.Method = WebRequestMethods.Ftp.DownloadFile;
                FtpWebResponse responseFileDownload = (FtpWebResponse)requestFileDownload.GetResponse();
                Stream responseStream = responseFileDownload.GetResponseStream();
                FileStream writeStream = new FileStream(LocalDirectory + "/" + FileName, FileMode.Create);
                int Length = 2048;
                Byte[] buffer = new Byte[Length];
                int bytesRead = responseStream.Read(buffer, 0, Length);
                while (bytesRead > 0)
                {
                    writeStream.Write(buffer, 0, bytesRead);
                    bytesRead = responseStream.Read(buffer, 0, Length);
                }
                responseStream.Close();
                writeStream.Close();
                requestFileDownload = null;
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                Loghandling.Logerror(error);
                return;
            }

            Filecheck();
        }

        private static void Filecheck()
        {
            string exeFile = (new System.Uri(Assembly.GetEntryAssembly().CodeBase)).AbsolutePath;
            string exeDir = Path.GetDirectoryName(exeFile);
            string ucpath = Path.Combine(exeDir, "updatecheck.txt");

            ReadFile(ucpath);
        }

        private static void ReadFile(string ucpath)
        {
            string line;
            string setexp;

            StreamReader file = new StreamReader(ucpath);
            while ((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("expectedversion:"))
                {
                    setexp = (line.Split(':')[1]);
                    expectedversion = setexp;
                }
            }

            Regcheck();
        }

        public static void Regcheck()
        {

            using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
            using (var key = hklm.OpenSubKey(@"SOFTWARE\TSR-VTC\TSR-VTC_Launcher"))
            {
                if (key != null)
                {
                    currentversion = (string)key.GetValue("Version");

                    if (currentversion != null)
                    {
                        if (currentversion == expectedversion)
                        {
                            string error = "Same Version Installed!";
                            Loghandling.Logerror(error);

                            Application.Exit();
                        }
                        else
                        {
                            string exeFile = (new System.Uri(Assembly.GetEntryAssembly().CodeBase)).AbsolutePath;
                            string updatecheckfile = Path.GetDirectoryName(exeFile);

                            string _LocalDirectory = updatecheckfile;  //Local directory where the files will be downloaded

                            DownloadUpdate(_ftpURL, _UserName, _Password, _ftpupdateDirectory, _updateFile, _LocalDirectory);
                        }
                    }
                }
            }
        }

        public static void DownloadUpdate(string ftpURL, string UserName, string Password, string ftpupdateDirectory, string updateFile, string LocalDirectory)
        {
            Form1.flag = true;

            Form1.Form1_Load1();
            try
            {
                FtpWebRequest requestFileDownload = (FtpWebRequest)WebRequest.Create(ftpURL + "/" + ftpupdateDirectory + "/" + updateFile);
                requestFileDownload.Credentials = new NetworkCredential(UserName, Password);
                requestFileDownload.Method = WebRequestMethods.Ftp.DownloadFile;
                FtpWebResponse responseFileDownload = (FtpWebResponse)requestFileDownload.GetResponse();
                Stream responseStream = responseFileDownload.GetResponseStream();
                FileStream writeStream = new FileStream(LocalDirectory + "/" + updateFile, FileMode.Create);
                int Length = 2048;
                Byte[] buffer = new Byte[Length];
                int bytesRead = responseStream.Read(buffer, 0, Length);
                while (bytesRead > 0)
                {
                    writeStream.Write(buffer, 0, bytesRead);
                    bytesRead = responseStream.Read(buffer, 0, Length);
                }
                responseStream.Close();
                writeStream.Close();
                requestFileDownload = null;
                Form1.flag = false;
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                Loghandling.Logerror(error);
                return;
            }

            Process.Start("TSR-VTC.exe");

            try
            {
                Form1.Form1_Load1();
                Process.Start("cmd.exe", "/c taskkill /F /IM tsrvtgui.exe");
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                Loghandling.Logerror(error);
                return;
            }
        }
    }
}
