using System.IO;

namespace tsrvtcnew
{
    class Loghandling
    {
        public static void Logerror(string error)
        {
            string filename = "logs.txt";
            if (!System.IO.File.Exists(filename))
                System.IO.File.WriteAllText(filename, Properties.Resources.logs);

            StreamWriter file2 = new StreamWriter("logs.txt", append: true);
            file2.WriteLine("\n" + error + "\n" + "----------End----------");
            file2.Close();
        }
    }
}
