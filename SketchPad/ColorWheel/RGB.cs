namespace ColorWheel;

/// <summary>
/// Represents the RGB color code.
/// </summary>
public class RGB
{
    /// <summary>
    /// The red value [0-255]
    /// </summary>
    public int Red { get; }
    /// <summary>
    /// The green value [0-255]
    /// </summary>
    public int Green { get; }
    /// <summary>
    /// The blue value [0-255]
    /// </summary>
    public int Blue { get; }
    
    /// <summary>
    /// Creates a new RGB object given a red, green, and blue value. These values are restricted to the range [0-255].
    /// Values outside the range will be clamped mod 255.
    /// </summary>
    /// <param name="red">The red value</param>
    /// <param name="green">The green value</param>
    /// <param name="blue">The blue value</param>
    public RGB(int red, int green, int blue)
    {
        int trueRed = Clamp(red);
        int trueGreen = Clamp(green);
        int trueBlue = Clamp(blue);
        Red = trueRed;
        Green = trueGreen;
        Blue = trueBlue;
    }

    /// <summary>
    /// Clamps a value to stay in the range [0-255] using modular arithmetic.
    /// </summary>
    /// <param name="value">The value to clamp</param>
    /// <returns>Either the original value, or the value after it was clamped</returns>
    private static int Clamp(int value)
    {
        if (value is > 255 or < 0)
        {
            return (value % 255 + 255) % 255;
        }

        return value;
    }

    /// <summary>
    /// Operator overload; reports whether two RGB objects == each other based on
    /// the <see cref="Equals"/> method.
    /// </summary>
    /// <param name="rgb1">The first RGB to check equality</param>
    /// <param name="rgb2">The second RGB to check equality</param>
    public static bool operator ==(RGB rgb1, RGB rgb2)
    {
        return rgb1.Equals(rgb2);
    }

    /// <summary>
    /// Operator overload; reports whether two RGB objects != each other based on
    /// the <see cref="Equals"/> method.
    /// </summary>
    /// <param name="rgb1">The first RGB to check equality</param>
    /// <param name="rgb2">The second RGB to check equality</param>
    public static bool operator !=(RGB rgb1, RGB rgb2)
    {
        return !rgb1.Equals(rgb2);
    }

    /// <summary>
    /// Two RGB objects are equal to each other if their red, green, and blue values
    /// respectively equal each other.
    /// </summary>
    /// <param name="obj">The object to check for equality</param>
    public override bool Equals(object? obj)
    {
        if (obj is RGB rgb)
        {
            return rgb.Red == Red && rgb.Green == Green && rgb.Blue == Blue;
        }

        return false;
    }

    /// <summary>
    /// Returns the hashcode of this RGB, which is its string form hash.
    /// </summary>
    public override int GetHashCode()
    {
        return ToString().GetHashCode();
    }

    /// <summary>
    /// Prints in the format (red, green, blue), where red, green, and blue are all
    /// between 0 and 255.
    /// </summary>
    public override string ToString()
    {
        return $"({Red}, {Green}, {Blue})";
    }
}