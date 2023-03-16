using AnalogueClock.Enums;

namespace AnalogueClock;

public interface IInputHandler
{
    int GetInput(InputType inputType);
}

public class InputHandler : IInputHandler
{
    public int GetInput(InputType inputType)
    {
        var minValue = GetMinValueByInputType(inputType);
        var maxValue = GetMaxValueByInputType(inputType);

        Console.Write(ConsoleMessage.Input, inputType.ToString().ToLower(), minValue, maxValue);

        var success = int.TryParse(Console.ReadLine(), out var input);

        var inputIsValid = input >= minValue && input <= maxValue;

        if (success && inputIsValid) return input;

        Console.WriteLine(ConsoleMessage.InvalidInput, minValue, maxValue);

        return GetInput(inputType);
    }

    private static int GetMinValueByInputType(InputType inputType) => inputType switch
    {
        InputType.Hours => (int)InputRange.Hour.Min,
        InputType.Minutes => (int)InputRange.Minute.Min,
        _ => throw new ArgumentException(ConsoleMessage.InvalidInputType),
    };

    private static int GetMaxValueByInputType(InputType inputType) => inputType switch
    {
        InputType.Hours => (int)InputRange.Hour.Max,
        InputType.Minutes => (int)InputRange.Minute.Max,
        _ => throw new ArgumentException(ConsoleMessage.InvalidInputType),
    };
}