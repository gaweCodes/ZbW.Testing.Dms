using System;
using NUnit.Framework;
using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.Dms.UnitTests.ModelTests
{
    [TestFixture]
    internal class MetadataItemTests
    {
        private const string TestingText = "Test Something";
        private readonly DateTime _testDateTime = DateTime.Now;
        [Test]
        public void MetadataItem_Bezeichnung_GetSetTestingText()
        {
            // Arrange
            var metadataItem = new MetadataItem(_testDateTime, TestingText) {Bezeichnung = TestingText};

            // Act
            var name = metadataItem.Bezeichnung;
            var valutaDate = metadataItem.ValutaDatum;
            var type = metadataItem.Type;
            var keyword = metadataItem.Stichwoerter;

            // Assert
            Assert.That(name, Is.EqualTo(TestingText));
            Assert.That(valutaDate, Is.EqualTo(_testDateTime));
            Assert.That(type, Is.EqualTo(TestingText));
            Assert.That(keyword, Is.EqualTo(string.Empty));
        }
        [Test]
        public void MetadataItem_Benutzer_GetSetTestingText()
        {
            // Arrange
            var metadataItem = new MetadataItem(_testDateTime, TestingText) { Benutzer = TestingText};

            // Act
            var username = metadataItem.Benutzer;
            var valutaDate = metadataItem.ValutaDatum;
            var type = metadataItem.Type;
            var keyword = metadataItem.Stichwoerter;

            // Arrange
            Assert.That(username, Is.EqualTo(TestingText));
            Assert.That(valutaDate, Is.EqualTo(_testDateTime));
            Assert.That(type, Is.EqualTo(TestingText));
            Assert.That(keyword, Is.EqualTo(string.Empty));
        }
        [Test]
        public void MetadataItem_FilePath_GetSetTestingText()
        {
            // Arrange
            var metadataItem = new MetadataItem(_testDateTime, TestingText) { FilePath = TestingText};

            // Act
            var filePath = metadataItem.FilePath;
            var valutaDate = metadataItem.ValutaDatum;
            var type = metadataItem.Type;
            var keyword = metadataItem.Stichwoerter;

            // Assert
            Assert.That(filePath, Is.EqualTo(TestingText));
            Assert.That(valutaDate, Is.EqualTo(_testDateTime));
            Assert.That(type, Is.EqualTo(TestingText));
            Assert.That(keyword, Is.EqualTo(string.Empty));
        }
        [Test]
        public void MetadataItem_SetIsRemoveFileEnabled_GetTrue()
        {
            // Arrange
            var metadataItem = new MetadataItem(_testDateTime, TestingText) { IsRemoveFileEnabled = true};

            // Act
            var isRemoveEnabled = metadataItem.IsRemoveFileEnabled;
            var valutaDate = metadataItem.ValutaDatum;
            var type = metadataItem.Type;
            var keyword = metadataItem.Stichwoerter;

            // Assert
            Assert.That(isRemoveEnabled, Is.True);
            Assert.That(valutaDate, Is.EqualTo(_testDateTime));
            Assert.That(type, Is.EqualTo(TestingText));
            Assert.That(keyword, Is.EqualTo(string.Empty));
        }
        [Test]
        public void MetadataItem_SetType_GetTestingText()
        {
            // Arrange
            var metadataItem = new MetadataItem(_testDateTime, TestingText);

            // Act
            var type = metadataItem.Type;
            var valutaDate = metadataItem.ValutaDatum;
            var keyword = metadataItem.Stichwoerter;

            // Assert
            Assert.That(type, Is.EqualTo(TestingText));
            Assert.That(valutaDate, Is.EqualTo(_testDateTime));
            Assert.That(keyword, Is.EqualTo(string.Empty));
        }
        [Test]
        public void MetadateItem_Erfassungsdatum_GetTestDateTime()
        {
            // Arrange
            var metadataItem = new MetadataItem(_testDateTime, TestingText) { Erfassungsdatum = _testDateTime};

            // Act
            var creationDate = metadataItem.Erfassungsdatum;
            var type = metadataItem.Type;
            var valutaDate = metadataItem.ValutaDatum;
            var keyword = metadataItem.Stichwoerter;

            // Assert
            Assert.That(creationDate, Is.EqualTo(_testDateTime));
            Assert.That(valutaDate, Is.EqualTo(_testDateTime));
            Assert.That(type, Is.EqualTo(TestingText));
            Assert.That(keyword, Is.EqualTo(string.Empty));
        }
        [Test]
        public void MetadataItem_SetValutaDatum_GetTestDateTime()
        {
            // Arrange
            var metadataItem = new MetadataItem(_testDateTime, TestingText);

            // Act
            var valutaDate = metadataItem.ValutaDatum;
            var type = metadataItem.Type;
            var keyword = metadataItem.Stichwoerter;

            // Assert
            Assert.That(valutaDate, Is.EqualTo(_testDateTime));
            Assert.That(type, Is.EqualTo(TestingText));
            Assert.That(keyword, Is.EqualTo(string.Empty));
        }
        [Test]
        public void MetadataItem_SetStichwoerter_GetTestingText()
        {
            // Arrange
            var metadataItem = new MetadataItem(_testDateTime, TestingText, TestingText);

            // Act
            var keyword = metadataItem.Stichwoerter;
            var valutaDate = metadataItem.ValutaDatum;
            var type = metadataItem.Type;

            // Assert
            Assert.That(keyword, Is.EqualTo(TestingText));
            Assert.That(valutaDate, Is.EqualTo(_testDateTime));
            Assert.That(type, Is.EqualTo(TestingText));
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
