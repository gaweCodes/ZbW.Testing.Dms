using System;
using NUnit.Framework;
using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.Dms.UnitTests.ModelTests
{
    [TestFixture]
    internal class MetadataItemTests
    {
        private const string TestingText = "Test Something";
        private readonly DateTimeOffset _testDateTime = DateTime.Now;
        [Test]
        public void MetadataItem_Bezeichnung_GetSetTestingText()
        {
            // Arrange
            var metadataItem = new MetadataItem {Bezeichnung = TestingText};

            // Act
            var name = metadataItem.Bezeichnung;

            // Assert
            Assert.That(name, Is.EqualTo(TestingText));
        }
        [Test]
        public void MetadataItem_Benutzer_GetSetTestingText()
        {
            // Arrange
            var metadataItem = new MetadataItem {Benutzer = TestingText};

            // Act
            var username = metadataItem.Benutzer;

            // Arrange
            Assert.That(username, Is.EqualTo(TestingText));
        }
        [Test]
        public void MetadataItem_FilePath_GetSetTestingText()
        {
            // Arrange
            var metadataItem = new MetadataItem {FilePath = TestingText};

            // Act
            var filePath = metadataItem.FilePath;

            // Assert
            Assert.That(filePath, Is.EqualTo(TestingText));
        }
        [Test]
        public void MetadataItem_SetIsRemoveFileEnabled_GetTrue()
        {
            // Arrange
            var metadataItem = new MetadataItem {IsRemoveFileEnabled = true};

            // Act
            var isRemoveEnabled = metadataItem.IsRemoveFileEnabled;

            // Assert
            Assert.That(isRemoveEnabled, Is.True);
        }
        [Test]
        public void MetadataItem_SetType_GetTestingText()
        {
            // Arrange
            var metadataItem = new MetadataItem {Type = TestingText};

            // Act
            var type = metadataItem.Type;

            // Assert
            Assert.That(type, Is.EqualTo(TestingText));
        }
        [Test]
        public void MetadateItem_Erfassungsdatum_GetTestDateTime()
        {
            // Arrange
            var metadataItem = new MetadataItem {Erfassungsdatum = _testDateTime};

            // Act
            var result = metadataItem.Erfassungsdatum;

            // Assert
            Assert.That(result, Is.EqualTo(_testDateTime));
        }
        [Test]
        public void MetadataItem_SetValutaDatum_GetTestDateTime()
        {
            // Arrange
            var metadataItem = new MetadataItem {ValutaDatum = _testDateTime};

            // Act
            var result = metadataItem.ValutaDatum;

            // Assert
            Assert.That(result, Is.EqualTo(_testDateTime));
        }
        [Test]
        public void MetadataItem_SetStichwoerter_GetTestingText()
        {
            // Arrange
            var metadataItem = new MetadataItem {Stichwoerter = TestingText};

            // Act
            var keyword = metadataItem.Stichwoerter;

            // Assert
            Assert.That(keyword, Is.EqualTo(TestingText));
        }
        [Test]
        public void MetadataItem_FullConstructor_GetTestingTextsAndDates()
        {
            // Arrange and Act
            var metadataItem = new MetadataItem(TestingText, _testDateTime, TestingText, false, TestingText, TestingText, _testDateTime, TestingText);

            // Assert
            Assert.That(metadataItem.Benutzer, Is.EqualTo(TestingText));
            Assert.That(metadataItem.Bezeichnung, Is.EqualTo(TestingText));
            Assert.That(metadataItem.Erfassungsdatum, Is.EqualTo(_testDateTime));
            Assert.That(metadataItem.FilePath, Is.EqualTo(TestingText));
            Assert.That(metadataItem.IsRemoveFileEnabled, Is.False);
            Assert.That(metadataItem.Stichwoerter, Is.EqualTo(TestingText));
            Assert.That(metadataItem.Type, Is.EqualTo(TestingText));
            Assert.That(metadataItem.ValutaDatum, Is.EqualTo(_testDateTime));
        }
    }
}
