using FileConverter.Core.Engine;
using FileConverter.Core.Interfaces;
using FileConverter.Plugins.Converters;

var plugins = new List<IFileConverter>
{
    new JsonToCsvConverter(),
    new CsvToJsonConverter(),
    new JsonToXmlConverter(),
};

var engine = new FileConverterEngine(plugins);

Console.Write("Enter input file path: ");
var inputPath = Console.ReadLine();

Console.Write("Enter from format (e.g., json): ");
var fromFormat = Console.ReadLine();

Console.Write("Enter to format (e.g., csv): ");
var toFormat = Console.ReadLine();

if (!File.Exists(inputPath))
{
    Console.WriteLine("❌ File not found.");
    return;
}

var content = File.ReadAllText(inputPath);

try
{
    var output = engine.Convert(content, fromFormat, toFormat);
    var outputPath = Path.Combine(Path.GetDirectoryName(inputPath), "output.txt");
    File.WriteAllText(outputPath, output);

    Console.WriteLine("✅ Conversion complete. Output saved to output.txt");
}
catch (Exception ex)
{
    Console.WriteLine($"❌ Error: {ex.Message}");
}
