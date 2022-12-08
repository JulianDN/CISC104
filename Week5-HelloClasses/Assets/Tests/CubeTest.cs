using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CubeTest
{
    [Test]
    public void CubeDefaultTest()
    {
       
        Cube testCube = new Cube();

       
        Assert.AreEqual(0, testCube.getHeight());
        Assert.AreEqual(0, testCube.getWidth());
        Assert.AreEqual(0, testCube.getLength());
        Assert.AreEqual(0, testCube.getVolume());
    }

   
    [Test]
    public void CubeLengthTest()
    {
      
        Cube testLength = new Cube(1f, 8f, 7f);

       
        testLength.setLength(5);

      
        Assert.AreEqual(1, testLength.getHeight());
        Assert.AreEqual(8, testLength.getWidth());
        Assert.AreEqual(5, testLength.getLength()); 
        Assert.AreEqual(40, testLength.getVolume());
        Assert.AreEqual(5, testLength.getEdge());
    }


    [Test]
    public void CubeTwoByThreeByFourTest()
    {
        
        Cube testSetCube = new Cube(2f, 9f, 2f);

       
        Assert.AreEqual(2, testSetCube.getHeight());
        Assert.AreEqual(9, testSetCube.getWidth());
        Assert.AreEqual(1, testSetCube.getLength());
        Assert.AreEqual(18, testSetCube.getVolume());
        Assert.AreEqual(4, testSetCube.getEdge());
    }
}