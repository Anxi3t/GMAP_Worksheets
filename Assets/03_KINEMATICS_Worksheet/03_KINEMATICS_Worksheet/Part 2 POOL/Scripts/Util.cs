using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    //void Start()
    //{
        //HVector2D a = new HVector2D(0f, 5f);
        //HVector2D b = new HVector2D(0f, 0f);
        //float distance = Util.FindDistance(a, b);
        //Debug.Log("Distance between points: " + distance);
    //}
    
    public static float FindDistance(HVector2D p1, HVector2D p2)
    {
        // using pythagoras theorem: c = square root of (a^2 + b^2)
        // use unity's Mathf
        // find the square of a: (p2.x - p1.x)^2
        // find the square of b: (p2.y - p1.y)^2
        // square root of a^2 + b^2 to get c
        return Mathf.Sqrt(Mathf.Pow(p2.x - p1.x, 2f) + Mathf.Pow(p2.y - p1.y, 2f));
    }
}

