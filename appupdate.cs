using System;

public class appupdate
{
	public appupdate()
	{
        InitializeComponent();

        //gets application directory
        string exeFile = (new System.Uri(Assembly.GetEntryAssembly().CodeBase)).AbsolutePath;
        string updatecheckfile = Path.GetDirectoryName(exeFile);

        string _ftpURL = "ftp://151.229.220.11";             //Host URL or address of the FTP server
        string _UserName = "anonymous";                 //User Name of the FTP server
        string _Password = "";              //Password of the FTP server
        string _ftpDirectory = "updatecheck";          //The directory in FTP server where the files are present
        string _ftpupdateDirectory = "files";
        string _FileName = "updatecheck.txt";             //File name, which one will be downloaded
        string _updateFile = "TSR-VTC";
        string _LocalDirectory = updatecheckfile;  //Local directory where the files will be downloaded

        string currentversion = "";
        string expectedversion = "";
    }

    public static void Run()
    {
        DownloadFile(_ftpURL, _UserName, _Password, _ftpDirectory, _FileName, _LocalDirectory);
    }


    public void DownloadFile(string ftpURL, string UserName, string Password, string ftpDirectory, string FileName, string LocalDirectory)
    {
        if (!File.Exists(LocalDirectory + "/" + FileName))
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
                throw ex;
            }
        }
    }

    private void Filecheck()
    {
        var matches = Directory.GetFiles(Environment.GetFolderPath(updatecheckfile, "updatecheck.txt", SearchOption.AllDirectories));
        var ucdir = matches.Take(1);
        foreach (var myscore in ucdir)
        {
            string myresult = myscore.ToString();
            ucpath = myresult;
        }
        if (matches.Length == 0)
        {
            MessageBox.Show("Failed to retreave update file!");
        }
        else if (matches.Length == 1)
        {
            ReadFile();
        }
        else if (matches.Length > 1)
        {
            
        }
    }

    private void ReadFile()
    {
        string line;

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

    private void Regcheck()
    {
        using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
        using (var key = hklm.OpenSubKey(@"SOFTWARE\TSR-VTC\TSR-VTC_Launcher"))
        {
            if (key != null)
            {
                currentversion = (string)key.GetValue("Version");

                if (currentversion != null)
                {
                    if (currentversion = expectedversion)
                    {
                        Environment.Exit(1);
                    }
                    else if (currentversion < expectedversion)
                    {
                        DownloadUpdate(_ftpURL, _UserName, _Password, _ftpupdateDirectory, _updateFile, _LocalDirectory);
                    }
                }
            }
        }
    }

    public void DownloadUpdate(string ftpURL, string UserName, string Password, string ftpDirectory, string FileName, string LocalDirectory)
    {
        if (!File.Exists(LocalDirectory + "/" + FileName))
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
                throw ex;
            }
        }
    }
}
