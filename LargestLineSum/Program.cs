using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LargestLineSum
{
    public class Program
    {
        const string ContinueKey = "1";
        private readonly LineReader _lineReader = new LineReader();
        private readonly FileProcessor _fileProcessor = new FileProcessor();

        public static void Main(string[] args)
        {
            Program program = new Program();
            program.Start(args.FirstOrDefault());
        }

        public void Start(string arg)
        {
            do
            {
                string fileName = GetFileNameFromUserInput(arg);
                string[] fileText = new string[] { };

                try
                {
                    fileText = _fileProcessor.GetLinesFromFile(fileName);
                }
                catch (FileNotFoundException exception)
                {
                    Console.Write(exception.Message);
                    if (PromptTryAgain())
                    {
                        Start("");
                    }

                    Environment.Exit(0);
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"Unexpected exception: {exception.Message}");
                    Environment.Exit(1);
                }

                int largestLine = _lineReader.GetLargestLineSumLine(fileText, out List<int> invalidLines);
                PrintStats(largestLine, invalidLines);
            }
            while (PromptTryAgain());
        }

        private void PrintStats(int largestLine, List<int> invalidLines)
        {
            if (largestLine > 0)
            {
                Console.WriteLine($"The largest number sum was found on line {largestLine}");
            }
            else
            {
                Console.WriteLine($"No lines with only numbers found");
            }

            if (invalidLines.Count > 0)
            {
                Console.WriteLine($"The lines with bad text are: {string.Join(',', invalidLines)}");
            }
            else
            {
                Console.WriteLine("There are no lines with bad text.");
            }
        }

        private bool PromptTryAgain()
        {
            Console.WriteLine("Would you like to input a new file? Type 1 to restart or anything else to exit: ");
            return Console.ReadLine() == ContinueKey;
        }

        private string GetFileNameFromUserInput(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                Console.WriteLine("Please enter a path with a valid file or press ctrl+c to exit: ");
                return GetFileNameFromUserInput(Console.ReadLine());
            }

            return text;
        }


    }
}
