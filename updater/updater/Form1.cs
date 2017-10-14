using System;
using System.Net;
using System.Windows.Forms;
using System.IO;

namespace updater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string _ftpURL = "ftp://151.229.220.11";             //Host URL or address of the FTP server
            string _UserName = "Admin";                 //User Name of the FTP server
            string _Password = "Dropthebass97";              //Password of the FTP server
            string _ftpDirectory = "Receipts";          //The directory in FTP server where the files are present
            string _FileName = "tsrvtgui.exe";             //File name, which one will be downloaded
            string _LocalDirectory = "D:\\FilePuller";  //Local directory where the files will be downloaded
            DownloadFile(_ftpURL, _UserName, _Password, _ftpDirectory, _FileName, _LocalDirectory);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
    }
}
