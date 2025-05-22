using FileConverter.Core.Interfaces;
using System.Text.Json;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace FileConverter.Plugins.Converters
{
    public class JsonToYamlConverter : IFileConverter
    {
        public string InputFormat => "json";
        public string OutputFormat => "yaml";

        public string Convert(string inputContent)
        {
            var jsonObject = JsonSerializer.Deserialize<object>(inputContent);

            var serializer = new SerializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            return serializer.Serialize(jsonObject);
        }
    }
}
