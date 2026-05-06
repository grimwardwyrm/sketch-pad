using ColorWheel;

namespace ColorWheelTests;

/// <summary>
/// Unit tests for the RGB class
/// </summary>
[TestClass]
public class RGBTests
{
    // --- Tests for Constructors ---
    
    [TestMethod]
    public void Constructor_RGBZero_AssignsCorrectValues()
    {
        RGB rgb = new RGB(0, 0, 0);
        Assert.IsTrue(rgb.r == 0 && rgb.g == 0 && rgb.b == 0);
    }
    
    [TestMethod]
    public void Constructor_RGB255_AssignsCorrectValues()
    {
        RGB rgb = new RGB(255, 255, 255);
        Assert.IsTrue(rgb.r == 255 && rgb.g == 255 && rgb.b == 255);
    }
    
    [TestMethod]
    public void Constructor_RGBUnder255_AssignsCorrectValues()
    {
        RGB rgb = new RGB(50, 40, 30);
        Assert.IsTrue(rgb.r == 50 && rgb.g == 40 && rgb.b == 30);
    }
    
    [TestMethod]
    public void Constructor_RGBOver255_AssignsCorrectValues()
    {
        RGB rgb = new RGB(260, 270, 280);
        Assert.IsTrue(rgb.r == 5 && rgb.g == 15 && rgb.b == 25);
    }
    
    [TestMethod]
    public void Constructor_NegativeRGB_DoesNotThrow()
    {
        RGB _ = new RGB(-10, -20, -30);
    }
    
    [TestMethod]
    public void Constructor_NegativeRGB_AssignsCorrectValues()
    {
        RGB rgb = new RGB(-10, -20, -30);
        Assert.IsTrue(rgb.r == 245 && rgb.g == 235 && rgb.b == 225);
    }
    
    // --- Tests for Equality ---

    [TestMethod]
    public void AreEqual_SameRGB_True()
    {
        RGB rgb1 = new RGB(5, 10, 15);
        RGB rgb2 = new RGB(5, 10, 15);
        Assert.IsTrue(rgb1.Equals(rgb2));
    }
    
    [TestMethod]
    public void AreEqual_DifferentRGB_False()
    {
        RGB rgb1 = new RGB(5, 10, 15);
        RGB rgb2 = new RGB(10, 15, 5);
        Assert.IsFalse(rgb1.Equals(rgb2));
    }
    
    [TestMethod]
    public void AreEqual_DifferentObject_False()
    {
        RGB rgb1 = new RGB(5, 10, 15);
        Object obj = new();
        Assert.IsFalse(rgb1.Equals(obj));
    }
    
    [TestMethod]
    public void AreEqual_Null_False()
    {
        RGB rgb1 = new RGB(5, 10, 15);
        Assert.IsFalse(rgb1.Equals(null));
    }
    
    [TestMethod]
    public void GetHashCode_SameRGB_True()
    {
        RGB rgb1 = new RGB(5, 10, 15);
        RGB rgb2 = new RGB(5, 10, 15);
        Assert.AreEqual(rgb2.GetHashCode(), rgb1.GetHashCode());
    }
    
    [TestMethod]
    public void GetHashCode_DifferentRGB_False()
    {
        RGB rgb1 = new RGB(5, 10, 15);
        RGB rgb2 = new RGB(10, 15, 5);
        Assert.AreNotEqual(rgb2.GetHashCode(), rgb1.GetHashCode());
    }
    
    [TestMethod]
    public void GetHashCode_DifferentObject_False()
    {
        RGB rgb1 = new RGB(5, 10, 15);
        Object obj = new();
        Assert.AreNotEqual(obj.GetHashCode(), rgb1.GetHashCode());
    }
    
    [TestMethod]
    public void EqualsOverride_SameRGB_True()
    {
        RGB rgb1 = new RGB(5, 10, 15);
        RGB rgb2 = new RGB(5, 10, 15);
        Assert.IsTrue(rgb1 == rgb2);
    }
    
    [TestMethod]
    public void EqualsOverride_DifferentRGB_False()
    {
        RGB rgb1 = new RGB(5, 10, 15);
        RGB rgb2 = new RGB(10, 15, 5);
        Assert.IsFalse(rgb1 == rgb2);
    }
    
    [TestMethod]
    public void EqualsOverride_DifferentObject_False()
    {
        RGB rgb1 = new RGB(5, 10, 15);
        Object obj = new();
        Assert.IsFalse(rgb1 == obj);
    }
    
    [TestMethod]
    public void NotEqualsOverride_SameRGB_False()
    {
        RGB rgb1 = new RGB(5, 10, 15);
        RGB rgb2 = new RGB(5, 10, 15);
        Assert.IsFalse(rgb1 != rgb2);
    }
    
    [TestMethod]
    public void NotEqualsOverride_DifferentRGB_True()
    {
        RGB rgb1 = new RGB(5, 10, 15);
        RGB rgb2 = new RGB(10, 15, 5);
        Assert.IsTrue(rgb1 != rgb2);
    }
    
    [TestMethod]
    public void NotEqualsOverride_DifferentObject_True()
    {
        RGB rgb1 = new RGB(5, 10, 15);
        Object obj = new();
        Assert.IsTrue(rgb1 != obj);
    }
    
    // --- Tests for ToString ---
    
    [TestMethod]
    public void ToString_RGBUnder255_Correct()
    {
        string expected = "(50, 40, 30)";
        RGB rgb = new RGB(50, 40, 30);
        Assert.AreEqual(expected, rgb.ToString());
    }
    
    [TestMethod]
    public void ToString_RGBOver255_Correct()
    {
        string expected = "(5, 15, 20)";
        RGB rgb = new RGB(260, 270, 280);
        Assert.AreEqual(expected, rgb.ToString());
    }
    
    [TestMethod]
    public void ToString_NegativeRGB_Correct()
    {
        string expected = "(245, 235, 225)";
        RGB rgb = new RGB(-10, -20, -30);
        Assert.AreEqual(expected, rgb.ToString());
    }
}