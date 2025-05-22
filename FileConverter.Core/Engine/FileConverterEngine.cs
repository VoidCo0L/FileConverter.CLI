using FileConverter.Core.Interfaces;

namespace FileConverter.Core.Engine
{
    public class FileConverterEngine
    {
        private readonly IEnumerable<IFileConverter> _converters;

        public FileConverterEngine(IEnumerable<IFileConverter> converters)
        {
            _converters = converters;
        }

        public string Convert(string inputContent, string fromFormat, string toFormat)
        {
            var converter = _converters.FirstOrDefault(c =>
                c.InputFormat.Equals(fromFormat, StringComparison.OrdinalIgnoreCase) &&
                c.OutputFormat.Equals(toFormat, StringComparison.OrdinalIgnoreCase));

            if (converter == null)
                throw new Exception($"No converter found for {fromFormat} -> {toFormat}");

            return converter.Convert(inputContent);
        }
    }
}
