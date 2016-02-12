using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trainbox
{
    public class CSVProcessing
    {
        public static void ConvertCSV(string openFile, string saveToFile)
        {
            int counter = 0;
            using (FileStream fs = File.Open(openFile, FileMode.Open))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    int iterator = 1;
                    string[] stringSeparators = new string[] { "::::" };
                    var row = line.Split(stringSeparators, StringSplitOptions.None);
                    //int clicked = int.Parse(row[1].Trim());
                    int queryId = int.Parse(row[0].Trim());
                    string query = row[4];
                    string link = row[5].Trim();
                    string[] vertor = row[2].Trim().Substring(1, (row[2].Trim().Length - 2)).Replace(" ", "").Replace(".", "a").Replace(",", ".").Replace("a", ",").Split('.');
                    var list = new List<decimal>();
                    //string temp = string.Concat(clicked, " qid:", queryId, " ");
                    string temp = string.Concat("qid:", queryId, " ");

                    foreach (var item in vertor)
                    {
                        temp = string.Concat(temp, iterator, ":", Decimal.Parse(item, System.Globalization.NumberStyles.Float));
                        temp = string.Concat(temp, " ");
                        iterator++;
                    }
                    temp = temp.Replace(",", ".");
                    temp = string.Concat(temp, "# ", query, " | ", link);

                    CSVProcessing.ExportToFile(temp, saveToFile);
                    counter++;
                }
            }
        }

        public static void ExportToFile(string line, string saveToFile)
        {
            if (!File.Exists(saveToFile))
            {
                using (File.Create(saveToFile)){ }
                
                TextWriter tw = new StreamWriter(saveToFile);
                tw.WriteLine(line);
                tw.Close();
            }
            else if (File.Exists(saveToFile))
            {
                TextWriter tw = new StreamWriter(saveToFile, true);
                tw.WriteLine(line);
                tw.Close();
            }
        }
    }
}
