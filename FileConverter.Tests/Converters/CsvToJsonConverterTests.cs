using FileConverter.Plugins.Converters;
using Xunit;
using System.Text.Json;

namespace FileConverter.Tests.Converters
{
    public class CsvToJsonConverterTests
    {
        [Fact]
        public void Converts_ValidCsv_ToJsonArray()
        {
            // Arrange
            var csv = "name,age\nLaura,30\nMax,25";
            var converter = new CsvToJsonConverter();

            // Act
            var json = converter.Convert(csv);

            // Assert
            var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

            Assert.Equal(JsonValueKind.Array, root.ValueKind);
            Assert.Equal("Laura", root[0].GetProperty("name").GetString());
            Assert.Equal("30", root[0].GetProperty("age").GetString());
            Assert.Equal("Max", root[1].GetProperty("name").GetString());
        }
    }
}
