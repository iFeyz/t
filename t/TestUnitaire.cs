using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

[TestClass]
public class PlateauTests
{
    [TestMethod]
    public void TestGenerationPlateau()
    {
        Plateau plateau = new Plateau();


        string[,] result = plateau.generationPlateau(5, 5); 

        Assert.IsNotNull(result);
        Assert.AreEqual(5, result.GetLength(0));
        Assert.AreEqual(5, result.GetLength(1));
    }

    [TestMethod]
    public void TestRechercheMotPresent()
    {
        Plateau plateau = new Plateau();
        string[,] testPlateau = new string[,]
        {
            { "A", "B", "C" },
            { "D", "E", "F" },
            { "G", "H", "I" }
        };


        RecherchePlateau result = plateau.RechercheMot("ABC", testPlateau);


        Assert.IsNotNull(result);
        Assert.IsTrue(result.motPresent == true);

    }

    [TestMethod]
    public void TestRechercheMotNonPresent()
    {
 
        Plateau plateau = new Plateau();
        string[,] testPlateau = new string[,]
        {
            { "A", "B", "C" },
            { "D", "E", "F" },
            { "G", "H", "I" }
        };

   
        RecherchePlateau result = plateau.RechercheMot("XYZ", testPlateau);


        Assert.IsNotNull(result);
        Assert.IsTrue(result.motPresent == false);

    }

    [TestMethod]
    public void TestMajPlateau()
    {
        
        Plateau plateau = new Plateau();
        string[,] testPlateau = new string[,]
        {
            { "", "B", "C" },
            { "D", "E", "F" },
            { "G", "H", "I" }
        };
        RecherchePlateau recherchePlateau = new RecherchePlateau
        {
            indexMotTrouver = { new int[] { 1, 0 }, new int[] { 0, 1 } }
        };

    
        string[,] result = plateau.majPlateau(testPlateau, recherchePlateau);


        Assert.IsNotNull(result);
        Assert.AreEqual("", result[1, 0]);
        Assert.AreEqual("", result[0, 1]);
        
    }

    [TestMethod]
    public void TestToFileAndToRead()
    {
        
        Plateau plateau = new Plateau();
        string[,] testPlateau = new string[,]
        {
            { "A", "B", "C" },
            { "D", "E", "F" },
            { "G", "H", "I" }
        };

     
        plateau.toFile(testPlateau);
        string[,] result = plateau.toRead("../../../save/1");

       
        Assert.IsNotNull(result);
        CollectionAssert.AreEqual(testPlateau, result);
  
    }
}
