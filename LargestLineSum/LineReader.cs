using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Globalization;

namespace LargestLineSum
{
    public class LineReader
    {
        public int GetLargestLineSumLine(string[] textLines, out List<int> invalidLines)
        {
            invalidLines = new List<int>();

            if (textLines == null)
            {
                throw new ArgumentNullException(nameof(textLines), "The text array cannot be null.");
            }

            if (textLines.Length < 1)
            {
                return 0;
            }

            double largestSum = 0;
            int largestSumLine = 0;

            for (int i = 0; i < textLines.Length; i++)
            {
                string[] splitLine = textLines[i].Split(',');

                if (splitLine.Any(x => !Regex.IsMatch(x, @"^-?[0-9]*\.?[0-9]+$")))
                {
                    invalidLines.Add(i + 1);
                }
                else
                {
                    double currentSum = splitLine.Sum(x => double.Parse(x, CultureInfo.InvariantCulture.NumberFormat));
                    if (currentSum > largestSum)
                    {
                        largestSum = currentSum;
                        largestSumLine = i + 1;
                    }
                }
            }

            return largestSumLine;
        }

    }
}
