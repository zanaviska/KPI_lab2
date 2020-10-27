using System;
using Xunit;
using IIG.FileWorker;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        static string pathToFiles = @"C:\Users\user\Desktop\proj\lab2_kpi\XUnitTestProject1\XUnitTestProject1\Files";
        //static string pathToFiles = System.IO.Directory.GetCurrentDirectory() + "\\..\\..\\..";
        [Fact]
        public void TestGetFileNameReturnNull()
        {
            //non-existed file
            Assert.Null(BaseFileWorker.GetFileName(pathToFiles + @"\IIF"));
            //folder
            Assert.Null(BaseFileWorker.GetFileName(pathToFiles));
            //existed file but with no extension
            Assert.Null(BaseFileWorker.GetFileName(pathToFiles + @"\test"));
        }
        [Fact]
        public void TestGetFileNameReturnValidName()
        {
            //without file extension
            Assert.Equal("IIG", BaseFileWorker.GetFileName(pathToFiles + @"\IIG"));
            //regular
            Assert.Equal("a.txt", BaseFileWorker.GetFileName(pathToFiles + @"\a.txt"));
            //with space in name
            Assert.Equal("I IG.txt", BaseFileWorker.GetFileName(pathToFiles + @"\I IG.txt"));
            //with cyrilic in nane
            Assert.Equal("абв.txt", BaseFileWorker.GetFileName(pathToFiles + @"\абв.txt"));
            //with ieroglif
            Assert.Equal("お母様.txt", BaseFileWorker.GetFileName(pathToFiles + @"\お母様.txt"));
            //with few dots in name
            Assert.Equal("a.b.c.txt", BaseFileWorker.GetFileName(pathToFiles + @"\a.b.c.txt"));
            //with smiles
            Assert.Equal("😅.txt", BaseFileWorker.GetFileName(pathToFiles + @"\😅.txt"));
            //with different extensions
            Assert.Equal("a.cs", BaseFileWorker.GetFileName(pathToFiles + @"\a.cs"));
            Assert.Equal("a.docx", BaseFileWorker.GetFileName(pathToFiles + @"\a.docx"));
            Assert.Equal("a.mp4", BaseFileWorker.GetFileName(pathToFiles + @"\a.mp4"));
            Assert.Equal("a.pptx", BaseFileWorker.GetFileName(pathToFiles + @"\a.pptx"));
            Assert.Equal("a.torrent", BaseFileWorker.GetFileName(pathToFiles + @"\a.torrent"));
        }
        [Fact]
        public void TestGetFullPath()
        {
        }
    }

}
