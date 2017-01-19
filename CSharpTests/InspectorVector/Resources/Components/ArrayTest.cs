using System;
using AtomicEngine;

public class ArrayTest : CSComponent
{

    [Inspector]
    bool[] MyBoolArray;

    [Inspector]
    int[] MyIntArray;

    [Inspector]
    uint[] MyUIntArray;

    [Inspector]
    float[] MyFloatArray;

    [Inspector]
    Color[] MyColorArray;

    [Inspector]
    Vector2[] MyVector2Array;

    [Inspector]
    Vector3[] MyVector3Array;

    [Inspector]
    string[] MyStringArray;


    // TODO resource/node arrays

    void Update(float timeStep)
    {
        
    }

}
