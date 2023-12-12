using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class DictionaryIntersectionTests
{
    [Test]
    public void Test_Intersect_TwoEmptyDictionaries_ReturnsEmptyDictionary()
    {
       //Arrange
       Dictionary<string,int> dic1= new Dictionary<string,int>();
       Dictionary<string,int> dic2= new Dictionary<string,int>();
       //Act
       Dictionary<string,int> result=DictionaryIntersection.Intersect(dic1, dic2);
        //Assert
        Assert.That(result, Has.Count.EqualTo(0));
    }
    [Test]
    public void Test_Intersect_OneEmptyDictionaryAndOneNonEmptyDictionary_ReturnsEmptyDictionary()
    {
        //Arrange
        Dictionary<string,int> dic1= new Dictionary<string,int>();  
        Dictionary<string,int> dic2= new Dictionary<string,int>()
        {
            {"sofia",1},
            {"pleven",2}
        };  
        //Act
        Dictionary<string,int> result=DictionaryIntersection.Intersect(dic1, dic2);
        //Assert
        Assert.That(result,Has.Count.EqualTo(0));
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithNoCommonKeys_ReturnsEmptyDictionary()
    {   
        //Arrange
        Dictionary<string,int> dic1= new Dictionary<string,int>()
        {
            {"sofia1",3 },
            {"pleven1",4 }
        };
        Dictionary<string,int> dic2= new Dictionary<string, int>()
        {
            {"sofia",3 },
            {"pleven",4 }
        };
        //Act
        Dictionary<string,int> result=DictionaryIntersection.Intersect(dic1, dic2);
        //Assert
        Assert.That(result, Has.Count.EqualTo(0));
        Assert.AreEqual(0,result.Count);
       
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithCommonKeysAndValues_ReturnsIntersectionDictionary()
    {
        //Arrange
        Dictionary<string, int> dic1 = new Dictionary<string, int>()
        {
            {"sofia",1 },
            {"pleven",4 }
        };
        Dictionary<string, int> dic2 = new Dictionary<string, int>()
        {
            {"sofia",1 },
            {"pleven",4 }
        };
        Dictionary<string, int> expected = new Dictionary<string, int>()
        {
            {"sofia",1 },
            {"pleven",4 }
        };
        
        //Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(dic1, dic2);
        
        //Assert
        Assert.AreEqual(2,result.Count);
        Assert.AreEqual(expected,result);

        Assert.IsTrue(result.ContainsKey("sofia"));
        Assert.AreEqual(1, result["sofia"]);

        Assert.IsTrue(result.ContainsKey("pleven"));
        Assert.AreEqual(4, result["pleven"]);
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithCommonKeysAndDifferentValues_ReturnsEmptyDictionary()
    {
        //Arrange
        Dictionary<string, int> dic1 = new Dictionary<string, int>()
        {
            {"sofia1",3 },
            {"pleven1",4 }
        };
        Dictionary<string, int> dic2 = new Dictionary<string, int>()
        {
            {"sofia1",1 },
            {"pleven1",3 }
        };
        //Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(dic1, dic2);
        //Assert
        Assert.That(result, Has.Count.EqualTo(0));
    }
}
