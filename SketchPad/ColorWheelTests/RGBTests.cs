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
        Assert.IsTrue(rgb is { Red: 0, Green: 0, Blue: 0 });
    }
    
    [TestMethod]
    public void Constructor_RGB255_AssignsCorrectValues()
    {
        RGB rgb = new RGB(255, 255, 255);
        Assert.IsTrue(rgb is { Red: 255, Green: 255, Blue: 255 });
    }
    
    [TestMethod]
    public void Constructor_RGBUnder255_AssignsCorrectValues()
    {
        RGB rgb = new RGB(50, 40, 30);
        Assert.IsTrue(rgb is { Red: 50, Green: 40, Blue: 30 });
    }
    
    [TestMethod]
    public void Constructor_RGBOver255_AssignsCorrectValues()
    {
        RGB rgb = new RGB(260, 270, 280);
        Assert.IsTrue(rgb is { Red: 5, Green: 15, Blue: 25 });
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
        Assert.IsTrue(rgb is { Red: 245, Green: 235, Blue: 225 });
    }
    
    // --- Tests for Equality ---

    [TestMethod]
    public void Equals_SameRGB_True()
    {
        RGB rgb1 = new RGB(5, 10, 15);
        RGB rgb2 = new RGB(5, 10, 15);
        Assert.IsTrue(rgb1.Equals(rgb2));
    }
    
    [TestMethod]
    public void Equals_DifferentRGB_False()
    {
        RGB rgb1 = new RGB(5, 10, 15);
        RGB rgb2 = new RGB(10, 15, 5);
        Assert.IsFalse(rgb1.Equals(rgb2));
    }
    
    [TestMethod]
    public void Equals_DifferentObject_False()
    {
        RGB rgb1 = new RGB(5, 10, 15);
        Object obj = new();
        Assert.IsFalse(rgb1.Equals(obj));
    }
    
    [TestMethod]
    public void Equals_Null_False()
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
    public void EqualsOperator_SameRGB_True()
    {
        RGB rgb1 = new RGB(5, 10, 15);
        RGB rgb2 = new RGB(5, 10, 15);
        Assert.IsTrue(rgb1 == rgb2);
    }
    
    [TestMethod]
    public void EqualsOperator_DifferentRGB_False()
    {
        RGB rgb1 = new RGB(5, 10, 15);
        RGB rgb2 = new RGB(10, 15, 5);
        Assert.IsFalse(rgb1 == rgb2);
    }
    
    [TestMethod]
    public void NotEqualsOperator_SameRGB_False()
    {
        RGB rgb1 = new RGB(5, 10, 15);
        RGB rgb2 = new RGB(5, 10, 15);
        Assert.IsFalse(rgb1 != rgb2);
    }
    
    [TestMethod]
    public void NotEqualsOperator_DifferentRGB_True()
    {
        RGB rgb1 = new RGB(5, 10, 15);
        RGB rgb2 = new RGB(10, 15, 5);
        Assert.IsTrue(rgb1 != rgb2);
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
        RGB rgb = new RGB(260, 270, 275);
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