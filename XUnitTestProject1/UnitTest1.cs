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
            Assert.Equal("a.csc", BaseFileWorker.GetFileName(pathToFiles + @"\a.csc"));
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
            Assert.Equal(pathToFiles + "\\a.csc", BaseFileWorker.GetFullPath(pathToFiles + @"\a.csc"));
            Assert.Equal(pathToFiles + "\\a.csc", BaseFileWorker.GetFullPath(@"..\..\..\Files\a.csc"));
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
            Assert.Null(BaseFileWorker.GetPath(pathToFiles + "\\empty"));
            Assert.Null(BaseFileWorker.GetPath(@"..\..\..\Files\empty"));
            //non-existed file
            Assert.Null(BaseFileWorker.GetPath(pathToFiles + "\\empty\\test.txt"));
            Assert.Null(BaseFileWorker.GetPath(@"..\..\..\Files\empty\test.txt"));
            //file but forgot to type extension
            Assert.Null(BaseFileWorker.GetPath(pathToFiles + "\\test"));
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
            Assert.Equal(pathToFiles, BaseFileWorker.GetPath(pathToFiles + @"\a.csc"));
            Assert.Equal(pathToFiles, BaseFileWorker.GetPath(@"..\..\..\Files\a.csc"));
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

            //create empty dir
            Assert.NotNull(Record.Exception(() => BaseFileWorker.MkDir(""))); //Assert.Throws<ArgumentException>(() => BaseFileWorker.MkDir(""));// should do the same but doesnt works
            //create dir with invalid path/name
            Assert.NotNull(Record.Exception(() => BaseFileWorker.MkDir(pathToFiles + "\\test:123")));
            Assert.NotNull(Record.Exception(() => BaseFileWorker.MkDir(pathToFiles + "\\test<123")));
            Assert.NotNull(Record.Exception(() => BaseFileWorker.MkDir(pathToFiles + "\\test>123")));
            Assert.NotNull(Record.Exception(() => BaseFileWorker.MkDir(pathToFiles + "\\test*123")));
            Assert.NotNull(Record.Exception(() => BaseFileWorker.MkDir(pathToFiles + "\\test?123")));
            Assert.NotNull(Record.Exception(() => BaseFileWorker.MkDir(pathToFiles + "\\test\"123")));
            Assert.NotNull(Record.Exception(() => BaseFileWorker.MkDir(pathToFiles + "\\test|123")));
            //create dir with forbiden name
            Assert.NotNull(Record.Exception(() => BaseFileWorker.MkDir(pathToFiles + "\\CON")));
            Assert.NotNull(Record.Exception(() => BaseFileWorker.MkDir(pathToFiles + "\\PRN")));
            Assert.NotNull(Record.Exception(() => BaseFileWorker.MkDir(pathToFiles + "\\AUX")));
            Assert.NotNull(Record.Exception(() => BaseFileWorker.MkDir(pathToFiles + "\\NUL")));
            Assert.NotNull(Record.Exception(() => BaseFileWorker.MkDir(pathToFiles + "\\COM1")));
            Assert.NotNull(Record.Exception(() => BaseFileWorker.MkDir(pathToFiles + "\\COM9")));
            Assert.NotNull(Record.Exception(() => BaseFileWorker.MkDir(pathToFiles + "\\LPT1")));
            Assert.NotNull(Record.Exception(() => BaseFileWorker.MkDir(pathToFiles + "\\LPT9")));
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
        [Fact]
        void TestReadAllforNull()
        {
            //read from nothing
            Assert.Null(BaseFileWorker.ReadAll(""));
            //read from non-existing file
            Assert.Null(BaseFileWorker.ReadAll(pathToFiles + "//read_all.non_existed"));
        }
        [Fact]
        void TestReadAllValid()
        {
            //read regular
            Assert.Equal("123", BaseFileWorker.ReadAll(pathToFiles + "\\read_all.txt"));
            Assert.Equal("123", BaseFileWorker.ReadAll(@"..\..\..\Files\read_all.txt"));
            //read with \n
            Assert.Equal("I need a hero to save me now\r\nI need a hero (save me now)\r\nI need a hero to save my life\r\nA hero'll save me (just in time)", BaseFileWorker.ReadAll(pathToFiles + "\\text.txt"));
            Assert.Equal("I need a hero to save me now\r\nI need a hero (save me now)\r\nI need a hero to save my life\r\nA hero'll save me (just in time)", BaseFileWorker.ReadAll(@"..\..\..\Files\text.txt"));
            //read from file with non ascii symbols
            Assert.Equal("123", BaseFileWorker.ReadAll(pathToFiles + "\\ції😴り.txt"));
            Assert.Equal("123", BaseFileWorker.ReadAll(@"..\..\..\Files\ції😴り.txt"));
            //read from file with non ascii text
            Assert.Equal("ції😴り.txt", BaseFileWorker.ReadAll(pathToFiles + "\\read_all1.txt"));
            Assert.Equal("ції😴り.txt", BaseFileWorker.ReadAll(@"..\..\..\Files\read_all1.txt"));
            //read from file with few dots in name
            Assert.Equal("123", BaseFileWorker.ReadAll(pathToFiles + "\\1.2.3.txt"));
            Assert.Equal("123", BaseFileWorker.ReadAll(@"..\..\..\Files\1.2.3.txt"));
            //read from file with different file formats
            Assert.Equal("1", BaseFileWorker.ReadAll(pathToFiles + "\\a.csc"));
            Assert.Equal("2", BaseFileWorker.ReadAll(pathToFiles + "\\a.docx"));
            Assert.Equal("3", BaseFileWorker.ReadAll(pathToFiles + "\\a.mp4"));
            Assert.Equal("4", BaseFileWorker.ReadAll(pathToFiles + "\\a.pptx"));
            Assert.Equal("5", BaseFileWorker.ReadAll(pathToFiles + "\\a.torrent"));
        }
        [Fact]
        void TestReadLines()
        {
            //read 1 regular line
            Assert.Equal(new string[] { "123" }, BaseFileWorker.ReadLines(pathToFiles + "\\read_all.txt"));
            Assert.Equal(new string[] { "123" }, BaseFileWorker.ReadLines(@"..\..\..\Files\read_all.txt"));
            //read from file with non ascii symbols
            Assert.Equal(new string[] { "123" }, BaseFileWorker.ReadLines(pathToFiles + "\\ції😴り.txt"));
            Assert.Equal(new string[] { "123" }, BaseFileWorker.ReadLines(@"..\..\..\Files\ції😴り.txt"));
            //read from file with non ascii text
            Assert.Equal(new string[] { "ції😴り.txt" }, BaseFileWorker.ReadLines(pathToFiles + "\\read_all1.txt"));
            Assert.Equal(new string[] { "ції😴り.txt" }, BaseFileWorker.ReadLines(@"..\..\..\Files\read_all1.txt"));
            //read from file with few dots in name
            Assert.Equal(new string[] { "123" }, BaseFileWorker.ReadLines(pathToFiles + "\\1.2.3.txt"));
            Assert.Equal(new string[] { "123" }, BaseFileWorker.ReadLines(@"..\..\..\Files\1.2.3.txt"));
            //read from file with different file formats
            Assert.Equal(new string[] { "1" }, BaseFileWorker.ReadLines(pathToFiles + "\\a.csc"));
            Assert.Equal(new string[] { "2" }, BaseFileWorker.ReadLines(pathToFiles + "\\a.docx"));
            Assert.Equal(new string[] { "3" }, BaseFileWorker.ReadLines(pathToFiles + "\\a.mp4"));
            Assert.Equal(new string[] { "4" }, BaseFileWorker.ReadLines(pathToFiles + "\\a.pptx"));
            Assert.Equal(new string[] { "5" }, BaseFileWorker.ReadLines(pathToFiles + "\\a.torrent"));
            //read polyline file
            string[] expected =
            {
                "I need a hero to save me now",
                "I need a hero (save me now)",
                "I need a hero to save my life",
                "A hero'll save me (just in time)"
            };
            Assert.Equal(expected, BaseFileWorker.ReadLines(pathToFiles + "\\text.txt"));
            Assert.Equal(expected, BaseFileWorker.ReadLines(@"..\..\..\Files\text.txt"));
        }
        [Fact]
        void TestTryCopyFails()
        {
            //try copy from empty
            Assert.False(BaseFileWorker.TryCopy("", @"..\..\..\Files\trycopyfalse.txt", true));
            Assert.False(BaseFileWorker.TryCopy("", pathToFiles + "\\trycopyfalse.txt", true));

            //try copy from non-existing file

            Assert.NotNull(Record.Exception(() => BaseFileWorker.TryCopy(@"..\..\..\Files\empty\trycopyfalse.txt", @"..\..\..\Files\trycopyfalse.txt", false, 2)));
            Assert.NotNull(Record.Exception(() => BaseFileWorker.TryCopy(pathToFiles + "\\empty\\trycopyfalse.txt", pathToFiles + "\\trycopyfalse.txt", false, 2)));
            Assert.NotNull(Record.Exception(() => BaseFileWorker.TryCopy(@"..\..\..\Files\empty\trycopyfalse.txt", @"..\..\..\Files\trycopyfalse.txt", true, 2)));
            Assert.NotNull(Record.Exception(() => BaseFileWorker.TryCopy(pathToFiles + "\\empty\\trycopyfalse.txt", pathToFiles + "\\trycopyfalse.txt", true, 2)));

            //try to copy and paste into the same file
            Assert.NotNull(Record.Exception(() => BaseFileWorker.TryCopy(@"..\..\..\Files\copy_from.txt", @"..\..\..\Files\copy_from.txt", true, 2)));
            Assert.NotNull(Record.Exception(() => BaseFileWorker.TryCopy(pathToFiles + "\\copy_from.txt", pathToFiles + "\\copy_from.txt", true, 2)));
            Assert.NotNull(Record.Exception(() => BaseFileWorker.TryCopy(@"..\..\..\Files\copy_from.txt", @"..\..\..\Files\copy_from.txt", false, 2)));
            Assert.NotNull(Record.Exception(() => BaseFileWorker.TryCopy(pathToFiles + "\\copy_from.txt", pathToFiles + "\\copy_from.txt", false, 2)));

            //try to copy to the existing file with disabled rewrite option
            Assert.NotNull(Record.Exception(() => BaseFileWorker.TryCopy(@"..\..\..\Files\copy_from.txt", @"..\..\..\Files\exist.txt", false, 2)));
            Assert.NotNull(Record.Exception(() => BaseFileWorker.TryCopy(pathToFiles + "\\copy_from.txt", pathToFiles + "\\exist.txt", false, 2)));
        }
        [Fact]
        void TestTryCopy()
        {
            //test with no file extension
            Assert.True(BaseFileWorker.TryCopy(@"..\..\..\Files\IIG", @"..\..\..\Files\copy_to.txt", true, 2));
            Assert.True(BaseFileWorker.TryCopy(pathToFiles + "\\IIG", pathToFiles + "\\copy_to.txt", true, 2));
            Assert.False(BaseFileWorker.TryCopy(@"..\..\..\Files\IIG", @"..\..\..\Files\copy_to.txt", true, 0));
            Assert.False(BaseFileWorker.TryCopy(pathToFiles + "\\IIG", pathToFiles + "\\copy_to.txt", true, 0));
            Assert.False(BaseFileWorker.TryCopy(@"..\..\..\Files\IIG", @"..\..\..\Files\copy_to.txt", true, -1));
            Assert.False(BaseFileWorker.TryCopy(pathToFiles + "\\IIG", pathToFiles + "\\copy_to.txt", true, -1));
            File.Delete(pathToFiles + "\\copy_to.txt");

            //test copy with non-latin name
            Assert.True(BaseFileWorker.TryCopy(@"..\..\..\Files\ції😴り.txt", @"..\..\..\Files\ції😴り.txt1", true, 2));
            Assert.True(BaseFileWorker.TryCopy(pathToFiles + "\\ції😴り.txt", pathToFiles + "\\ції😴り.txt1", true, 2));
            Assert.False(BaseFileWorker.TryCopy(@"..\..\..\Files\ції😴り.txt", @"..\..\..\Files\ції😴り.txt1", true, 0));
            Assert.False(BaseFileWorker.TryCopy(pathToFiles + "\\ції😴り.txt", pathToFiles + "\\ції😴り.txt1", true, 0));
            Assert.False(BaseFileWorker.TryCopy(@"..\..\..\Files\ції😴り.txt", @"..\..\..\Files\ції😴り.txt1", true, -1));
            Assert.False(BaseFileWorker.TryCopy(pathToFiles + "\\ції😴り.txt", pathToFiles + "\\ції😴り.txt1", true, -1));
            File.Delete(pathToFiles + "\\ції😴り.txt1");

            //test copy with few dots in name name
            Assert.True(BaseFileWorker.TryCopy(@"..\..\..\Files\1.2.3.txt", @"..\..\..\Files\1.2.34.txt1", true, 2));
            Assert.True(BaseFileWorker.TryCopy(pathToFiles + "\\1.2.3.txt", pathToFiles + "\\1.2.34.txt1", true, 2));
            Assert.False(BaseFileWorker.TryCopy(@"..\..\..\Files\1.2.3.txt", @"..\..\..\Files\1.2.34.txt1", true, 0));
            Assert.False(BaseFileWorker.TryCopy(pathToFiles + "\\1.2.3.txt", pathToFiles + "\\1.2.34.txt1", true, 0));
            Assert.False(BaseFileWorker.TryCopy(@"..\..\..\Files\1.2.3.txt", @"..\..\..\Files\1.2.34.txt1", true, -1));
            Assert.False(BaseFileWorker.TryCopy(pathToFiles + "\\1.2.3.txt", pathToFiles + "\\1.2.34.txt1", true, -1));
            File.Delete(pathToFiles + "\\1.2.34.txt1");
        }
        [Fact]
        void TestTryWriteFail()
        {
            //try write to empty
            Assert.False(BaseFileWorker.TryWrite("", @"", -1));
            Assert.False(BaseFileWorker.TryWrite("", @"", 0));
            Assert.False(BaseFileWorker.TryWrite("", @"", 2));

        }
        [Fact]
        void TestTryWrite()
        {
            //test with no file extension
            Assert.True(BaseFileWorker.TryWrite(@"..\..\..\Files\IIG", @"..\..\..\Files\copy_to.txt", 2));
            Assert.True(BaseFileWorker.TryWrite(pathToFiles + "\\IIG", pathToFiles + "\\copy_to.txt", 2));
            Assert.False(BaseFileWorker.TryWrite(@"..\..\..\Files\IIG", @"..\..\..\Files\copy_to.txt", 0));
            Assert.False(BaseFileWorker.TryWrite(pathToFiles + "\\IIG", pathToFiles + "\\copy_to.txt", 0));
            Assert.False(BaseFileWorker.TryWrite(@"..\..\..\Files\IIG", @"..\..\..\Files\copy_to.txt", -1));
            Assert.False(BaseFileWorker.TryWrite(pathToFiles + "\\IIG", pathToFiles + "\\copy_to.txt", -1));
            File.Delete(pathToFiles + "\\copy_to.txt");

            //test copy with non-latin name
            Assert.True(BaseFileWorker.TryWrite(@"..\..\..\Files\ції😴り.txt", @"..\..\..\Files\ції😴り.txt1", 2));
            Assert.True(BaseFileWorker.TryWrite(pathToFiles + "\\ції😴り.txt", pathToFiles + "\\ції😴り.txt1", 2));
            Assert.False(BaseFileWorker.TryWrite(@"..\..\..\Files\ції😴り.txt", @"..\..\..\Files\ції😴り.txt1", 0));
            Assert.False(BaseFileWorker.TryWrite(pathToFiles + "\\ції😴り.txt", pathToFiles + "\\ції😴り.txt1", 0));
            Assert.False(BaseFileWorker.TryWrite(@"..\..\..\Files\ції😴り.txt", @"..\..\..\Files\ції😴り.txt1", -1));
            Assert.False(BaseFileWorker.TryWrite(pathToFiles + "\\ції😴り.txt", pathToFiles + "\\ції😴り.txt1", -1));
            File.Delete(pathToFiles + "\\ції😴り.txt1");

            //test copy with few dots in name name
            Assert.True(BaseFileWorker.TryWrite(@"..\..\..\Files\1.2.3.txt", @"..\..\..\Files\1.2.34.txt1", 2));
            Assert.True(BaseFileWorker.TryWrite(pathToFiles + "\\1.2.3.txt", pathToFiles + "\\1.2.34.txt1", 2));
            Assert.False(BaseFileWorker.TryWrite(@"..\..\..\Files\1.2.3.txt", @"..\..\..\Files\1.2.34.txt1", 0));
            Assert.False(BaseFileWorker.TryWrite(pathToFiles + "\\1.2.3.txt", pathToFiles + "\\1.2.34.txt1", 0));
            Assert.False(BaseFileWorker.TryWrite(@"..\..\..\Files\1.2.3.txt", @"..\..\..\Files\1.2.34.txt1", -1));
            Assert.False(BaseFileWorker.TryWrite(pathToFiles + "\\1.2.3.txt", pathToFiles + "\\1.2.34.txt1", -1));
            File.Delete(pathToFiles + "\\1.2.34.txt1");
        }
        [Fact]
        void TestWrite()
        {
            //write to file without file
            Assert.False(BaseFileWorker.Write("123", ""));

            //write to file with no extension
            Assert.True(BaseFileWorker.Write("123", pathToFiles + "\\copy_to"));
            Assert.True(BaseFileWorker.Write("123", @"..\..\..\Files\to_copy"));

            //write to existing file
            Assert.True(BaseFileWorker.Write("1234", pathToFiles + "\\copy_to"));
            Assert.True(BaseFileWorker.Write("1234", @"..\..\..\Files\to_copy"));
            File.Delete(pathToFiles + "\\copy_to");
            File.Delete(pathToFiles + "\\to_copy");

            
            //write to file empty text
            Assert.True(BaseFileWorker.Write("", pathToFiles + "\\copy_to"));
            Assert.True(BaseFileWorker.Write("", @"..\..\..\Files\to_copy"));
            File.Delete(pathToFiles + "\\copy_to");
            File.Delete(pathToFiles + "\\to_copy");

            //write to file in non-existing folder
            Assert.False(BaseFileWorker.Write("1", pathToFiles + "\\image\\copy_to"));
            Assert.False(BaseFileWorker.Write("1", @"..\..\..\Files\image\to_copy"));

            Assert.NotNull(Record.Exception(() => Directory.Delete(pathToFiles + "\\image", true)));
            Assert.NotNull(Record.Exception(() => Directory.Delete(pathToFiles + "\\image", true)));
            //write to file with non ASCII
            Assert.True(BaseFileWorker.Write("ції😴り", pathToFiles + "\\ції😴り.temp"));
            Assert.True(BaseFileWorker.Write("ції😴り", @"..\..\..\Files\ції😴り1.temp"));
            File.Delete(pathToFiles + "\\ції😴り.temp");
            File.Delete(pathToFiles + "\\ції😴り1.temp");

        }
    }

}
