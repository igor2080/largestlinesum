using Microsoft.VisualStudio.TestTools.UnitTesting;
using LargestLineSum;
using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;

namespace LargestLineSumTests
{
    [TestClass]
    public class LineReaderTests
    {
        private readonly LineReader _lineReader = new LineReader();

        [TestMethod]
        public void GetLargestLineSumLine_Highest_Line_Sum()
        {
            string[] input = new string[] {
                    "1,2,3,4,5\n",
                    "er,qwe\n",
                    "1,2,3,4,e\n",
                    "100,200,300,400,500\n",
                    "100,200,300,400,,500\n",
                    "1.1,1.2,1,3.1,5,1.4\n",
                    "10000.5,1,2,3,100.\n",
                    "1.e,1.2,1.3\n",
                    "1.0,2.0,3.0,4.0,5.0"};

            int expectedResult = 4;
            int actualResult = _lineReader.GetLargestLineSumLine(input, out List<int> invalidLines);
            Assert.AreEqual(expectedResult, actualResult);
        }

        public void GetLargestLineSumLine_Highest_Line_Sum_Negatives_Only()
        {
            string[] input = new string[] {
                    "-1,-2,-3,-4,-5",
                    "-1,-2,-3,-4",
                    "-1,-2,-3",
                    "-1,-2",
                    "-1"};

            int expectedResult = 5;
            int actualResult = _lineReader.GetLargestLineSumLine(input, out List<int> invalidLines);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetLargestLineSumLine_Empty_File_Highest_Line_Sum_Zero()
        {

            string[] input = new string[] { };
            int expectedResult = 0;
            int actualResult = _lineReader.GetLargestLineSumLine(input, out List<int> invalidLines);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetLargestLineSumLine_No_Valid_Lines_Highest_Line_Sum_Zero()
        {
            string[] input = new string[] {
                    "1,2,!,4,5\n",
                    "er,qwe\n",
                    "1,2,3,4,e\n",
                    "100,?,300,400,500\n",
                    "100,200,300,400,,500"};

            int expectedResult = 0;
            int actualResult = _lineReader.GetLargestLineSumLine(input, out List<int> invalidLines);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetLargestLineSumLine_Invalid_Lines()
        {
            string[] input = new string[] {
                     "1,2,3,4,5\n",
                    "er,qwe\n",
                    "1,2,3,4,e\n",
                    "100,200,300,400,500\n",
                    "100,200,300,400,,500\n",
                    "1.1,1.2,1,3.1,5,1.4\n",
                    "10000.5,1,2,3,100.\n",
                    "1.e,1.2,1.3\n",
                     "1.0,2.0,3.0,4.0,5.0"};

            var expectedResult = new List<int> { 2, 3, 5, 7, 8 };
            _lineReader.GetLargestLineSumLine(input, out List<int> actualResult);
            Assert.IsTrue(expectedResult.SequenceEqual(actualResult));
        }

        [TestMethod]
        public void GetLargestLineSumLine_Empty_File_Invalid_Lines_Empty()
        {
            string[] input = new string[] { };
            var expectedResult = new List<int> { };
            _lineReader.GetLargestLineSumLine(input, out List<int> actualResult);
            Assert.IsTrue(expectedResult.SequenceEqual(actualResult));
        }

    }
}
