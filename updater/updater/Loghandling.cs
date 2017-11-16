using System;
using System.IO;

namespace updater
{
    class Loghandling
    {
        public static void Logerror(string error)
        {
            string filename = "logs.txt";
            if (!File.Exists(filename))
                File.WriteAllText(filename, Properties.Resources.logs);

            //allows to take annoying errors into a log.txt file rather than having many pop up windows
            var date = DateTime.Now.ToString("yyyyMMddHHmmss");

            StreamWriter file2 = new StreamWriter("logs.txt", append: true);
            file2.WriteLine("---------Start---------" + "\r\n" + date + " : " + error + "\r\n" + "----------End----------");
            file2.Close();
        }
    }
}
