using FileConverter.Plugins.Converters;
using FileConverter.Tests.Models;
using Xunit;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using System.Collections.Generic;
using System.Linq;
using System;

namespace FileConverter.Tests.Converters
{
    public class JsonToYamlConverterTests
    {
        [Fact]
        public void Converts_ValidJson_ToYaml()
        {
            // Arrange
            var json = @"
[
  {""name"":""Laura"",""age"":30},
  {""name"":""Max"",""age"":25}
]";
            var converter = new JsonToYamlConverter();

            // Act
            var yaml = converter.Convert(json);

            // Deserialize YAML into List<Dictionary<string, object>>
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .IgnoreUnmatchedProperties()
                .Build();

            var intermediate = deserializer.Deserialize<List<Dictionary<string, object>>>(yaml);

            var result = intermediate.Select(dict => new Person
            {
                Name = dict["name"].ToString(),

                Age = dict["age"] switch
                {
                    int i => i,
                    long l => (int)l,
                    string s => int.Parse(s),
                    IEnumerable<object> list when list.Any() =>
                        list.First() switch
                        {
                            int i => i,
                            long l => (int)l,
                            string s => int.TryParse(s, out var val) ? val : throw new InvalidCastException("Invalid age string in list"),
                            _ => throw new InvalidCastException("Unexpected type inside age list")
                        },
                    IEnumerable<object> _ => throw new InvalidCastException("Age list is empty"),
                    _ => throw new InvalidCastException($"Unexpected age type: {dict["age"]?.GetType().Name}")
                }
            }).ToList();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);

            Assert.Equal("Laura", result[0].Name);
            Assert.Equal(30, result[0].Age);

            Assert.Equal("Max", result[1].Name);
            Assert.Equal(25, result[1].Age);
        }
    }
}
