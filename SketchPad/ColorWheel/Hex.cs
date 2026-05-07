namespace ColorWheel;

/// <summary>
/// Represents the hex color code.
/// </summary>
public class Hex
{
    /// <summary>
    /// The full hexcode of this hex, excluding the hashtag
    /// </summary>
    public string HexCode { get; }
    /// <summary>
    /// The red part of the hex
    /// </summary>
    public string RR { get; }
    /// <summary>
    /// The green part of the hex
    /// </summary>
    public string GG { get; }
    /// <summary>
    /// The blue part of the hex
    /// </summary>
    public string BB { get; }

    /// <summary>
    /// Creates a Hex object given a hex code. The hex code must be valid (Within the 000000-FFFFFF range).
    /// If the hex code is incomplete, or too long, it will clamp it to exactly 6 digits, adding 0's if necessary.
    /// </summary>
    /// <param name="hexCode"></param>
    /// <exception cref="ArgumentOutOfRangeException">If the given hex code is not valid.</exception>
    public Hex(string hexCode)
    {
        string trueHexCode = ParseToHexFormat(hexCode);
        string rr = trueHexCode.Substring(0, 2);
        string gg = trueHexCode.Substring(2, 2);
        string bb = trueHexCode.Substring(4, 2);
        if (!CheckValidity(rr) || !CheckValidity(gg) || !CheckValidity(bb))
        {
            throw new ArgumentOutOfRangeException(hexCode);
        }

        HexCode = trueHexCode;
        RR = rr;
        GG = gg;
        BB = bb;
    }

    /// <summary>
    /// A value is valid if it is within the hex range [00,FF]
    /// </summary>
    /// <param name="value">The value to check</param>
    /// <returns>True if the value is within [00, FF], false otherwise</returns>
    private bool CheckValidity(string value)
    {
        string lowercase = value.ToLower();
        if (int.TryParse(lowercase, out _)) return true;
        
        char[] split = lowercase.ToCharArray();
        foreach (char chara in split)
        {
            if (chara > 'f')
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Parses a given string into a hex code format.
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    private string ParseToHexFormat(string input)
    {
        string noHashtag = input.StartsWith('#') ? input.Remove(0, 1) : input;
        string clamped = noHashtag;
        switch (noHashtag.Length)
        {
            case > 6:
                clamped = noHashtag.Substring(0, 6);
                break;
            case < 6:
            {
                for (int i = noHashtag.Length; i < 6; i++)
                {
                    clamped += "0";
                }

                break;
            }
        }

        return clamped;
    }
    
    /// <summary>
    /// Operator overload; reports whether two Hex objects == each other based on
    /// the <see cref="Equals"/> method.
    /// </summary>
    /// <param name="hex1">The first Hex to check equality</param>
    /// <param name="hex2">The second Hex to check equality</param>
    public static bool operator ==(Hex hex1, Hex hex2)
    {
        return hex1.Equals(hex2);
    }

    /// <summary>
    /// Operator overload; reports whether two Hex objects != each other based on
    /// the <see cref="Equals"/> method.
    /// </summary>
    /// <param name="hex1">The first Hex to check equality</param>
    /// <param name="hex2">The second Hex to check equality</param>
    public static bool operator !=(Hex hex1, Hex hex2)
    {
        return !hex1.Equals(hex2);
    }

    /// <summary>
    /// Two Hex objects are equal if their hexcodes are the same.
    /// </summary>
    /// <param name="obj">The object to check for equality</param>
    public override bool Equals(object? obj)
    {
        if (obj is Hex hex)
        {
            return hex.HexCode == HexCode;
        }
        
        return false;
    }

    /// <summary>
    /// Returns the hashcode for this Hex, which is its string form hash.
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return HexCode.GetHashCode();
    }

    /// <summary>
    /// Returns in the format #hexcode
    /// </summary>
    public override string ToString()
    {
        return "#" + HexCode;
    }
}