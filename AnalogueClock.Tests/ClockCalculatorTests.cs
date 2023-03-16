using FluentAssertions;

namespace AnalogueClock.Tests;

public class ClockCalculatorTests
{
    private readonly IClockCalculator _calculator;

    public ClockCalculatorTests()
    {
        _calculator = new ClockCalculator();
    }

    [Theory]
    [InlineData(12, 0, 0)]
    [InlineData(3, 15, 7.5)]
    [InlineData(6, 30, 15.0)]
    [InlineData(9, 45, 22.5)]
    public void CalculateAngle_Returns_CorrectResult(int hours, int minutes, double expectedAngle)
    {
        // Act
        var result = _calculator.CalculateAngle(hours, minutes);

        // Assert
        result.Should().Be(expectedAngle);
    }

    [Theory]
    [InlineData(-1, 0)]
    public void CalculateAngle_Throws_Exception_For_Hours_Out_Of_Range(int hours, int minutes)
    {
        // Act & Assert
        Action act = () => _calculator.CalculateAngle(hours, minutes);
        act.Should().Throw<ArgumentOutOfRangeException>();
    }
    
    [Theory]
    [InlineData(1, 60)]
    public void CalculateAngle_Throws_Exception_For_Minutes_Out_Of_Range(int hours, int minutes)
    {
        // Act & Assert
        Action act = () => _calculator.CalculateAngle(hours, minutes);
        act.Should().Throw<ArgumentOutOfRangeException>();
    }
}