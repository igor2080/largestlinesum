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
        public int GetLargestLineSumLine(string[] file, out List<int> invalidLines)
        {
            invalidLines = new List<int>();

            if (file.Length < 1)
                return 0;

            double largestSum = 0;
            double currentSum = 0;
            int largestSumLine = 0;
            int currentLineNumber = 1;
            string[] splitLine;

            for (int i = 0; i < file.Length; i++)
            {
                splitLine = file[i].Split(',');

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
