using FileConverter.Core.Interfaces;
using System.Text.Json;
using System.Xml.Linq;

namespace FileConverter.Plugins.Converters
{
    public class JsonToXmlConverter : IFileConverter
    {
        public string InputFormat => "json";
        public string OutputFormat => "xml";

        public string Convert(string inputContent)
        {
            var rootElement = new XElement("Root");
            var doc = JsonDocument.Parse(inputContent);

            if (doc.RootElement.ValueKind != JsonValueKind.Array)
                throw new Exception("Expected a JSON array");

            foreach (var element in doc.RootElement.EnumerateArray())
            {
                var itemElement = new XElement("Item");
                foreach (var prop in element.EnumerateObject())
                {
                    itemElement.Add(new XElement(prop.Name, prop.Value.ToString()));
                }
                rootElement.Add(itemElement);
            }

            return rootElement.ToString();
        }
    }
}
