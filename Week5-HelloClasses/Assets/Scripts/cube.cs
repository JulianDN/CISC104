using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube
{
    private float height;
    private float width;
    private float length;
    private float volume;

    public Cube()
    {
        height = 0f;
        width = 0f;
        length = 0f;
    }
    public Cube(float newHeight, float newWidth, float newLength)
    {
        //Given Values
        height = newHeight;
        width = newWidth;
        length = newLength;
    }

    public float getEdge()
    {
        float edge = (height * width * length) / (height * width);
        return edge;
    }

    public float getVolume()
    {
        return height * width * length;
    }

    public float getHeight()
    {
        return height;
    }

    public void setHeight(float newHeight)
    {
        height = newHeight;
    }

    public void setWidth(float newWidth)
    {
        width = newWidth;
    }
    public float getWidth()
    {
        return width;
    }

    public float getLength()
    {
        return length;
    }
    public void setLength(float newLength)
    {
        length = newLength;
    }
}
