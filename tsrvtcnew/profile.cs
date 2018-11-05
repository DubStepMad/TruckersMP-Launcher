using System;
using System.IO;
using System.Net;
using System.IO.Compression;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace tsrvtcnew
{
    internal class Profile
    {
        //local variables
        private static string fileLink = "";

        public static void Run()
        {
            try
            {
                MySqlConnection connectionMySQL = new MySqlConnection("server=217.***;uid=senkawol_dubstep;password=**;database=senkawol_hub_wtl;");
                connectionMySQL.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM convoys WHERE DATE(startdate) = CURDATE()", connectionMySQL);
                MySqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                fileLink = rdr.GetString("profilelink");
                rdr.Close();
                connectionMySQL.Close();
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                Loghandling.Logerror(error);

                MessageBox.Show("No Convoy Today!");
                return;
            }

            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string profileLocation = Path.GetDirectoryName(documentsPath + "/Euro Truck Simulator 2/profiles/");

            string _LocalDirectory = profileLocation;  //Local directory where the files will be downloaded

            File.Delete(profileLocation + "/57544c204576656e74205465616d.zip");
            Directory.Delete(profileLocation + "/57544c204576656e74205465616d", true);

            DownloadUpdate(fileLink);
        }

        public static void DownloadUpdate(string fileLink)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string profileLocation = Path.GetDirectoryName(documentsPath + "/Euro Truck Simulator 2/profiles/");

            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers.Add("Accept: text/html, application/xhtml+xml, */*");
                webClient.Headers.Add("User-Agent: Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)");
                webClient.DownloadFileAsync(new Uri(fileLink), profileLocation + "/57544c204576656e74205465616d.zip");

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                Loghandling.Logerror(error);
                return;
            }

            ZipFile.ExtractToDirectory(profileLocation + "/57544c204576656e74205465616d.zip", profileLocation);
            File.Delete(profileLocation + "/57544c204576656e74205465616d.zip");
        }

    }
}
