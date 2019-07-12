using System.IO;
using System.Xml;
using System.Xml.Serialization;
using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.Dms.Client.Services
{
    public class XmlService
    {
        public string SeralizeMetadataItem(MetadataItem metadataItem)
        {
            var xmlserializer = new XmlSerializer(typeof(MetadataItem));
            var stringWriter = new StringWriter();
            var writer = XmlWriter.Create(stringWriter);

            xmlserializer.Serialize(writer, metadataItem);
            var serializeXml = stringWriter.ToString();
            writer.Close();
            return serializeXml;
        }
        public MetadataItem DeseralizeMetadataItem(string path)
        {
            var serializer = new XmlSerializer(typeof(MetadataItem));
            var reader = new StreamReader(path);
            var metadataItem = (MetadataItem)serializer.Deserialize(reader);
            reader.Close();
            return metadataItem;
        }

        public void SaveXml(string serializeXml, string path)
        {
            var xdoc = new XmlDocument();
            xdoc.LoadXml(serializeXml);
            xdoc.Save(path);
        }
    }
}
