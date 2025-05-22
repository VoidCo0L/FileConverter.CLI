using FileConverter.Core.Interfaces;
using System.Xml.Linq;
using System.Text.Json;

namespace FileConverter.Plugins.Converters
{
    public class XmlToJsonConverter : IFileConverter
    {
        public string InputFormat => "xml";
        public string OutputFormat => "json";

        public string Convert(string inputContent)
        {
            var xml = XElement.Parse(inputContent);
            var list = new List<Dictionary<string, string>>();

            foreach (var item in xml.Elements("Item"))
            {
                var dict = new Dictionary<string, string>();
                foreach (var element in item.Elements())
                {
                    dict[element.Name.LocalName] = element.Value;
                }
                list.Add(dict);
            }

            return JsonSerializer.Serialize(list, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
