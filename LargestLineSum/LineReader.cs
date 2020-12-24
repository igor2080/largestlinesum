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
        private FileProcessor _file;
        public void SetFile(string filePath)
        {
            _file = new FileProcessor(filePath);
        }
        public int GetLargestLineSumLine(out List<int> invalidLines)
        {
            double largestSum = 0;
            double currentSum = 0;
            int largestSumLine = 0;
            int currentLineNumber = 1;
            invalidLines = new List<int>();
            string[] splitLine;

            for (int i = 0; i < _file.GetFileText.Length; i++)
            {
                splitLine = _file.GetFileText[i].Split(',');
                if (!splitLine.Any(x => !Regex.IsMatch(x, @"^-?[0-9]*\.?[0-9]+$")))
                {
                    currentSum = splitLine.Sum(x => double.Parse(x));
                    if (currentSum > largestSum)
                    {
                        largestSum = currentSum;
                        largestSumLine = currentLineNumber;
                    }
                }
                else
                {//non numbers inside the line
                    invalidLines.Add(currentLineNumber);
                }
                currentLineNumber++;
            }

            return largestSumLine;
        }

    }
}
