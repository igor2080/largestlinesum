using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LargestLineSum
{
    public class FileExtractor
    {
        private readonly string[] _fileContent;
        public string[] GetFileText { get { return _fileContent; } }
        public FileExtractor(string filePath)
        {
            _fileContent = File.ReadAllLines(filePath);
        }
    }
}
