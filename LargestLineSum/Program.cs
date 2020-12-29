using System;
using System.Collections.Generic;
using System.IO;

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
            if (args.Length > 0)
            {
                program.Start(args[0]);
            }
            else
            {
                program.Start("");
            }
        }
        public void Start(string arg)
        {
            do
            {
                string fileName = GetFileNameFromUserInput(arg);
                string[] fileText=new string[] { };

                try
                {
                    fileText = _fileProcessor.GetLinesFromFile(fileName);
                }
                catch (ArgumentNullException exception)
                {
                    Console.Write(exception.Message);
                    Start("");
                }
                catch (FileNotFoundException exception)
                {
                    Console.Write(exception.Message);
                    Start("");
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"Unexpected exception: {exception.Message}");
                    Start("");
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

        private string GetFileNameFromUserInput(string arg)
        {
            string filePath;

            if (string.IsNullOrWhiteSpace(arg))
            {
                Console.WriteLine("Please enter a path with a valid file or press ctrl+c to exit: ");
                filePath = Console.ReadLine();
            }
            else
            {
                filePath = arg;
            }

            return filePath;
        }


    }
}
