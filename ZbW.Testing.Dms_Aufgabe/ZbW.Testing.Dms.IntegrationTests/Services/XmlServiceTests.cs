using System;
using System.IO;
using NUnit.Framework;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.IntegrationTests.Services
{
    [TestFixture]
    internal class XmlServiceTests
    {
        [Test]
        public void XmlService_Serialize_SerializedString()
        {
            // Arrange
            var xmlService = new XmlService();

            // Act
            const string expectedXml = "<?xml version=\"1.0\" encoding=\"utf-16\"?><MetadataItem xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"><Stichwoerter /><Erfassungsdatum>0001-01-01T00:00:00</Erfassungsdatum><IsRemoveFileEnabled>false</IsRemoveFileEnabled><Type>Test</Type><ValutaDatum>0001-01-01T00:00:00</ValutaDatum></MetadataItem>";
            var xml = xmlService.SeralizeMetadataItem(new MetadataItem(DateTime.MinValue, "Test"));

            // Assert
            Assert.That(xml, Is.EqualTo(expectedXml));
        }
        [Test]
        public void XmlService_Deserialize_MetadataItem()
        {
            // Arrange
            var xmlService = new XmlService();
            var fs = File.Create("text.txt");
            const string expectedXml = "<?xml version=\"1.0\" encoding=\"utf-16\"?><MetadataItem xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"><Stichwoerter /><Erfassungsdatum>0001-01-01T00:00:00</Erfassungsdatum><IsRemoveFileEnabled>false</IsRemoveFileEnabled><Type>Test</Type><ValutaDatum>0001-01-01T00:00:00</ValutaDatum></MetadataItem>";
            fs.Close();
            File.WriteAllText(fs.Name, expectedXml);

            // Act
            var deserializedObject = xmlService.DeseralizeMetadataItem(fs.Name);
            var expectedResult = new MetadataItem(DateTime.MinValue, "Test");

            // Assert
            Assert.That(deserializedObject.ValutaDatum, Is.EqualTo(expectedResult.ValutaDatum));
            Assert.That(deserializedObject.Type, Is.EqualTo(expectedResult.Type));
        }
        [Test]
        public void XmlService_SaveXml_Saved()
        {
            // Arrange
            var xmlService = new XmlService();
            const string expectedXml = "<?xml version=\"1.0\" encoding=\"utf-16\"?><MetadataItem xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"><Stichwoerter /><Erfassungsdatum>0001-01-01T00:00:00</Erfassungsdatum><IsRemoveFileEnabled>false</IsRemoveFileEnabled><Type>Test</Type><ValutaDatum>0001-01-01T00:00:00</ValutaDatum></MetadataItem>";

            // Act
            xmlService.SaveXml(expectedXml, "text.txt");

            // Arrange
            FileAssert.Exists("text.txt");
        }
    }
}
