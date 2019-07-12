using System;
using System.IO;
using NUnit.Framework;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.UnitTests.ServiceTests
{
    [TestFixture]
    internal class FileServiceTests
    {
        [Test]
        public void FileService_NewFileNameContent_GenerateReturnsValidFileName()
        {
            // Arrange
            var fileService = new FileService();
            const string fileExtension = "TestExtension";
            const string fileName = "TestFile";
            var guid = new Guid("3e911311-f1de-4279-9fed-a8a1a270845c");

            // Act
            var result = fileService.GetNewFileName(fileName, fileExtension, guid);

            // Assert
            Assert.That(result, Is.EqualTo($"{guid}_{fileName}.{fileExtension}"));
        }
        [Test]
        public void FileService_CopyFile_FileCopied()
        {
            // Arrange
            var fs = File.Create(@"C:\temp\asdf.txt");
            var name = fs.Name;
            fs.Close();
            var fileService = new FileTestable();

            // Act
            fileService.Copy(fs.Name, @"C:\temp\jkl.txt", true);

            // Assert
            FileAssert.Exists(@"C:\temp\jkl.txt");
        }
    }
}
