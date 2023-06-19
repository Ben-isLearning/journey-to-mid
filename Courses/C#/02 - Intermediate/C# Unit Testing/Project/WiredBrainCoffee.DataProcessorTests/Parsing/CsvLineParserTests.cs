using NuGet.Frameworks;

namespace WiredBrainCoffee.DataProcessor.Parsing;

public class CsvLineParserTests
{
    [Fact]
    public void ShouldParseValidLine()
    {
        //Arrange
        string[] scvLines = new[] { "Cappuccino;10/27/2022 8:06:04 AM" };

        //Act
        var machineDataItems = CsvLineParser.Parse(scvLines);

        //Assert
        Assert.NotNull(machineDataItems);
        Assert.Single(machineDataItems);
        Assert.Equal("Cappuccino", machineDataItems[0].CoffeeType);
        Assert.Equal(new DateTime(2022, 10, 27, 8, 6, 4), machineDataItems[0].CreatedAt);

    }

    [Fact]
    public void ShouldSkipEmptyLines()
    {
        //Arrange
        string[] scvLines = new[] { "", " " };

        //Act
        var machineDataItems = CsvLineParser.Parse(scvLines);

        //Assert
        Assert.NotNull(machineDataItems);
        Assert.Empty(machineDataItems);

    }

    [InlineData("Cappuchino", "Invalid csv line")]
    [InlineData("Cappuchino;InvalidDateTime", "Invalid datetime in csv line")]

    [Theory]
    public void ShouldThrowExceptionForInvalidLine(string csvLine, string expectedMessagePrefix)
    {
        //Arrange
        var csvLines = new[] { csvLine };

        //Act &
        //Assert
        var exception = Assert.Throws<Exception>(() => CsvLineParser.Parse(csvLines));

        Assert.Equal($"{expectedMessagePrefix}: {csvLine}", exception.Message);

    }

}
