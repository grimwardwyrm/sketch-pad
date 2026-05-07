using ColorWheel;

namespace ColorWheelTests;

/// <summary>
/// Unit tests for the HSV class
/// </summary>
[TestClass] 
public class HSVTests
{
    // --- Tests for Constructors ---
    
    [TestMethod]
    public void Constructor_HSVZero_AssignsCorrectValues()
    {
        HSV hsv = new HSV(0, 0, 0);
        Assert.IsTrue(hsv is { Hue: 0, Saturation: 0, Value: 0 });
    }
    
    [TestMethod]
    public void Constructor_HSVMax_AssignsCorrectValues()
    {
        HSV hsv = new HSV(360, 100, 100);
        Assert.IsTrue(hsv is { Hue: 360, Saturation: 100, Value: 100 });
    }
    
    [TestMethod]
    public void Constructor_HSVUnderMax_AssignsCorrectValues()
    {
        HSV hsv = new HSV(50, 40, 30);
        Assert.IsTrue(hsv is { Hue: 50, Saturation: 40, Value: 30 });
    }
    
    [TestMethod]
    public void Constructor_HSVOverMax_AssignsCorrectValues()
    {
        HSV hsv = new HSV(370, 110, 110);
        Assert.IsTrue(hsv is { Hue: 10, Saturation: 10, Value: 10 });
    }
    
    [TestMethod]
    public void Constructor_NegativeHSV_DoesNotThrow()
    {
        HSV _ = new HSV(-10, -20, -30);
    }
    
    [TestMethod]
    public void Constructor_NegativeHSV_AssignsCorrectValues()
    {
        HSV hsv = new HSV(-10, -20, -30);
        Assert.IsTrue(hsv is { Hue: 350, Saturation: 80, Value: 70 });
    }
    
    // --- Tests for Equality ---

    [TestMethod]
    public void AreEqual_SameHSV_True()
    {
        HSV hsv1 = new HSV(5, 10, 15);
        HSV hsv2 = new HSV(5, 10, 15);
        Assert.IsTrue(hsv1.Equals(hsv2));
    }
    
    [TestMethod]
    public void AreEqual_DifferentHSV_False()
    {
        HSV hsv1 = new HSV(5, 10, 15);
        HSV hsv2 = new HSV(10, 15, 5);
        Assert.IsFalse(hsv1.Equals(hsv2));
    }
    
    [TestMethod]
    public void AreEqual_DifferentObject_False()
    {
        HSV hsv1 = new HSV(5, 10, 15);
        Object obj = new();
        Assert.IsFalse(hsv1.Equals(obj));
    }
    
    [TestMethod]
    public void AreEqual_Null_False()
    {
        HSV hsv1 = new HSV(5, 10, 15);
        Assert.IsFalse(hsv1.Equals(null));
    }
    
    [TestMethod]
    public void GetHashCode_SameHSV_True()
    {
        HSV hsv1 = new HSV(5, 10, 15);
        HSV hsv2 = new HSV(5, 10, 15);
        Assert.AreEqual(hsv2.GetHashCode(), hsv1.GetHashCode());
    }
    
    [TestMethod]
    public void GetHashCode_DifferentHSV_False()
    {
        HSV hsv1 = new HSV(5, 10, 15);
        HSV hsv2 = new HSV(10, 15, 5);
        Assert.AreNotEqual(hsv2.GetHashCode(), hsv1.GetHashCode());
    }
    
    [TestMethod]
    public void GetHashCode_DifferentObject_False()
    {
        HSV hsv1 = new HSV(5, 10, 15);
        Object obj = new();
        Assert.AreNotEqual(obj.GetHashCode(), hsv1.GetHashCode());
    }
    
    [TestMethod]
    public void EqualsOperatorOverride_SameHSV_True()
    {
        HSV hsv1 = new HSV(5, 10, 15);
        HSV hsv2 = new HSV(5, 10, 15);
        Assert.IsTrue(hsv1 == hsv2);
    }
    
    [TestMethod]
    public void EqualsOperatorOverride_DifferentHSV_False()
    {
        HSV hsv1 = new HSV(5, 10, 15);
        HSV hsv2 = new HSV(10, 15, 5);
        Assert.IsFalse(hsv1 == hsv2);
    }
    
    [TestMethod]
    public void NotEqualsOperatorOverride_SameHSV_False()
    {
        HSV hsv1 = new HSV(5, 10, 15);
        HSV hsv2 = new HSV(5, 10, 15);
        Assert.IsFalse(hsv1 != hsv2);
    }
    
    [TestMethod]
    public void NotEqualsOperatorOverride_DifferentHSV_True()
    {
        HSV hsv1 = new HSV(5, 10, 15);
        HSV hsv2 = new HSV(10, 15, 5);
        Assert.IsTrue(hsv1 != hsv2);
    }
    
    // --- Tests for ToString ---
    
    [TestMethod]
    public void ToString_HSVUnderMax_Correct()
    {
        string expected = "(50deg, 40%, 30%)";
        HSV hsv = new HSV(50, 40, 30);
        Assert.AreEqual(expected, hsv.ToString());
    }
    
    [TestMethod]
    public void ToString_HSVOverMax_Correct()
    {
        string expected = "(10deg, 10%, 10%)";
        HSV hsv = new HSV(370, 110, 110);
        Assert.AreEqual(expected, hsv.ToString());
    }
    
    [TestMethod]
    public void ToString_NegativeHSV_Correct()
    {
        string expected = "(350deg, 80%, 70%)";
        HSV hsv = new HSV(-10, -20, -30);
        Assert.AreEqual(expected, hsv.ToString());
    }
}