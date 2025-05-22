using FileConverter.Plugins.Converters;
using Xunit;
using System.Text.Json;

namespace FileConverter.Tests.Converters
{
    public class YamlToJsonConverterTests
    {
        [Fact]
        public void Converts_ValidYaml_ToJson()
        {
            // Arrange
            var yaml = @"
- name: Laura
  age: 30
- name: Max
  age: 25
";
            var converter = new YamlToJsonConverter();

            // Act
            var json = converter.Convert(yaml);

            // Deserialize to actual objects for precise checking
            var people = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(json);

            // Assert
            Assert.NotNull(people);
            Assert.Equal(2, people.Count);

            Assert.Equal("Laura", people[0]["name"].ToString());
            Assert.Equal("30", people[0]["age"].ToString());

            Assert.Equal("Max", people[1]["name"].ToString());
            Assert.Equal("25", people[1]["age"].ToString());
        }
    }
}
