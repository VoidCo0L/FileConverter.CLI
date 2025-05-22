using FileConverter.Plugins.Converters;
using Xunit;

namespace FileConverter.Tests.Converters
{
    public class JsonToCsvConverterTests
    {
        [Fact]
        public void Converts_ValidJsonArray_ToCsv()
        {
            var json = "[{\"name\":\"Laura\",\"age\":30},{\"name\":\"Max\",\"age\":25}]";
            var converter = new JsonToCsvConverter();

            var result = converter.Convert(json);

            Assert.Contains("name,age", result);
            Assert.Contains("Laura,30", result);
            Assert.Contains("Max,25", result);
        }
    }
}
