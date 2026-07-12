using ColorWheel;

namespace ColorWheelTests;

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
    public void findRGB_HexToRGB_FindsCorrectValue()
    {
        RGB expected = new RGB(18, 52,86);
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel();
        RGB actual = cw.findRGB(new Hex("123456"));
        Assert.IsTrue(expected == actual);
    }
    
    [TestMethod]
    public void findRGB_HSVToRGB_FindsCorrectValue()
    {
        RGB expected = new RGB(18, 52,86);
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel();
        RGB actual = cw.findRGB(new HSV(210,79, 34));
        Assert.IsTrue(expected == actual);
    }
    
    [TestMethod]
    public void findHSV_HexToHSV_FindsCorrectValue()
    {
        HSV expected = new HSV(10, 20, 30);
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel();
        HSV actual = cw.findHSV(new Hex("4c3f3d"));
        Assert.IsTrue(expected == actual);
    }
    
    [TestMethod]
    public void findHSV_RGBToHSV_FindsCorrectValue()
    {
        HSV expected = new HSV(10, 20, 30);
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel();
        HSV actual = cw.findHSV(new RGB(76,63,61));
        Assert.IsTrue(expected == actual);
    }
    
    [TestMethod]
    public void findHex_RGBToHex_FindsCorrectValue()
    {
        Hex expected = new Hex("102040");
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel();
        Hex actual = cw.findHex(new RGB(16,32,64));
        Assert.IsTrue(expected == actual);
    }
    
    [TestMethod]
    public void findHex_HSVToHex_FindsCorrectValue()
    {
        Hex expected = new Hex("102040");
        ColorWheel.ColorWheel cw = new ColorWheel.ColorWheel();
        Hex actual = cw.findHex(new HSV(220,75,25));
        Assert.IsTrue(expected == actual);
    }
}

[TestClass]
public class BlendModesTests
{
    [TestMethod]
    public void Multiply_ComputesValues_CorrectRGBValue()
    {
    }
    
    [TestMethod]
    public void Multiply_ComputesValues_CorrectHexValue()
    {
    }
    
    [TestMethod]
    public void Multiply_ComputesValues_CorrectHSVValue()
    {
    }   
    
    [TestMethod]
    public void Add_ComputesValues_CorrectRGBValue()
    {
    }
    
    [TestMethod]
    public void Add_ComputesValues_CorrectHexValue()
    {
    }
    
    [TestMethod]
    public void Add_ComputesValues_CorrectHSVValue()
    {
    }  
    
    [TestMethod]
    public void Screen_ComputesValues_CorrectRGBValue()
    {
    }
    
    [TestMethod]
    public void Screen_ComputesValues_CorrectHexValue()
    {
    }
    
    [TestMethod]
    public void Screen_ComputesValues_CorrectHSVValue()
    {
    }  
    
    [TestMethod]
    public void Overlay_ComputesValues_CorrectRGBValue()
    {
    }
    
    [TestMethod]
    public void Overlay_ComputesValues_CorrectHexValue()
    {
    }
    
    [TestMethod]
    public void Overlay_ComputesValues_CorrectHSVValue()
    {
    }  
}