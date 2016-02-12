using System; 
using System.Linq;
using System.Collections.Generic;

namespace Trainbox
{
    public class Program
    {
        static void Main(string[] args)
        {
            //string openFile = @"D:\Studia\MMDS\Next\train.csv";
            //string saveToFile = "train.txt";

            string openFile = @"D:\Studia\MMDS\Next\test.csv";
            string saveToFile = "test.txt";
            CSVProcessing.ConvertCSV(openFile, saveToFile);
        }
    }
}
