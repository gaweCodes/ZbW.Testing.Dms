using System.IO;
using NUnit.Framework;
using FakeItEasy;
using ZbW.Testing.Dms.Client.Exceptions;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.IntegrationTests.Services
{
    [TestFixture]
    internal class FileServiceTests
    {
        private string Source_Path = "source_path";
        private string Target_Path = "target_path";
        [Test]
        public void FileService_CopyDocument_CallsCopyCorrect()
        {
            // Arrange
            var fileService = new FileService();
            var fileTestableMock = A.Fake<FileTestable>();
            fileService.FileTestable = fileTestableMock;

            // Act
            fileService.CopyDocumentToTarget(Source_Path, Target_Path);

            // Assert
            A.CallTo(() => fileTestableMock.Copy(Source_Path, Target_Path, true)).MustHaveHappenedOnceExactly();
        }
        [Test]
        public void FileService_CopyDocumentHandleIOExceptionCorrect_ThrowsException()
        {
            // Arrange
            var fileService = new FileService();
            var fileTestableStub = A.Fake<FileTestable>();
            fileService.FileTestable = fileTestableStub;

            // Act and Assert
            A.CallTo(() => fileTestableStub.Copy(A<string>.Ignored, A<string>.Ignored, A<bool>.Ignored)).Throws<IOException>();
            
            // Act
            void TestDelegate() => fileService.CopyDocumentToTarget(Source_Path, Target_Path);

            // Assert
            Assert.That(TestDelegate, Throws.Exception.TypeOf<CouldNotCopyFileException>());
            Assert.That(TestDelegate, Throws.Exception.InnerException.TypeOf<IOException>());
        }
        [Test]
        public void FileService_CreateFolder_SuccessfulCreated()
        {
            // Arrange
            var fileService = new FileService();
            const string path = "C:/temp/test";

            // Act
            fileService.CreateValutaFolderIfNotExists(path);

            // Assert
            DirectoryAssert.Exists(path);
            Directory.Delete(path);
        }
        [Test]
        public void FileService_RemoveDocument_DeletseDocument()
        {
            // Arrange
            var fileService = new FileService();
            const string path = "C:/temp/testfile.txt";

            // Act
            File.Create(path).Dispose();
            fileService.RemoveDocumentOnSource(path);

            // Assert
            FileAssert.DoesNotExist(path);
        }
    }
}
