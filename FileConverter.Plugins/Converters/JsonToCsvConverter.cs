using FileConverter.Core.Interfaces;
using System.Text.Json;
using System.Text;

namespace FileConverter.Plugins.Converters
{
    public class JsonToCsvConverter : IFileConverter
    {
        public string InputFormat => "json";
        public string OutputFormat => "csv";

        public string Convert(string inputContent)
        {
            using var doc = JsonDocument.Parse(inputContent);
            var root = doc.RootElement;

            if (root.ValueKind != JsonValueKind.Array)
                throw new Exception("Expected a JSON array");

            var sb = new StringBuilder();
            var headers = root[0].EnumerateObject().Select(p => p.Name).ToArray();
            sb.AppendLine(string.Join(",", headers));

            foreach (var obj in root.EnumerateArray())
            {
                var values = headers.Select(h => obj.GetProperty(h).ToString());
                sb.AppendLine(string.Join(",", values));
            }

            return sb.ToString();
        }
    }
}
