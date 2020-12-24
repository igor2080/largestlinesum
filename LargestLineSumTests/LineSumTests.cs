using Microsoft.VisualStudio.TestTools.UnitTesting;
using LargestLineSum;
using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;

namespace LargestLineSumTests
{
    [TestClass]
    public class LineSumTests
    {
        [TestMethod]
        public void IsFilePathValid_Valid_File()
        {
            Program program = new Program();
            string input = @"text.txt";//an actual file
            Assert.IsTrue(program.IsFileValid(input));
        }

        [TestMethod]
        public void IsFilePathValid_Invalid_File()
        {
            Program program = new Program();
            string input = @"nothing.txt";
            Assert.IsFalse(program.IsFileValid(input));
        }

        [TestMethod]
        public void GetLargestLineSumLine_Highest_Line_Sum()
        {
            string input = @"text.txt";
            LineReader lineReader = new LineReader(input);
            //file contents:
            //1,2,3,4,5
            //er,qwe
            //1,2,3,4,e
            //100,200,300,400,500
            //100,200,300,400,,500
            //1.1,1.2,1,3.1,5,1.4
            //10000.5,1,2,3,100.
            //1.e,1.2,1.3
            //1.0,2.0,3.0,4.0,5.0
            int expectedResult = 4;
            int actualResult = lineReader.GetLargestLineSumLine(out List<int> invalidLines);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetLargestLineSumLine_Empty_File()
        {
            string input = @"empty.txt";
            LineReader lineReader = new LineReader(input);
            //file contents:
            //
            int expectedResult = 0;
            int actualResult = lineReader.GetLargestLineSumLine(out List<int> invalidLines);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetLargestLineSumLine_No_Valid_Lines()
        {
            string input = @"bad.txt";
            LineReader lineReader = new LineReader(input);
            //file contents:
            //1,2,!,4,5
            //er,qwe
            //1,2,3,4,e
            //100,?,300,400,500
            //100,200,300,400,,500
            int expectedResult = 0;
            int actualResult = lineReader.GetLargestLineSumLine(out List<int> invalidLines);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetLargestLineSumLine_Invalid_Lines()
        {
            string input = @"text.txt";
            LineReader lineReader = new LineReader(input);
            //file contents:
            //1,2,3,4,5
            //er,qwe
            //1,2,3,4,e
            //100,200,300,400,500
            //100,200,300,400,,500
            //1.1,1.2,1,3.1,5,1.4
            //10000.5,1,2,3,100.
            //1.e,1.2,1.3
            //1.0,2.0,3.0,4.0,5.0
            var expectedResult = new List<int> { 2, 3, 5, 7, 8 };
            lineReader.GetLargestLineSumLine(out List<int> actualResult);
            Assert.IsTrue(expectedResult.SequenceEqual(actualResult));
        }

        [TestMethod]
        public void GetLargestLineSumLine_Empty_File_Invalid_Lines()
        {
            string input = @"empty.txt";
            LineReader lineReader = new LineReader(input);
            //file contents:
            //
            var expectedResult = new List<int> { };
            lineReader.GetLargestLineSumLine(out List<int> actualResult);
            Assert.IsTrue(expectedResult.SequenceEqual(actualResult));
        }

    }
}
