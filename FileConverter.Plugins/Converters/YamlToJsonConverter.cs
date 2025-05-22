using FileConverter.Core.Interfaces;
using System.Text.Json;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace FileConverter.Plugins.Converters
{
    public class YamlToJsonConverter : IFileConverter
    {
        public string InputFormat => "yaml";
        public string OutputFormat => "json";

        public string Convert(string inputContent)
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            var yamlObject = deserializer.Deserialize<object>(inputContent);

            return JsonSerializer.Serialize(yamlObject, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
