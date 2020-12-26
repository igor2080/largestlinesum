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
    }
}
