using FileConverter.Core.Interfaces;
using System.Text.Json;

namespace FileConverter.Plugins.Converters
{
    public class CsvToJsonConverter : IFileConverter
    {
        public string InputFormat => "csv";
        public string OutputFormat => "json";

        public string Convert(string inputContent)
        {
            var lines = inputContent.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            if (lines.Length < 2) throw new Exception("CSV must have headers and at least one row.");

            var headers = lines[0].Split(',');

            var list = new List<Dictionary<string, string>>();

            for (int i = 1; i < lines.Length; i++)
            {
                var row = lines[i].Split(',');
                var dict = new Dictionary<string, string>();

                for (int j = 0; j < headers.Length && j < row.Length; j++)
                {
                    dict[headers[j].Trim()] = row[j].Trim();
                }

                list.Add(dict);
            }

            return JsonSerializer.Serialize(list, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
