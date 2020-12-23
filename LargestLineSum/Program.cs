using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LargestLineSum
{
    public class Program
    {
        const string ContinueKey = "1";
        public bool IsFileValid(string path)
        {
            return File.Exists(path);
        }

        public void Start(string[] args)
        {
            string filePath;
            LineReader lineReader;

            if (args.Length < 1)
            {
                Console.WriteLine("Please enter a file path: ");
                filePath = Console.ReadLine();
            }
            else
            {
                filePath = args[0];
            }

            while (!IsFileValid(filePath))
            {
                Console.WriteLine("The given file is invalid or does not exist. Please enter a new path or press ctrl+c to exit: ");
                filePath = Console.ReadLine();
            }

            lineReader = new LineReader(filePath);
            int largestLine = lineReader.GetLargestLineSumLine(out List<int> invalidLines);
            Console.WriteLine($"The largest number sum was found on line {largestLine}");
            Console.WriteLine($"The lines with bad text are: {string.Join(',', invalidLines)}");
        }

        public bool PromptTryAgain()
        {
            Console.WriteLine("Would you like to input a new matrix? Type 1 to restart or anything else to exit: ");
            return Console.ReadLine() == ContinueKey;
        }

        public static void Main(string[] args)
        {
            Program program = new Program();
            do
            {
                program.Start(args);
                args = new string[] { };
            } while (program.PromptTryAgain());
        }
    }
}
