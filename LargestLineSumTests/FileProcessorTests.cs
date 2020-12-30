using Microsoft.VisualStudio.TestTools.UnitTesting;
using LargestLineSum;
using System.IO;
using System;

namespace LargestLineSumTests
{
    [TestClass]
    public class FileProcessorTests
    {
        private readonly FileProcessor _fileProcessor = new FileProcessor();
        private const string FileName = "text.txt";

        [TestInitialize]
        public void FileProcessorInit()
        {
            File.CreateText(FileName).Close();
        }

        [TestCleanup]
        public void FileProcessorClean()
        {
            File.Delete(FileName);
        }

        [TestMethod]
        public void GetLinesFromFile_Valid_File()
        {
            string[] result = _fileProcessor.GetLinesFromFile(FileName);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void GetLinesFromFile_Nonexistent_File_Name_Throws()
        {
            string[] result = _fileProcessor.GetLinesFromFile("nothing.txt");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetLinesFromFile_Null_File_Throws()
        {
            string[] result = _fileProcessor.GetLinesFromFile(null);
        }

        [TestMethod]
        public void GetLinesFromFile_Single_Line_File()
        {
            string input = "1,2,3,4,5";
            using (var tempWriter = new StreamWriter(FileName))
            {
                tempWriter.Write(input);
            }

            int expectedResult = 1;
            string[] actualResult = _fileProcessor.GetLinesFromFile(FileName);
            Assert.AreEqual(expectedResult, actualResult.Length);


        }

    }
}
