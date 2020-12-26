using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LargestLineSum
{
    public class Program
    {
        const string ContinueKey = "1";

        public void Start(string arg = "")
        {
            string filePath;
            LineReader lineReader = new LineReader();

            if (string.IsNullOrWhiteSpace(arg))
                filePath = GetValidUserInput();
            else
                filePath = arg;

            int largestLine = lineReader.GetLargestLineSumLine(filePath, out List<int> invalidLines);

            if (largestLine > 0)
                Console.WriteLine($"The largest number sum was found on line {largestLine}");
            else
                Console.WriteLine($"No lines with only numbers found");

            Console.WriteLine($"The lines with bad text are: {string.Join(',', invalidLines)}");
        }

        public bool IsArgumentValidFile(string arg)
        {
            return FileProcessor.IsFileValid(arg);
        }

        public bool PromptTryAgain()
        {
            Console.WriteLine("Would you like to input a new file? Type 1 to restart or anything else to exit: ");
            return Console.ReadLine() == ContinueKey;
        }

        public string GetValidUserInput()
        {
            Console.WriteLine("Please enter a path with a valid file: ");
            string filePath = Console.ReadLine();

            while (!FileProcessor.IsFileValid(filePath))
            {
                Console.WriteLine("The given file is invalid or does not exist. Please enter a valid path or press ctrl+c to exit: ");
                filePath = Console.ReadLine();
            }

            return filePath;
        }


        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Program program = new Program();

            do
            {
                if (args.Length > 0 && program.IsArgumentValidFile(args[0]))
                    program.Start(args[0]);
                else
                    program.Start();
            } while (program.PromptTryAgain());
        }
    }
}
