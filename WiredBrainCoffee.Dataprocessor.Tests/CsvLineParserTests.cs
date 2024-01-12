using WiredBrainCoffee.DataProcessor.Model;
using WiredBrainCoffee.DataProcessor.Parsing;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WiredBrainCoffee.Dataprocessor.Tests
{
    public class CsvLineParserTests
    {
        [Fact]
        public void ShouldParseALine()
        {
            var csvLine = new string[] { "Espresso;10/27/2022 8:01:16 AM" };

            MachineDataItem[] items = CsvLineParser.Parse(csvLine);
            Assert.NotNull(items);
            Assert.Single(items);
            Assert.Equal("Espresso", items[0].CoffeeType);
        }
        [InlineData("Espresso", "Invalid line")]
        [InlineData("Espresso;Invalid date time", "Invalid date time")]
        [Theory]
        public void ShouldThrowExceptionWhenLineInvalid(string csvLine, string message)
        {
            var lines = new string[] { csvLine };

            var exception = Assert.Throws<Exception>(() => CsvLineParser.Parse(lines));

            Assert.Equal(message, exception.Message);
        }

        [Fact]
        public void ShouldSkipEmptyAndNullLines() 
        {
            var csvLine = new string[] { "Espresso;10/27/2022 8:01:16 AM", "" };

            MachineDataItem[] items = CsvLineParser.Parse(csvLine);

            Assert.NotNull(items);
            Assert.Single(items);
        }
    }
}