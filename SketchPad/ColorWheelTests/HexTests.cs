using ColorWheel;

namespace ColorWheelTests;

/// <summary>
/// Unit tests for the Hex class
/// </summary>
[TestClass]
public class HexTests
{
    // --- Tests for Constructor ---
    
    [TestMethod]
    public void Constructor_HashtagHex_ParsesHexCode()
    {
        Hex hex = new Hex("#ff0000");
        string expected = "ff0000";
        Assert.AreEqual(expected, hex.HexCode);
    }
    
    [TestMethod]
    public void Constructor_HashtagHex_ParsesRGB()
    {
        Hex hex = new Hex("#ff0011");
        string expectedrr = "ff";
        string expectedgg = "00";
        string expectedbb = "11";
        Assert.IsTrue(hex.RR == expectedrr && hex.GG == expectedgg && hex.BB == expectedbb);
    }
    
    [TestMethod]
    public void Constructor_IncompleteHashtagHex_FinishesHexCode()
    {
        Hex hex = new Hex("#ff");
        string expected = "ff0000";
        Assert.AreEqual(expected, hex.HexCode);
    }
    
    [TestMethod]
    public void Constructor_LongStringHashtagHex_ClampsTo6Digits()
    {
        Hex hex = new Hex("#ff000000000000");
        string expected = "ff0000";
        Assert.AreEqual(expected, hex.HexCode);
    }
    
    [TestMethod]
    public void Constructor_IntHex_ParsesHexCode()
    {
        Hex hex = new Hex("ff0000");
        string expected = "ff0000";
        Assert.AreEqual(expected, hex.HexCode);
    }
    
    [TestMethod]
    public void Constructor_IntHex_ParsesRGB()
    {
        Hex hex = new Hex("ff0011");
        string expectedrr = "ff";
        string expectedgg = "00";
        string expectedbb = "11";
        Assert.IsTrue(hex.RR == expectedrr && hex.GG == expectedgg && hex.BB == expectedbb);
    }
    
    [TestMethod]
    public void Constructor_IncompleteIntHex_FinishesHexCode()
    {
        Hex hex = new Hex("ff");
        string expected = "ff0000";
        Assert.AreEqual(expected, hex.HexCode);
    }
    
    [TestMethod]
    public void Constructor_LongStringIntHex_ClampsTo6Digits()
    {
        Hex hex = new Hex("ff000000000000");
        string expected = "ff0000";
        Assert.AreEqual(expected, hex.HexCode);
    }

    [TestMethod]
    public void Constructor_InvalidHex_Throws()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Hex("ZZ0000"));
    }
    
    // --- Tests for Equality ---

    [TestMethod]
    public void Equals_SameHex_True()
    {
        Hex hex1 = new Hex("#ff0000");
        Hex hex2 = new Hex("#ff0000");
        Assert.IsTrue(hex1.Equals(hex2));
    }
    
    [TestMethod]
    public void Equals_DifferentHex_False()
    {
        Hex hex1 = new Hex("#ff0000");
        Hex hex2 = new Hex("#00ff00");
        Assert.IsFalse(hex1.Equals(hex2));
    }
    
    [TestMethod]
    public void Equals_DifferentObject_False()
    {
        Hex hex1 = new Hex("#ff0000");
        Object obj = new();
        Assert.IsFalse(hex1.Equals(obj));
    }
    
    [TestMethod]
    public void Equals_Null_False()
    {
        Hex hex1 = new Hex("#ff0000");
        Assert.IsFalse(hex1.Equals(null));
    }
    
    [TestMethod]
    public void GetHashCode_SameHex_True()
    {
        Hex hex1 = new Hex("#ff0000");
        Hex hex2 = new Hex("#ff0000");
        Assert.AreEqual(hex2.GetHashCode(), hex1.GetHashCode());
    }
    
    [TestMethod]
    public void GetHashCode_DifferentHex_False()
    {
        Hex hex1 = new Hex("#ff0000");
        Hex hex2 = new Hex("#00ff00");
        Assert.AreNotEqual(hex2.GetHashCode(), hex1.GetHashCode());
    }
    
    [TestMethod]
    public void GetHashCode_DifferentObject_False()
    {
        Hex hex1 = new Hex("#ff0000");
        Object obj = new();
        Assert.AreNotEqual(obj.GetHashCode(), hex1.GetHashCode());
    }
    
    [TestMethod]
    public void EqualsOperator_SameHex_True()
    {
        Hex hex1 = new Hex("#ff0000");
        Hex hex2 = new Hex("#ff0000");
        Assert.IsTrue(hex1 == hex2);
    }
    
    [TestMethod]
    public void EqualsOperator_DifferentHex_False()
    {
        Hex hex1 = new Hex("#ff0000");
        Hex hex2 = new Hex("#00ff00");
        Assert.IsFalse(hex1 == hex2);
    }
    
    [TestMethod]
    public void NotEqualsOperator_SameHex_False()
    {
        Hex hex1 = new Hex("#ff0000");
        Hex hex2 = new Hex("#ff0000");
        Assert.IsFalse(hex1 != hex2);
    }
    
    [TestMethod]
    public void NotEqualsOperator_DifferentHex_True()
    {
        Hex hex1 = new Hex("#ff0000");
        Hex hex2 = new Hex("#00ff00");
        Assert.IsTrue(hex1 != hex2);
    }
    
    // --- Tests for ToString ---
    
    [TestMethod]
    public void ToString_Hex_Correct()
    {
        string expected = "#ff0101";
        Hex hex = new Hex("#ff0101");
        Assert.AreEqual(expected, hex.ToString());
    }
    
    [TestMethod]
    public void ToString_IncompleteHex_CompleteString()
    {
        string expected = "#ff0000";
        Hex hex = new Hex("#ff");
        Assert.AreEqual(expected, hex.ToString());
    }
    
    [TestMethod]
    public void ToString_LongString_ClampedString()
    {
        string expected = "#ff0000";
        Hex hex = new Hex("#ff0000000000");
        Assert.AreEqual(expected, hex.ToString());
    }
}