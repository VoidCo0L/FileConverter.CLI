using FileConverter.Core.Interfaces;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace FileConverter.Plugins.Converters
{
    public class JsonToYamlConverter : IFileConverter
    {
        public string InputFormat => "json";
        public string OutputFormat => "yaml";

        public string Convert(string inputContent)
        {
            var token = JToken.Parse(inputContent);
            var obj = ConvertJTokenToObject(token);

            var serializer = new SerializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            return serializer.Serialize(obj);
        }

        private object? ConvertJTokenToObject(JToken token)
        {
            switch (token.Type)
            {
                case JTokenType.Object:
                    var dict = new Dictionary<string, object?>();
                    foreach (var prop in token.Children<JProperty>())
                    {
                        dict[prop.Name] = ConvertJTokenToObject(prop.Value);
                    }
                    return dict;

                case JTokenType.Array:
                    var list = new List<object?>();
                    foreach (var item in token.Children())
                    {
                        list.Add(ConvertJTokenToObject(item));
                    }
                    return list;

                case JTokenType.Integer:
                    return token.ToObject<int>();

                case JTokenType.Float:
                    return token.ToObject<double>();

                case JTokenType.String:
                    return token.ToObject<string>();

                case JTokenType.Boolean:
                    return token.ToObject<bool>();

                case JTokenType.Null:
                    return null;

                default:
                    return token.ToString(); // fallback for other types
            }
        }
    }
}
