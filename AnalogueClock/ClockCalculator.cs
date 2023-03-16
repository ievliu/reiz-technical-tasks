using AnalogueClock.Enums;

namespace AnalogueClock;

public interface IClockCalculator
{
    double CalculateAngle(int hours, int minutes);
}

public class ClockCalculator : IClockCalculator
{
    public double CalculateAngle(int hours, int minutes)
    {
        if (hours is < (int)InputRange.Hour.Min or > (int)InputRange.Hour.Max)
            throw new ArgumentOutOfRangeException(nameof(hours));

        if (minutes is < (int)InputRange.Minute.Min or > (int)InputRange.Minute.Max)
            throw new ArgumentOutOfRangeException(nameof(minutes));

        var hourAngle = 0.5 * (hours * 60 + minutes);

        var minuteAngle = 6 * minutes;

        var angleDiff = Math.Abs(hourAngle - minuteAngle);

        return Math.Min(angleDiff, 360 - angleDiff);
    }
}
