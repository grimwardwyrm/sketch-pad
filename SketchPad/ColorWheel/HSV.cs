namespace ColorWheel;

/// <summary>
/// Represents the HSV color code.
/// </summary>
public class HSV
{
    /// <summary>
    /// The hue [0-360]
    /// </summary>
    public int Hue { get; }
    /// <summary>
    /// The saturation [0-100]
    /// </summary>
    public int Saturation { get; }
    /// <summary>
    /// The value [0-100]
    /// </summary>
    public int Value { get; }

    /// <summary>
    /// Creates a new HSV object given a hue, saturation, and value. Hue is restricted to the range [0-360]
    /// (degrees of a circle), while saturation and value are restricted to the range [0-100] (percentage).
    /// Any value outside these ranges will be clamped mod their right end point.
    /// </summary>
    /// <param name="hue">The hue</param>
    /// <param name="saturation">The saturation</param>
    /// <param name="value">The value</param>
    public HSV(int hue, int saturation, int value)
    {
        int trueHue = Clamp(hue, 360);
        int trueSaturation = Clamp(saturation, 100);
        int trueValue = Clamp(value, 100);
        Hue = trueHue;
        Saturation = trueSaturation;
        Value = trueValue;
    }

    /// <summary>
    /// Clamps a value to the range [0-clamp] using modular arithmetic.
    /// </summary>
    /// <param name="value">The value to clamp</param>
    /// <param name="clamp">The max the value can be</param>
    /// <returns>Either the original value, or the value after it was clamped</returns>
    private static int Clamp(int value, int clamp)
    {
        if (value > clamp || value < 0)
        {
            return (value % clamp + clamp) % clamp;
        }

        return value;
    }
    
    /// <summary>
    /// Operator overload; reports whether two HSV objects == each other based on
    /// the <see cref="Equals"/> method.
    /// </summary>
    /// <param name="hsv1">The first HSV to check equality</param>
    /// <param name="hsv2">The second HSV to check equality</param>
    public static bool operator ==(HSV hsv1, HSV hsv2)
    {
        return hsv1.Equals(hsv2);
    }

    /// <summary>
    /// Operator overload; reports whether two HSV objects != each other based on
    /// the <see cref="Equals"/> method.
    /// </summary>
    /// <param name="hsv1">The first HSV to check equality</param>
    /// <param name="hsv2">The second HSV to check equality</param>
    public static bool operator !=(HSV hsv1, HSV hsv2)
    {
        return !hsv1.Equals(hsv2);
    }

    /// <summary>
    /// Two HSV objects are equal to each other if their hue, saturation, and value values
    /// respectively equal each other.
    /// </summary>
    /// <param name="obj">The object to check for equality</param>
    public override bool Equals(object? obj)
    {
        if (obj is HSV hsv)
        {
            return hsv.Hue == Hue && hsv.Saturation == Saturation && hsv.Value == Value;
        }

        return false;
    }

    /// <summary>
    /// Returns the hashcode of this HSV, which is its string form.
    /// </summary>
    public override int GetHashCode()
    {
        return ToString().GetHashCode();
    }

    /// <summary>
    /// Prints in the format (hue deg, saturation%, value%), where hue is between 0 and 360, and saturation
    /// and value are between 0 and 100 (percent).
    /// </summary>
    public override string ToString()
    {
        return $"({Hue}deg, {Saturation}%, {Value}%)";
    }
}