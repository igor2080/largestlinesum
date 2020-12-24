using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace LargestLineSum
{
    public class Program
    {
        const string ContinueKey = "1";

        public void Start(string arg = "")
        {
            string filePath;
            LineReader lineReader;
            filePath = FileProcessor.ValidateFileInput(arg);
            lineReader = new LineReader();
            lineReader.SetFile(filePath);
            int largestLine = lineReader.GetLargestLineSumLine(out List<int> invalidLines);
            Console.WriteLine($"The largest number sum was found on line {largestLine}");
            Console.WriteLine($"The lines with bad text are: {string.Join(',', invalidLines)}");
        }

        public bool PromptTryAgain()
        {
            Console.WriteLine("Would you like to input a new file? Type 1 to restart or anything else to exit: ");
            return Console.ReadLine() == ContinueKey;
        }

        public static void Main(string[] args)
        {
            Program program = new Program();
            do
            {
                if (args.Length > 0)
                    program.Start(args[0]);
                else
                    program.Start();
            } while (program.PromptTryAgain());
        }
    }
}
