using FileConverter.Plugins.Converters;
using Xunit;
using System.Xml.Linq;

namespace FileConverter.Tests.Converters
{
    public class JsonToXmlConverterTests
    {
        [Fact]
        public void Converts_JsonArray_ToXml()
        {
            // Arrange
            var json = "[{\"name\":\"Laura\",\"age\":30},{\"name\":\"Max\",\"age\":25}]";
            var converter = new JsonToXmlConverter();

            // Act
            var xmlString = converter.Convert(json);

            // Assert
            var xml = XElement.Parse(xmlString);
            var items = xml.Elements("Item").ToList();

            Assert.Equal(2, items.Count);
            Assert.Equal("Laura", items[0].Element("name")?.Value);
            Assert.Equal("30", items[0].Element("age")?.Value);
            Assert.Equal("Max", items[1].Element("name")?.Value);
        }
    }
}
