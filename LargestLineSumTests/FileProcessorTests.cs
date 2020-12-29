using Microsoft.VisualStudio.TestTools.UnitTesting;
using LargestLineSum;
using System.IO;

namespace LargestLineSumTests
{
    [TestClass]
    public class FileProcessorTests
    {
        private FileProcessor _fileProcessor;
        private const string FileName = "text.txt";

        [TestInitialize]
        public void FileProcessorInit()
        {
            _fileProcessor = new FileProcessor();
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

        
    }
}
