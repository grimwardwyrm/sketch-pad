using ColorWheel;

namespace ColorWheelTests;

/// <summary>
/// Unit tests for the ColorWheel class.
/// </summary>
[TestClass]
public sealed class ColorWheelTests
{
    [TestMethod]
    public void ColorWheelDefault_SetsDefaultValues_RGBToZero()
    {
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel();
        RGB rgb = new RGB(0, 0, 0);
        Assert.IsTrue(cw.Rgb == rgb);
    }
    
    [TestMethod]
    public void ColorWheelDefault_SetsDefaultValues_HSVToZero()
    {
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel();
        HSV hsv = new HSV(0, 0, 0);
        Assert.IsTrue(cw.Hsv == hsv);
    }
    
    [TestMethod]
    public void ColorWheelDefault_SetsDefaultValues_HexToZero()
    {
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel();
        Hex hex = new Hex("000000");
        Assert.IsTrue(cw.Hex == hex);
    }

    [TestMethod]
    public void ColorWheelRGB_SetsRGB_CorrectValue()
    {
        RGB rgb = new RGB(1, 2, 3);
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel(rgb);
        Assert.IsTrue(cw.Rgb == rgb);
    }
    
    [TestMethod]
    public void ColorWheelRGB_SetsHSV_CorrectValue()
    {
        RGB rgb = new RGB(1, 2, 3);
        HSV hsv = new HSV(210, 67, 1);
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel(rgb);
        Assert.IsTrue(cw.Hsv == hsv);
    }
    
    [TestMethod]
    public void ColorWheelRGB_SetsHex_CorrectValue()
    {
        RGB rgb = new RGB(1, 2, 3);
        Hex hex = new Hex("010203");
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel(rgb);
        Assert.IsTrue(cw.Hex == hex);
    }
    
    [TestMethod]
    public void ColorWheelHSV_SetsRGB_CorrectValue()
    {
        HSV hsv = new HSV(210, 67, 1);
        RGB rgb = new RGB(1, 2, 3);
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel(hsv);
        Assert.IsTrue(cw.Rgb == rgb);
    }
    
    [TestMethod]
    public void ColorWheelHSV_SetsHSV_CorrectValue()
    {
        HSV hsv = new HSV(210, 67, 1);
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel(hsv);
        Assert.IsTrue(cw.Hsv == hsv);
    }
    
    [TestMethod]
    public void ColorWheelHSV_SetsHex_CorrectValue()
    {
        HSV hsv = new HSV(210, 67, 1);
        Hex hex = new Hex("010203");
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel(hsv);
        Assert.IsTrue(cw.Hex == hex);
    }
    
    [TestMethod]
    public void ColorWheelHex_SetsRGB_CorrectValue()
    {
        Hex hex = new Hex("010203");
        RGB rgb = new RGB(1, 2, 3);
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel(hex);
        Assert.IsTrue(cw.Rgb == rgb);
    }
    
    [TestMethod]
    public void ColorWheelHex_SetsHSV_CorrectValue()
    {
        Hex hex = new Hex("010203");
        HSV hsv = new HSV(210, 67, 1);
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel(hex);
        Assert.IsTrue(cw.Hsv == hsv);
    }
    
    [TestMethod]
    public void ColorWheelHex_SetsHex_CorrectValue()
    {
        Hex hex = new Hex("010203");
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel(hex);
        Assert.IsTrue(cw.Hex == hex);
    }
    
    [TestMethod]
    public void findRGB_HexToRGBZeros_FindsCorrectValue()
    {
        RGB expected = new RGB(0, 0,0);
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel();
        RGB actual = cw.FindRGB(new Hex("000000"));
        Assert.IsTrue(expected == actual);
    }
    
    [TestMethod]
    public void findRGB_HexToRGBNums_FindsCorrectValue()
    {
        RGB expected = new RGB(18, 52,86);
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel();
        RGB actual = cw.FindRGB(new Hex("123456"));
        Assert.IsTrue(expected == actual);
    }
    
    [TestMethod]
    public void findRGB_HexToRGBChars_FindsCorrectValue()
    {
        RGB expected = new RGB(255, 238,170);
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel();
        RGB actual = cw.FindRGB(new Hex("FFEEAA"));
        Assert.IsTrue(expected == actual);
    }
    
    [TestMethod]
    public void findRGB_HexToRGBMax_FindsCorrectValue()
    {
        RGB expected = new RGB(255, 255,255);
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel();
        RGB actual = cw.FindRGB(new Hex("FFFFFF"));
        Assert.IsTrue(expected == actual);
    }
    
    /// <summary>
    /// There is a natural margin of error of +-1 when converting from HSV to RGB.
    /// </summary>
    [TestMethod]
    public void findRGB_HSVToRGBZeros_FindsCorrectValue()
    {
        RGB expected = new RGB(0, 0,0);
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel();
        RGB actual = cw.FindRGB(new HSV(0,0, 0));
        Assert.IsLessThanOrEqualTo(1, Math.Abs(expected.Red - actual.Red));
        Assert.IsLessThanOrEqualTo(1, Math.Abs(expected.Green - actual.Green));
        Assert.IsLessThanOrEqualTo(1, Math.Abs(expected.Blue - actual.Blue));
    }
    
    [TestMethod]
    public void findRGB_HSVToRGB60Hue_FindsCorrectValue()
    {
        RGB expected = new RGB(86, 86,18);
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel();
        RGB actual = cw.FindRGB(new HSV(60,79, 34));
        Assert.IsLessThanOrEqualTo(1, Math.Abs(expected.Red - actual.Red));
        Assert.IsLessThanOrEqualTo(1, Math.Abs(expected.Green - actual.Green));
        Assert.IsLessThanOrEqualTo(1, Math.Abs(expected.Blue - actual.Blue));
    }
    
    [TestMethod]
    public void findRGB_HSVToRGB120Hue_FindsCorrectValue()
    {
        RGB expected = new RGB(18, 86,18);
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel();
        RGB actual = cw.FindRGB(new HSV(120,79, 34));
        Assert.IsLessThanOrEqualTo(1, Math.Abs(expected.Red - actual.Red));
        Assert.IsLessThanOrEqualTo(1, Math.Abs(expected.Green - actual.Green));
        Assert.IsLessThanOrEqualTo(1, Math.Abs(expected.Blue - actual.Blue));
    }
    
    [TestMethod]
    public void findRGB_HSVToRGB180Hue_FindsCorrectValue()
    {
        RGB expected = new RGB(18, 86,86);
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel();
        RGB actual = cw.FindRGB(new HSV(180,79, 34));
        Assert.IsLessThanOrEqualTo(1, Math.Abs(expected.Red - actual.Red));
        Assert.IsLessThanOrEqualTo(1, Math.Abs(expected.Green - actual.Green));
        Assert.IsLessThanOrEqualTo(1, Math.Abs(expected.Blue - actual.Blue));
    }
    
    [TestMethod]
    public void findRGB_HSVToRGB240Hue_FindsCorrectValue()
    {
        RGB expected = new RGB(18, 18,86);
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel();
        RGB actual = cw.FindRGB(new HSV(240,79, 34));
        Assert.IsLessThanOrEqualTo(1, Math.Abs(expected.Red - actual.Red));
        Assert.IsLessThanOrEqualTo(1, Math.Abs(expected.Green - actual.Green));
        Assert.IsLessThanOrEqualTo(1, Math.Abs(expected.Blue - actual.Blue));
    }
    
    [TestMethod]
    public void findRGB_HSVToRGB300Hue_FindsCorrectValue()
    {
        RGB expected = new RGB(86, 18,86);
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel();
        RGB actual = cw.FindRGB(new HSV(300,79, 34));
        Assert.IsLessThanOrEqualTo(1, Math.Abs(expected.Red - actual.Red));
        Assert.IsLessThanOrEqualTo(1, Math.Abs(expected.Green - actual.Green));
        Assert.IsLessThanOrEqualTo(1, Math.Abs(expected.Blue - actual.Blue));
    }
    
    [TestMethod]
    public void findRGB_HSVToRGBMaxValue_FindsCorrectValue()
    {
        RGB expected = new RGB(255, 255,255);
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel();
        RGB actual = cw.FindRGB(new HSV(0,0, 100));
        Assert.IsLessThanOrEqualTo(1, Math.Abs(expected.Red - actual.Red));
        Assert.IsLessThanOrEqualTo(1, Math.Abs(expected.Green - actual.Green));
        Assert.IsLessThanOrEqualTo(1, Math.Abs(expected.Blue - actual.Blue));
    }
    
    [TestMethod]
    public void findRGB_HSVToRGBMaxHSV_FindsCorrectValue()
    {
        RGB expected = new RGB(255, 0,0);
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel();
        RGB actual = cw.FindRGB(new HSV(360,100, 100));
        Assert.IsLessThanOrEqualTo(1, Math.Abs(expected.Red - actual.Red));
        Assert.IsLessThanOrEqualTo(1, Math.Abs(expected.Green - actual.Green));
        Assert.IsLessThanOrEqualTo(1, Math.Abs(expected.Blue - actual.Blue));
    }
    
    [TestMethod]
    public void findHSV_HexToHSVZeros_FindsCorrectValue()
    {
        HSV expected = new HSV(0, 0, 0);
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel();
        HSV actual = cw.FindHSV(new Hex("000000"));
        Assert.IsLessThanOrEqualTo(3, Math.Abs(expected.Hue - actual.Hue));
        Assert.IsLessThanOrEqualTo(1, Math.Abs(expected.Saturation - actual.Saturation));
        Assert.IsLessThanOrEqualTo(1, Math.Abs(expected.Value - actual.Value));
    }
    
    [TestMethod]
    public void findHSV_HexToHSVNums_FindsCorrectValue()
    {
        HSV expected = new HSV(210, 79, 34);
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel();
        HSV actual = cw.FindHSV(new Hex("123456"));
        Assert.IsLessThanOrEqualTo(3, Math.Abs(expected.Hue - actual.Hue));
        Assert.IsLessThanOrEqualTo(1, Math.Abs(expected.Saturation - actual.Saturation));
        Assert.IsLessThanOrEqualTo(1, Math.Abs(expected.Value - actual.Value));
    }
    
    [TestMethod]
    public void findHSV_HexToHSVChars_FindsCorrectValue()
    {
        HSV expected = new HSV(10, 20, 30);
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel();
        HSV actual = cw.FindHSV(new Hex("4c3f3d"));
        Assert.IsLessThanOrEqualTo(3, Math.Abs(expected.Hue - actual.Hue));
        Assert.IsLessThanOrEqualTo(1, Math.Abs(expected.Saturation - actual.Saturation));
        Assert.IsLessThanOrEqualTo(1, Math.Abs(expected.Value - actual.Value));
    }
    
    [TestMethod]
    public void findHSV_HexToHSVMax_FindsCorrectValue()
    {
        HSV expected = new HSV(0, 0, 100);
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel();
        HSV actual = cw.FindHSV(new Hex("FFFFFF"));
        Assert.IsLessThanOrEqualTo(3, Math.Abs(expected.Hue - actual.Hue));
        Assert.IsLessThanOrEqualTo(1, Math.Abs(expected.Saturation - actual.Saturation));
        Assert.IsLessThanOrEqualTo(1, Math.Abs(expected.Value - actual.Value));
    }
    
    /// <summary>
    /// There is a natural margin of error of +-3 with hue, +-1 with saturation and value
    /// when converting from RGB to HSV.
    /// </summary>
    [TestMethod]
    public void findHSV_RGBToHSVZeros_FindsCorrectValue()
    {
        HSV expected = new HSV(0, 0, 0);
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel();
        HSV actual = cw.FindHSV(new RGB(0,0,0));
        Assert.IsLessThanOrEqualTo(3, Math.Abs(expected.Hue - actual.Hue));
        Assert.IsLessThanOrEqualTo(1, Math.Abs(expected.Saturation - actual.Saturation));
        Assert.IsLessThanOrEqualTo(1, Math.Abs(expected.Value - actual.Value));
    }
    
    [TestMethod]
    public void findHSV_RGBToHSVRedMax_FindsCorrectValue()
    {
        HSV expected = new HSV(10, 20, 30);
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel();
        HSV actual = cw.FindHSV(new RGB(76,63,61));
        Assert.IsLessThanOrEqualTo(3, Math.Abs(expected.Hue - actual.Hue));
        Assert.IsLessThanOrEqualTo(1, Math.Abs(expected.Saturation - actual.Saturation));
        Assert.IsLessThanOrEqualTo(1, Math.Abs(expected.Value - actual.Value));
    }
    
    [TestMethod]
    public void findHSV_RGBToHSVGreenMax_FindsCorrectValue()
    {
        HSV expected = new HSV(97, 39, 39);
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel();
        HSV actual = cw.FindHSV(new RGB(76,100,61));
        Assert.IsLessThanOrEqualTo(3, Math.Abs(expected.Hue - actual.Hue));
        Assert.IsLessThanOrEqualTo(1, Math.Abs(expected.Saturation - actual.Saturation));
        Assert.IsLessThanOrEqualTo(1, Math.Abs(expected.Value - actual.Value));
    }
    
    [TestMethod]
    public void findHSV_RGBToHSVBlueMax_FindsCorrectValue()
    {
        HSV expected = new HSV(261, 37, 39);
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel();
        HSV actual = cw.FindHSV(new RGB(76,63,100));
        Assert.IsLessThanOrEqualTo(3, Math.Abs(expected.Hue - actual.Hue));
        Assert.IsLessThanOrEqualTo(1, Math.Abs(expected.Saturation - actual.Saturation));
        Assert.IsLessThanOrEqualTo(1, Math.Abs(expected.Value - actual.Value));
    }
    
    [TestMethod]
    public void findHSV_RGBToHSVMax_FindsCorrectValue()
    {
        HSV expected = new HSV(0, 0, 100);
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel();
        HSV actual = cw.FindHSV(new RGB(255,255,255));
        Assert.IsLessThanOrEqualTo(3, Math.Abs(expected.Hue - actual.Hue));
        Assert.IsLessThanOrEqualTo(1, Math.Abs(expected.Saturation - actual.Saturation));
        Assert.IsLessThanOrEqualTo(1, Math.Abs(expected.Value - actual.Value));
    }
    
    [TestMethod]
    public void findHex_RGBToHexZeros_FindsCorrectValue()
    {
        Hex expected = new Hex("000000");
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel();
        Hex actual = cw.FindHex(new RGB(0,0,0));
        Assert.IsTrue(expected == actual);
    }
    
    [TestMethod]
    public void findHex_RGBToHexNums_FindsCorrectValue()
    {
        Hex expected = new Hex("102040");
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel();
        Hex actual = cw.FindHex(new RGB(16,32,64));
        Assert.IsTrue(expected == actual);
    }
    
    [TestMethod]
    public void findHex_RGBToHexChars_FindsCorrectValue()
    {
        Hex expected = new Hex("FFEEAA");
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel();
        Hex actual = cw.FindHex(new RGB(255,238,170));
        Assert.IsTrue(expected == actual);
    }
    
    [TestMethod]
    public void findHex_RGBToHexCharsMax_FindsCorrectValue()
    {
        Hex expected = new Hex("FFFFFF");
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel();
        Hex actual = cw.FindHex(new RGB(255,255,255));
        Assert.IsTrue(expected == actual);
    }
    
    [TestMethod]
    public void findHex_HSVToHexZeros_FindsCorrectValue()
    {
        Hex expected = new Hex("000000");
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel();
        Hex actual = cw.FindHex(new HSV(0,0,0));
        Assert.IsTrue(expected == actual);
    }
    
    [TestMethod]
    public void findHex_HSVToHexNums_FindsCorrectValue()
    {
        Hex expected = new Hex("102040");
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel();
        Hex actual = cw.FindHex(new HSV(220,75,25));
        Assert.IsTrue(expected == actual);
    }
    
    [TestMethod]
    public void findHex_HSVToHexMax_FindsCorrectValue()
    {
        Hex expected = new Hex("FF0000");
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel();
        Hex actual = cw.FindHex(new HSV(360,100,100));
        Assert.IsTrue(expected == actual);
    }

    [TestMethod]
    public void EqualsOperator_SameColorWheel_True()
    {
        Hex hex = new Hex("FF0000");
        ColorWheel.ColorWheel left = new ColorWheel.ColorWheel(hex);
        ColorWheel.ColorWheel right = new ColorWheel.ColorWheel(hex);
        Assert.IsTrue(left == right);
    }
    
    [TestMethod]
    public void EqualsOperator_DifferentColorWheel_False()
    {
        Hex hex = new Hex("FF0000");
        ColorWheel.ColorWheel left = new ColorWheel.ColorWheel(hex);
        ColorWheel.ColorWheel right = new ColorWheel.ColorWheel();
        Assert.IsFalse(left == right);
    }
    
    [TestMethod]
    public void NotEqualsOperator_SameColorWheel_False()
    {
        Hex hex = new Hex("FF0000");
        ColorWheel.ColorWheel left = new ColorWheel.ColorWheel(hex);
        ColorWheel.ColorWheel right = new ColorWheel.ColorWheel(hex);
        Assert.IsFalse(left != right);
    }
    
    [TestMethod]
    public void NotEqualsOperator_DifferentColorWheel_True()
    {
        Hex hex = new Hex("FF0000");
        ColorWheel.ColorWheel left = new ColorWheel.ColorWheel(hex);
        ColorWheel.ColorWheel right = new ColorWheel.ColorWheel();
        Assert.IsTrue(left != right);
    }
    
    [TestMethod]
    public void Equals_SameColorWheel_True()
    {
        Hex hex = new Hex("FF0000");
        ColorWheel.ColorWheel left = new ColorWheel.ColorWheel(hex);
        ColorWheel.ColorWheel right = new ColorWheel.ColorWheel(hex);
        Assert.IsTrue(left.Equals(right));
    }
    
    [TestMethod]
    public void Equals_DifferentColorWheel_False()
    {
        Hex hex = new Hex("FF0000");
        ColorWheel.ColorWheel left = new ColorWheel.ColorWheel(hex);
        ColorWheel.ColorWheel right = new ColorWheel.ColorWheel();
        Assert.IsFalse(left.Equals(right));
    }
    
    [TestMethod]
    public void Equals_DifferentObject_False()
    {
        Hex hex = new Hex("FF0000");
        ColorWheel.ColorWheel left = new ColorWheel.ColorWheel(hex);
        Assert.IsFalse(left.Equals(new LinkedList<string>()));
    }
    
    [TestMethod]
    public void Equals_Null_False()
    {
        Hex hex = new Hex("FF0000");
        ColorWheel.ColorWheel left = new ColorWheel.ColorWheel(hex);
        Assert.IsFalse(left.Equals(null));
    }
    
    [TestMethod]
    public void GetHashCode_SameColorWheel_True()
    {
        Hex hex = new Hex("FF0000");
        ColorWheel.ColorWheel left = new ColorWheel.ColorWheel(hex);
        ColorWheel.ColorWheel right = new ColorWheel.ColorWheel(hex);
        Assert.AreEqual(left.GetHashCode(), right.GetHashCode());
    }
    
    [TestMethod]
    public void GetHashCode_DifferentColorWheel_False()
    {
        Hex hex = new Hex("FF0000");
        ColorWheel.ColorWheel left = new ColorWheel.ColorWheel(hex);
        ColorWheel.ColorWheel right = new ColorWheel.ColorWheel();
        Assert.AreNotEqual(left.GetHashCode(), right.GetHashCode());
    }
    
    [TestMethod]
    public void GetHashCode_DifferentObject_False()
    {
        Hex hex = new Hex("FF0000");
        ColorWheel.ColorWheel left = new ColorWheel.ColorWheel(hex);
        Object right = new();
        Assert.AreNotEqual(left.GetHashCode(), right.GetHashCode());
    }
}

/// <summary>
/// Unit tests for the BlendModes class.
/// </summary>
[TestClass]
public class BlendModesTests
{
    // TODO
    [TestMethod]
    public void Multiply_ComputesValues_CorrectValue()
    {
    }
    
    [TestMethod]
    public void Add_ComputesValues_CorrectValue()
    {
    }
    
    [TestMethod]
    public void Screen_ComputesValues_CorrectValue()
    {
    }
    
    [TestMethod]
    public void Overlay_ComputesValues_CorrectValue()
    {
    }
}