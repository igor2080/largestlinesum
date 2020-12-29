using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LargestLineSum
{
    public class FileProcessor
    {
        public string[] GetLinesFromFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException("The file path is empty or null. ");
            }

            ValidateFileExistsOrThrow(filePath);
            return File.ReadAllLines(filePath);
        }

        private void ValidateFileExistsOrThrow(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("The given file is invalid or does not exist. ");
            }
        }
    }
}
