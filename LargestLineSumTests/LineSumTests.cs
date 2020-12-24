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
        public void IsFileValid_Valid_File()
        {
            File.CreateText("text.txt").Close();
            string input = "text.txt";
            Assert.IsTrue(FileProcessor.IsFileValid(input));
            File.Delete("text.txt");
        }

        [TestMethod]
        public void IsFileValid_Invalid_File()
        {
            string input = "nothing.txt";
            Assert.IsFalse(FileProcessor.IsFileValid(input));

        }

        [TestMethod]
        public void GetLargestLineSumLine_Highest_Line_Sum()
        {
            using (var tempFile = File.CreateText("text.txt"))
            {
                tempFile.Write("1,2,3,4,5\ner,qwe\n1,2,3,4,e\n100,200,300,400,500\n100,200,300,400,,500\n1.1,1.2,1,3.1,5,1.4\n10000.5,1,2,3,100.\n1.e,1.2,1.3\n1.0,2.0,3.0,4.0,5.0");
            }
            string input = "text.txt";
            LineReader lineReader = new LineReader();
            lineReader.SetFile(input);
            //file contents:
            //1,2,3,4,5\n
            //er,qwe\n
            //1,2,3,4,e\n
            //100,200,300,400,500\n
            //100,200,300,400,,500\n
            //1.1,1.2,1,3.1,5,1.4\n
            //10000.5,1,2,3,100.\n
            //1.e,1.2,1.3\n
            //1.0,2.0,3.0,4.0,5.0
            int expectedResult = 4;
            int actualResult = lineReader.GetLargestLineSumLine(out List<int> invalidLines);
            Assert.AreEqual(expectedResult, actualResult);
            File.Delete("text.txt");
        }

        [TestMethod]
        public void GetLargestLineSumLine_Empty_File()
        {
            File.CreateText("empty.txt").Close();
            string input = "empty.txt";
            LineReader lineReader = new LineReader();
            lineReader.SetFile(input);
            //file contents:
            //
            int expectedResult = 0;
            int actualResult = lineReader.GetLargestLineSumLine(out List<int> invalidLines);
            Assert.AreEqual(expectedResult, actualResult);
            File.Delete("empty.txt");
        }

        [TestMethod]
        public void GetLargestLineSumLine_No_Valid_Lines()
        {
            using (var tempFile = File.CreateText("bad.txt"))
            {
                tempFile.Write("1,2,!,4,5\ner,qwe\n1,2,3,4,e\n100,?,300,400,500\n100,200,300,400,,500");
            }
            string input = "bad.txt";
            LineReader lineReader = new LineReader();
            lineReader.SetFile(input);
            //file contents:
            //1,2,!,4,5
            //er,qwe
            //1,2,3,4,e
            //100,?,300,400,500
            //100,200,300,400,,500
            int expectedResult = 0;
            int actualResult = lineReader.GetLargestLineSumLine(out List<int> invalidLines);
            Assert.AreEqual(expectedResult, actualResult);
            File.Delete("bad.txt");
        }

        [TestMethod]
        public void GetLargestLineSumLine_Invalid_Lines()
        {
            using (var tempFile = File.CreateText("text.txt"))
            {
                tempFile.Write("1,2,3,4,5\ner,qwe\n1,2,3,4,e\n100,200,300,400,500\n100,200,300,400,,500\n1.1,1.2,1,3.1,5,1.4\n10000.5,1,2,3,100.\n1.e,1.2,1.3\n1.0,2.0,3.0,4.0,5.0");
            }
            string input = "text.txt";
            LineReader lineReader = new LineReader();
            lineReader.SetFile(input);
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
            File.Delete("text.txt");
        }

        [TestMethod]
        public void GetLargestLineSumLine_Empty_File_Invalid_Lines()
        {
            File.CreateText("empty.txt").Close();
            string input = "empty.txt";
            LineReader lineReader = new LineReader();
            lineReader.SetFile(input);
            //file contents:
            //
            var expectedResult = new List<int> { };
            lineReader.GetLargestLineSumLine(out List<int> actualResult);
            Assert.IsTrue(expectedResult.SequenceEqual(actualResult));
            File.Delete("empty.txt");
        }
    }
}
