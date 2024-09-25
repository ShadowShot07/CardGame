using System.Collections.Generic;
using Dakard.Card;
using NUnit.Framework;

public class ResourcesTest
{
    private Dictionary<string, int> _resources = new Dictionary<string, int>();

    [SetUp]
    public void Setup()
    {
        _resources.Clear();
    }
    
    [Test]
    public void AddHealthTest()
    {
        Resources.AddResource(_resources, Constants.HEALTH);
        Assert.AreEqual(1, _resources[Constants.HEALTH]);
    }
    
    
    [Test]
    public void RemoveHealthTest()
    {
        Resources.AddResource(_resources, Constants.HEALTH);
        Resources.RemoveResource(_resources, Constants.HEALTH);
        Assert.AreEqual(0, _resources[Constants.HEALTH]);
    }
}
