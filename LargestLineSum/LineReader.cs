using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace LargestLineSum
{
    public class LineReader
    {
        private readonly string _filePath;
        public LineReader(string filePath)
        {
            _filePath = filePath;
        }
        public int GetLargestLineSumLine(out List<int> invalidLines)
        {
            float numberSum = 0;
            float currentSum = 0;
            int largestLine = 0;
            int currentLineNumber = 1;
            string currentLine;
            invalidLines = new List<int>();

            using (StreamReader file = new StreamReader(_filePath))
            {
                while ((currentLine = file.ReadLine()) != null)
                {
                    try
                    {
                        currentSum = currentLine.Split(',').Sum(x => float.Parse(x));
                        if (currentSum > numberSum)
                        {
                            numberSum = currentSum;
                            largestLine = currentLineNumber;
                        }
                    }
                    catch
                    {//non numbers inside the line
                        invalidLines.Add(currentLineNumber);
                    }
                    currentLineNumber++;
                }
            }

            return largestLine;
        }
    }
}
