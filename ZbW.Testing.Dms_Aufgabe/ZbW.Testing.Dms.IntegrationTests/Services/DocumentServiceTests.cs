using System;
using System.IO;
using System.Linq;
using FakeItEasy;
using NUnit.Framework;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.IntegrationTests.Services
{
    [TestFixture]
    internal class DocumentServiceTests
    {
        [Test]
        public void DocumentService_CanFilterMetadata_HasValue()
        {
            // Arrange
            var documentSerice = new DocumentService {MetadataItems = A.CollectionOfDummy<MetadataItem>(10).ToList()};
            var type = documentSerice.MetadataItems[0].Type;
            var searchParam = documentSerice.MetadataItems[0].Bezeichnung;

            // Act
            var filtered = documentSerice.FilterMetadataItems(type, searchParam);

            // Assert
            Assert.That(filtered, !Is.Empty);
        }

        [Test]
        public void DocumentService_GetAllMetadataItems_HasNoValue()
        {
            // Arrange
            var documentSerice = new DocumentService { MetadataItems = A.CollectionOfDummy<MetadataItem>(10).ToList() };

            // Act
            var all = documentSerice.GetAllMetadataItems();

            // Assert
            Assert.That(all, !Is.Empty);
        }
        [Test]
        public void DocumentServicd_GetAllFolderPaths_HasAny()
        {
            // Arrange
            var documentService = new DocumentService();

            // Act
            var folderPathsCount = documentService.GetAllFolderPaths(@"C:\Users\Gabriel\Desktop\Repo").Count();

            // Assert
            Assert.That(folderPathsCount, Is.GreaterThan(0));
        }
        [Test]
        public void DocumentServicd_AddDocument_DocumentExists()
        {
            // Arrange
            var documentService = new DocumentService();

            // Act
            documentService.AddDocumentToDms(new MetadataItem(DateTime.MinValue, "Test"){FilePath = @"C:/temp/test.txt" });
            var filesCount = Directory.GetFiles(@"C:\Users\Gabriel\Desktop\Repo\1").Length;
            Directory.Delete(@"C:\Users\Gabriel\Desktop\Repo\1", true);

            // Assert
            Assert.That(filesCount, Is.EqualTo(2));
        }
    }
}
