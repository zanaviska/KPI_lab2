using System;
using Xunit;
using IIG.FileWorker;
using System.IO;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        static string pathToFiles = System.IO.Path.GetFullPath(System.IO.Directory.GetCurrentDirectory() + "\\..\\..\\..\\Files");
        [Fact]
        public void TestGetFileNameReturnNull()
        {
            //non-existed file
            Assert.Null(BaseFileWorker.GetFileName(pathToFiles + @"\IIF"));
            //folder
            Assert.Null(BaseFileWorker.GetFileName(pathToFiles + "\\empty"));
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
        public void TestGetFullPathReturnNull()
        {
            //get path to files without file
            Assert.Null(BaseFileWorker.GetFullPath(pathToFiles));
            Assert.Null(BaseFileWorker.GetFullPath(@"..\..\..\Files\"));
            //get path to folder
            Assert.Null(BaseFileWorker.GetFullPath(pathToFiles + "\\empty"));
            Assert.Null(BaseFileWorker.GetFullPath(@"..\..\..\Files\empty"));
            //get path to non-existing file
            Assert.Null(BaseFileWorker.GetFullPath(pathToFiles + "\\empty\\file.txt"));
            Assert.Null(BaseFileWorker.GetFullPath(@"..\..\..\Files\empty\file.txt"));
            //get path to file bur forgot to type extension
            Assert.Null(BaseFileWorker.GetFullPath(pathToFiles + "\\test"));
            Assert.Null(BaseFileWorker.GetFullPath(@"..\..\..\Files\test"));
        }
        [Fact]
        public void TestGetFullPathReturnValid()
        {
            //get regular file
            Assert.Equal(pathToFiles + "\\a.txt", BaseFileWorker.GetFullPath(pathToFiles + @"\a.txt"));
            Assert.Equal(pathToFiles + "\\a.txt", BaseFileWorker.GetFullPath(@"..\..\..\Files\a.txt"));
            //get file no extension
            Assert.Equal(pathToFiles + "\\IIG", BaseFileWorker.GetFullPath(pathToFiles + @"\IIG"));
            Assert.Equal(pathToFiles + "\\IIG", BaseFileWorker.GetFullPath(@"..\..\..\Files\IIG"));
            //get file with space in name
            Assert.Equal(pathToFiles + "\\I IG.txt", BaseFileWorker.GetFullPath(pathToFiles + @"\I IG.txt"));
            Assert.Equal(pathToFiles + "\\I IG.txt", BaseFileWorker.GetFullPath(@"..\..\..\Files\I IG.txt"));
            //with cyrilic in nane
            Assert.Equal(pathToFiles + "\\абв.txt", BaseFileWorker.GetFullPath(pathToFiles + @"\абв.txt"));
            Assert.Equal(pathToFiles + "\\абв.txt", BaseFileWorker.GetFullPath(@"..\..\..\Files\абв.txt"));
            //with ieroglif
            Assert.Equal(pathToFiles + "\\お母様.txt", BaseFileWorker.GetFullPath(pathToFiles + @"\お母様.txt"));
            Assert.Equal(pathToFiles + "\\お母様.txt", BaseFileWorker.GetFullPath(@"..\..\..\Files\お母様.txt"));
            //with few dots in name
            Assert.Equal(pathToFiles + "\\a.b.c.txt", BaseFileWorker.GetFullPath(pathToFiles + @"\a.b.c.txt"));
            Assert.Equal(pathToFiles + "\\a.b.c.txt", BaseFileWorker.GetFullPath(@"..\..\..\Files\a.b.c.txt"));
            //with smiles
            Assert.Equal(pathToFiles + "\\😅.txt", BaseFileWorker.GetFullPath(pathToFiles + @"\😅.txt"));
            Assert.Equal(pathToFiles + "\\😅.txt", BaseFileWorker.GetFullPath(@"..\..\..\Files\😅.txt"));
            //with different extensions
            Assert.Equal(pathToFiles + "\\a.cs", BaseFileWorker.GetFullPath(pathToFiles + @"\a.cs"));
            Assert.Equal(pathToFiles + "\\a.cs", BaseFileWorker.GetFullPath(@"..\..\..\Files\a.cs"));
            Assert.Equal(pathToFiles + "\\a.docx", BaseFileWorker.GetFullPath(pathToFiles + @"\a.docx"));
            Assert.Equal(pathToFiles + "\\a.docx", BaseFileWorker.GetFullPath(@"..\..\..\Files\a.docx"));
            Assert.Equal(pathToFiles + "\\a.mp4", BaseFileWorker.GetFullPath(@"..\..\..\Files\a.mp4"));
            Assert.Equal(pathToFiles + "\\a.mp4", BaseFileWorker.GetFullPath(pathToFiles + @"\a.mp4"));
            Assert.Equal(pathToFiles + "\\a.pptx", BaseFileWorker.GetFullPath(pathToFiles + @"\a.pptx"));
            Assert.Equal(pathToFiles + "\\a.pptx", BaseFileWorker.GetFullPath(@"..\..\..\Files\a.pptx"));
            Assert.Equal(pathToFiles + "\\a.torrent", BaseFileWorker.GetFullPath(pathToFiles + @"\a.torrent"));
            Assert.Equal(pathToFiles + "\\a.torrent", BaseFileWorker.GetFullPath(@"..\..\..\Files\a.torrent"));
        }
        [Fact]
        public void GetPathReturnNullTest()
        {
            //without file
            Assert.Null(BaseFileWorker.GetPath(pathToFiles));
            Assert.Null(BaseFileWorker.GetPath(@"..\..\..\Files"));
            //folder
            Assert.Null(BaseFileWorker.GetPath(pathToFiles+"\\empty"));
            Assert.Null(BaseFileWorker.GetPath(@"..\..\..\Files\empty"));
            //non-existed file
            Assert.Null(BaseFileWorker.GetPath(pathToFiles+"\\empty\\test.txt"));
            Assert.Null(BaseFileWorker.GetPath(@"..\..\..\Files\empty\test.txt"));
            //file but forgot to type extension
            Assert.Null(BaseFileWorker.GetPath(pathToFiles+"\\test"));
            Assert.Null(BaseFileWorker.GetPath(@"..\..\..\Files\test"));
        }
        [Fact]
        public void GetPathReturnValidTest()
        {
            //regular
            Assert.Equal(pathToFiles, BaseFileWorker.GetPath(pathToFiles + "\\a.txt"));
            Assert.Equal(pathToFiles, BaseFileWorker.GetPath(@"..\..\..\Files\a.txt"));
            //file with no extension
            Assert.Equal(pathToFiles, BaseFileWorker.GetPath(pathToFiles + @"\IIG"));
            Assert.Equal(pathToFiles, BaseFileWorker.GetPath(@"..\..\..\Files\IIG"));
            //get file path with space in file name
            Assert.Equal(pathToFiles, BaseFileWorker.GetPath(pathToFiles + @"\I IG.txt"));
            Assert.Equal(pathToFiles, BaseFileWorker.GetPath(@"..\..\..\Files\I IG.txt"));
            //get file path with space in folder name
            Assert.Equal(pathToFiles + "\\II G", BaseFileWorker.GetPath(pathToFiles + @"\II G\test.txt"));
            Assert.Equal(pathToFiles + "\\II G", BaseFileWorker.GetPath(@"..\..\..\Files\II G\test.txt"));
            //with cyrilic in file name
            Assert.Equal(pathToFiles, BaseFileWorker.GetPath(pathToFiles + @"\абв.txt"));
            Assert.Equal(pathToFiles, BaseFileWorker.GetPath(@"..\..\..\Files\абв.txt"));
            //with cyrilic in folder name
            Assert.Equal(pathToFiles + "\\йцуке", BaseFileWorker.GetPath(pathToFiles + @"\йцуке\tset.txt"));
            Assert.Equal(pathToFiles + "\\йцуке", BaseFileWorker.GetPath(@"..\..\..\Files\йцуке\tset.txt"));
            //with ieroglif in file name
            Assert.Equal(pathToFiles, BaseFileWorker.GetPath(pathToFiles + @"\お母様.txt"));
            Assert.Equal(pathToFiles, BaseFileWorker.GetPath(@"..\..\..\Files\お母様.txt"));
            //with ieroglif in folder name
            Assert.Equal(pathToFiles + "\\到着した", BaseFileWorker.GetPath(pathToFiles + @"\到着した\test.txt"));
            Assert.Equal(pathToFiles + "\\到着した", BaseFileWorker.GetPath(@"..\..\..\Files\到着した\test.txt"));
            //with few dots in file name
            Assert.Equal(pathToFiles, BaseFileWorker.GetPath(pathToFiles + @"\a.b.c.txt"));
            Assert.Equal(pathToFiles, BaseFileWorker.GetPath(@"..\..\..\Files\a.b.c.txt"));
            //with few dots in folder name
            Assert.Equal(pathToFiles + "\\dot.dot", BaseFileWorker.GetPath(pathToFiles + @"\dot.dot\test.txt"));
            Assert.Equal(pathToFiles + "\\dot.dot", BaseFileWorker.GetPath(@"..\..\..\Files\dot.dot\test.txt"));
            //with smiles in file name
            Assert.Equal(pathToFiles, BaseFileWorker.GetPath(pathToFiles + @"\😅.txt"));
            Assert.Equal(pathToFiles, BaseFileWorker.GetPath(@"..\..\..\Files\😅.txt"));
            //with smiles in folder name
            Assert.Equal(pathToFiles + "\\😂😂", BaseFileWorker.GetPath(pathToFiles + @"\😂😂\test.txt"));
            Assert.Equal(pathToFiles + "\\😂😂", BaseFileWorker.GetPath(@"..\..\..\Files\😂😂\test.txt"));
            //with different extensions
            Assert.Equal(pathToFiles, BaseFileWorker.GetPath(pathToFiles + @"\a.cs"));
            Assert.Equal(pathToFiles, BaseFileWorker.GetPath(@"..\..\..\Files\a.cs"));
            Assert.Equal(pathToFiles, BaseFileWorker.GetPath(pathToFiles + @"\a.docx"));
            Assert.Equal(pathToFiles, BaseFileWorker.GetPath(@"..\..\..\Files\a.docx"));
            Assert.Equal(pathToFiles, BaseFileWorker.GetPath(@"..\..\..\Files\a.mp4"));
            Assert.Equal(pathToFiles, BaseFileWorker.GetPath(pathToFiles + @"\a.mp4"));
            Assert.Equal(pathToFiles, BaseFileWorker.GetPath(pathToFiles + @"\a.pptx"));
            Assert.Equal(pathToFiles, BaseFileWorker.GetPath(@"..\..\..\Files\a.pptx"));
            Assert.Equal(pathToFiles, BaseFileWorker.GetPath(pathToFiles + @"\a.torrent"));
            Assert.Equal(pathToFiles, BaseFileWorker.GetPath(@"..\..\..\Files\a.torrent"));
        }
        [Fact]
        public void MkDirErrorTest()
        {
            Func<Func<string>, int> shouldThrow = (func) =>
            {
                try
                {
                    func();
                }
                catch (Exception e)
                {
                    Assert.Equal(1, 1);
                    return 0;
                };
                Assert.Equal("", "Exception should have been thrown, but it isn't");
                return 1;
            };
            //create empty dir
            shouldThrow(() => BaseFileWorker.MkDir("")); //Assert.Throws<ArgumentException>(() => BaseFileWorker.MkDir(""));// should do the same but doesnt works
            //create dir with invalid path/name
            shouldThrow(() => BaseFileWorker.MkDir(pathToFiles + "\\test:123"));
            shouldThrow(() => BaseFileWorker.MkDir(pathToFiles + "\\test<123"));
            shouldThrow(() => BaseFileWorker.MkDir(pathToFiles + "\\test>123"));
            shouldThrow(() => BaseFileWorker.MkDir(pathToFiles + "\\test*123"));
            shouldThrow(() => BaseFileWorker.MkDir(pathToFiles + "\\test?123"));
            shouldThrow(() => BaseFileWorker.MkDir(pathToFiles + "\\test\"123"));
            shouldThrow(() => BaseFileWorker.MkDir(pathToFiles + "\\test|123"));
            //create dir with forbiden name
            shouldThrow(() => BaseFileWorker.MkDir(pathToFiles + "\\CON"));
            shouldThrow(() => BaseFileWorker.MkDir(pathToFiles + "\\PRN"));
            shouldThrow(() => BaseFileWorker.MkDir(pathToFiles + "\\AUX"));
            shouldThrow(() => BaseFileWorker.MkDir(pathToFiles + "\\NUL"));
            shouldThrow(() => BaseFileWorker.MkDir(pathToFiles + "\\COM1"));
            shouldThrow(() => BaseFileWorker.MkDir(pathToFiles + "\\COM9"));
            shouldThrow(() => BaseFileWorker.MkDir(pathToFiles + "\\LPT1"));
            shouldThrow(() => BaseFileWorker.MkDir(pathToFiles + "\\LPT9"));
        }
        [Fact]
        public void MkDirSuccessTest()
        {
            //create folder
            Assert.Equal(pathToFiles + "\\test", BaseFileWorker.MkDir(pathToFiles + "\\test"));
            Assert.Equal(pathToFiles + "\\test1", BaseFileWorker.MkDir(@"..\..\..\Files\test1"));
            //duplicate folder
            Assert.Equal(pathToFiles + "\\test", BaseFileWorker.MkDir(pathToFiles + "\\test"));
            Assert.Equal(pathToFiles + "\\test1", BaseFileWorker.MkDir(@"..\..\..\Files\test1"));
            //create folder in non-existing folder
            Assert.Equal(pathToFiles + "\\test2\\test4", BaseFileWorker.MkDir(pathToFiles + "\\test2\\test4"));
            Assert.Equal(pathToFiles + "\\test3\\test5", BaseFileWorker.MkDir(@"..\..\..\Files\test3\\test5"));
            //create folder with .(dot)
            Assert.Equal(pathToFiles + "\\test.2", BaseFileWorker.MkDir(pathToFiles + "\\test.2"));
            Assert.Equal(pathToFiles + "\\test.3", BaseFileWorker.MkDir(@"..\..\..\Files\test.3"));
            //create folder with space in name
            Assert.Equal(pathToFiles + "\\test 2", BaseFileWorker.MkDir(pathToFiles + "\\test 2"));
            Assert.Equal(pathToFiles + "\\test 3", BaseFileWorker.MkDir(@"..\..\..\Files\test 3"));
            //create folder with cyrilic
            Assert.Equal(pathToFiles + "\\ййййї", BaseFileWorker.MkDir(pathToFiles + "\\ййййї"));
            Assert.Equal(pathToFiles + "\\ццццї", BaseFileWorker.MkDir(@"..\..\..\Files\ццццї"));
            //create folder with smile
            Assert.Equal(pathToFiles + "\\😴", BaseFileWorker.MkDir(pathToFiles + "\\😴"));
            Assert.Equal(pathToFiles + "\\😴😴", BaseFileWorker.MkDir(@"..\..\..\Files\😴😴"));
            //create folder with ieroglif
            Assert.Equal(pathToFiles + "\\より", BaseFileWorker.MkDir(pathToFiles + "\\より"));
            Assert.Equal(pathToFiles + "\\変更", BaseFileWorker.MkDir(@"..\..\..\Files\変更"));
            //create folder with numbers only
            Assert.Equal(pathToFiles + "\\123", BaseFileWorker.MkDir(pathToFiles + "\\123"));
            Assert.Equal(pathToFiles + "\\456", BaseFileWorker.MkDir(@"..\..\..\Files\456"));

            Directory.Delete(pathToFiles + "\\test", true);
            Directory.Delete(pathToFiles + "\\test1", true);
            Directory.Delete(pathToFiles + "\\test2", true);
            Directory.Delete(pathToFiles + "\\test3", true);
            Directory.Delete(pathToFiles + "\\test.2", true);
            Directory.Delete(pathToFiles + "\\test.3", true);
            Directory.Delete(pathToFiles + "\\test 2", true);
            Directory.Delete(pathToFiles + "\\test 3", true);
            Directory.Delete(pathToFiles + "\\ййййї", true);
            Directory.Delete(pathToFiles + "\\ццццї", true);
            Directory.Delete(pathToFiles + "\\😴", true);
            Directory.Delete(pathToFiles + "\\😴😴", true);
            Directory.Delete(pathToFiles + "\\より", true);
            Directory.Delete(pathToFiles + "\\変更", true);
            Directory.Delete(pathToFiles + "\\123", true);
            Directory.Delete(pathToFiles + "\\456", true);
        }
    }

}
