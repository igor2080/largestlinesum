using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace LargestLineSum
{
    public class Program
    {
        const string ContinueKey = "1";
        private readonly LineReader _lineReader = new LineReader();
        private readonly FileProcessor _fileProcessor = new FileProcessor();

        public void Start()
        {
            string[] currentFile;
            do
            {
                currentFile = GetFileFromUserInput();
                int largestLine = _lineReader.GetLargestLineSumLine(currentFile, out List<int> invalidLines);
                PrintStats(largestLine, invalidLines);
            }
            while (PromptTryAgain());
        }

        private static void PrintStats(int largestLine, List<int> invalidLines)
        {
            if (largestLine > 0)
                Console.WriteLine($"The largest number sum was found on line {largestLine}");
            else
                Console.WriteLine($"No lines with only numbers found");

            Console.WriteLine($"The lines with bad text are: {string.Join(',', invalidLines)}");
        }

        private bool PromptTryAgain()
        {
            Console.WriteLine("Would you like to input a new file? Type 1 to restart or anything else to exit: ");
            return Console.ReadLine() == ContinueKey;
        }

        private string[] GetFileFromUserInput()
        {
            string filePath;
            string[] fileText;

            if (Environment.GetCommandLineArgs().Length > 1)//first element is the dll
            {
                filePath = Environment.GetCommandLineArgs()[1];
            }
            else
            {
                Console.WriteLine("Please enter a path with a valid file or press ctrl+c to exit: ");
                filePath = Console.ReadLine();
            }

            try
            {
                fileText = _fileProcessor.GetLinesFromFile(filePath);
            }
            catch (ArgumentNullException exception)
            {
                Console.Write(exception.Message);
                return GetFileFromUserInput();
            }
            catch (FileNotFoundException exception)
            {
                Console.Write(exception.Message);
                return GetFileFromUserInput();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Unexpected exception occurs {exception.Message}");
                return GetFileFromUserInput();
            }

            return fileText;
        }

        public static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();
        }
    }
}
