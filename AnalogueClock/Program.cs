using AnalogueClock;
using AnalogueClock.Enums;

var inputHandler = new InputHandler();
var calculations = new ClockCalculator();

var hours = inputHandler.GetInput(InputType.Hours);
var minutes = inputHandler.GetInput(InputType.Minutes);

var lesserAngle = calculations.CalculateAngle(hours, minutes);

Console.WriteLine(ConsoleMessage.Result, lesserAngle);