using FileConverter.Plugins.Converters;
using Xunit;
using System.Xml.Linq;

namespace FileConverter.Tests.Converters
{
    public class XmlToJsonConverterTests
    {
        [Fact]
        public void Converts_ValidXml_ToJsonArray()
        {
            // Arrange
            var xml = @"
                <Root>
                    <Item><name>Laura</name><age>30</age></Item>
                    <Item><name>Max</name><age>25</age></Item>
                </Root>";

            var converter = new XmlToJsonConverter();

            // Act
            var json = converter.Convert(xml);

            // Assert
            Assert.Contains("\"name\": \"Laura\"", json);
            Assert.Contains("\"age\": \"30\"", json);
            Assert.Contains("\"name\": \"Max\"", json);
            Assert.Contains("\"age\": \"25\"", json);
        }
    }
}
