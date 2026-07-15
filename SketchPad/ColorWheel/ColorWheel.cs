namespace ColorWheel;

public class ColorWheel
{
    /// <summary>
    /// The RGB form of this color wheel.
    /// </summary>
    public RGB Rgb { get; }
    /// <summary>
    /// The HSV form of this color wheel.
    /// </summary>
    public HSV Hsv { get; }
    /// <summary>
    /// The Hex form of this color wheel.
    /// </summary>
    public Hex Hex { get; }
    
    /// <summary>
    /// Default constructor, initializes all values to 0.
    /// </summary>
    public ColorWheel()
    {
        Hex = new Hex("000000");
        Rgb = new RGB(0, 0, 0);
        Hsv = new HSV(0, 0, 0);
    }

    /// <summary>
    /// Constructs a ColorWheel object using an RGB input.
    /// </summary>
    /// <param name="rgbInput">The RGB object to create the ColorWheel</param>
    public ColorWheel(RGB rgbInput)
    {
        Rgb = rgbInput;
        Hsv = FindHSV(rgbInput);
        Hex = FindHex(rgbInput);
    }
    
    /// <summary>
    /// Constructs a ColorWheel object using an HSV input.
    /// </summary>
    /// <param name="hsvInput">The HSV object to create the ColorWheel</param>
    public ColorWheel(HSV hsvInput)
    {
        Hsv = hsvInput;
        Rgb = FindRGB(hsvInput);
        Hex = FindHex(hsvInput);
    }

    /// <summary>
    /// Constructs a ColorWheel object using an HSV input.
    /// </summary>
    /// <param name="hexInput">The Hex object to create the ColorWheel</param>
    public ColorWheel(Hex hexInput)
    {
        Hex = hexInput;
        Rgb = FindRGB(hexInput);
        Hsv = FindHSV(hexInput);
    }

    /// <summary>
    /// Converts HSV values into RGB values and returns it.
    /// </summary>
    /// <param name="hsvInput">The HSV to convert from</param>
    public RGB FindRGB(HSV hsvInput)
    {
        double sat = hsvInput.Saturation / 100.0;
        double val = hsvInput.Value / 100.0;

        double c = val * sat;
        double x = c * (1 - Math.Abs((hsvInput.Hue / 60.0) % 2 - 1));
        double m = val - c;

        double rPrime = 0;
        double gPrime = 0;
        double bPrime = 0;

        double hue = hsvInput.Hue % 360;
        switch (hue)
        {
            case < 60:
                rPrime = c;
                gPrime = x;
                break;
            case < 120:
                rPrime = x;
                gPrime = c;
                break;
            case < 180:
                gPrime = c;
                bPrime = x;
                break;
            case < 240:
                gPrime = x;
                bPrime = c;
                break;
            case < 300:
                rPrime = x;
                bPrime = c;
                break;
            case <= 360:
                rPrime = c;
                bPrime = x;
                break;
        }

        double red = (rPrime + m) * 255;
        double green = (gPrime + m) * 255;
        double blue = (bPrime + m) * 255;
        
        RGB rgb = new RGB((int) Math.Round(red), (int) Math.Round(green), (int) Math.Round(blue));

        return rgb;
    }
    
    public RGB FindRGB(Hex hexInput)
    {
        // TODO
        return new RGB(0, 0, 0);
    }
    
    /// <summary>
    /// Converts RGB values into HSV values and returns it.
    /// </summary>
    /// <param name="rgbInput">The RGB to convert from</param>
    public HSV FindHSV(RGB rgbInput)
    {
        double red = rgbInput.Red / 255.0;
        double green = rgbInput.Green / 255.0;
        double blue = rgbInput.Blue / 255.0;
        double max = Math.Max(red, Math.Max(green, blue));
        double min = Math.Min(red, Math.Min(green, blue));
        double change = max - min;
        
        double hue = 0;
        if (change != 0)
        {
            // max will always be either red, green, or blue, so equality has no issue
            if (max == red)
            {
                hue = (60 * ((green - blue) / change) + 360) % 360;
            }
            else if (max == green)
            {
                hue = (60 * ((blue - red) / change) + 120) % 360;
            }
            else if (max == blue)
            {
                hue = (60 * ((red - green) / change) + 240) % 360;
            }
        }
        
        double saturation = 0;
        if (max != 0)
        {
            saturation = (change / max) * 100;
        }

        double value = max * 100;
        
        return new HSV((int)Math.Round(hue), (int)Math.Round(saturation), 
            (int)Math.Round(value));
    }
    
    public HSV FindHSV(Hex hexInput)
    {
        // TODO
        return new HSV(0, 0, 0);
    }
    
    /// <summary>
    /// Converts RGB to Hex and returns it.
    /// </summary>
    /// <param name="rgbInput">The RGB to convert from.</param>
    public Hex FindHex(RGB rgbInput)
    {
        (int redChangeBase, int redRemainder) = Math.DivRem(rgbInput.Red, 16);
        (int greenChangeBase, int greenRemainder) = Math.DivRem(rgbInput.Green, 16);
        (int blueChangeBase, int blueRemainder) = Math.DivRem(rgbInput.Blue, 16);

        string red = FixHex(redChangeBase) + FixHex(redRemainder);
        string green = FixHex(greenChangeBase) + FixHex(greenRemainder);
        string blue = FixHex(blueChangeBase) + FixHex(blueRemainder);

        string hex = red + green + blue;
        
        return new Hex(hex);
    }

    /// <summary>
    /// Fixes a hex value to adhere to hex rules (10=A, 11=B, 12=C, 13=D, 14=E, 15=F).
    /// </summary>
    /// <param name="hexDigit">The hex digit to convert from.</param>
    private string FixHex(int hexDigit)
    {
        string[] hexValues = ["A", "B", "C", "D", "E", "F"];
        string stringForm = hexDigit.ToString();
        if (hexDigit > 9)
        {
            stringForm = hexValues[hexDigit % 10];
        }
        return stringForm;
    }
    
    public Hex FindHex(HSV hsvInput)
    {
        // TODO
        return new Hex("0");
    }
}