using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LargestLineSum
{
    public class FileProcessor
    {
        public string[] GetFileText(string filePath)
        {
            if (IsFilePathValid(filePath) && IsFileValid(filePath))
                return File.ReadAllLines(filePath);
            else
                return null;
        }

        public bool IsFilePathValid(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                return false;

            string fullPath;
            string fileName;

            try
            {
                fullPath = Path.GetPathRoot(path);
                fileName = Path.GetFileName(path);
            }
            catch (Exception)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(fileName))
                return false;

            if (fullPath.IndexOfAny(Path.GetInvalidPathChars()) >= 0 || fileName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
                return false;

            return true;
        }

        private bool IsFileValid(string path)
        {
            return File.Exists(path);
        }
    }
}
