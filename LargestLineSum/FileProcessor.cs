using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LargestLineSum
{
    public class FileProcessor
    {
        public string[] GetFileText { get; private set; }
        public FileProcessor(string filePath)
        {
            ReadFile(filePath);
        }
        private void ReadFile(string filePath)
        {
            GetFileText = File.ReadAllLines(filePath);
        }
        public static bool IsFileValid(string path)
        {
            return File.Exists(path);
        }
        public static string ValidateFileInput(string arg)
        {
            if (!IsFileValid(arg))
            {
                Console.WriteLine("Please enter a path with a valid file: ");
                string filePath = Console.ReadLine();

                while (!IsFileValid(filePath))
                {
                    Console.WriteLine("The given file is invalid or does not exist. Please enter a valid path or press ctrl+c to exit: ");
                    filePath = Console.ReadLine();
                }
                return filePath;
            }
            else return arg;
        }
    }
}
