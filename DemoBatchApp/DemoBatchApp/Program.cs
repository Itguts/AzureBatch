// See https://aka.ms/new-console-template for more information
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace DemoBatchApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                //"C:\\Vikash\\OneDrive-Accenture\\OneDrive - Accenture\\Training\\Azure_Batch\\Data";
                string folderPath = args[0];
                Console.Write(folderPath);
                if (Directory.Exists(folderPath))
                {
                    foreach (var file in Directory.GetFiles(folderPath))
                    {
                        if (File.Exists(file) && Path.GetExtension(file) == ".txt" && Path.GetFileName(file).Contains("Output")!=true)
                        {
                            ProcessFile(Path.GetFullPath(file), Path.GetFileName(file));
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
        }
        static private void ProcessFile(string strInputFilePath, string strInputFileName)
        {
            String line;
            List<String> lines = new List<String>();

            using (StreamReader sr = new StreamReader(strInputFilePath))
                while ((line = sr.ReadLine()) != null)
                {
                    var ctc = Convert.ToInt32(line.Split(',')[1]);
                    var tax = 0;
                    if (ctc > 500000)
                        tax = ctc * 10 / 100;
                    else
                        tax = ctc * 30 / 100;
                    line += line + "," + tax;
                    Console.Write(line);
                    lines.Add(line);
                }
            //writing to putput file
            using (TextWriter tw = new StreamWriter(strInputFilePath.Replace(strInputFileName, "Output_" + strInputFileName)))
            {
                foreach (String s in lines)
                    tw.WriteLine(s);
            }

        }

    }
}

