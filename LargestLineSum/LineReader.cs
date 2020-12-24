using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace LargestLineSum
{
    public class LineReader
    {
        private readonly string _filePath;
        private readonly FileExtractor _file;
        public LineReader(string filePath)
        {
            _filePath = filePath;
            _file = new FileExtractor(_filePath);
        }
        public int GetLargestLineSumLine(out List<int> invalidLines)
        {
            double numberSum = 0;
            double currentSum = 0;
            int largestLine = 0;
            int currentLineNumber = 1;
            invalidLines = new List<int>();
            string[] splitLine;

            for (int i = 0; i < _file.GetFileText.Length; i++)
            {
                splitLine = _file.GetFileText[i].Split(',');
                if (splitLine.All(x => Regex.IsMatch(x, @"^-?[0-9]*\.?[0-9]+$")))
                {
                    currentSum = splitLine.Sum(x => double.Parse(x));
                    if (currentSum > numberSum)
                    {
                        numberSum = currentSum;
                        largestLine = currentLineNumber;
                    }
                }
                else
                {//non numbers inside the line
                    invalidLines.Add(currentLineNumber);
                }
                currentLineNumber++;
            }

            return largestLine;
        }

    }
}
