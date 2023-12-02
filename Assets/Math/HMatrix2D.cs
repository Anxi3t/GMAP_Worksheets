using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMatrix2D 
{
    public float[,] Entries { get; set; } = new float[3, 3];

    public HMatrix2D()
    {
        for (int y = 0; y < 3 ; y++) // for each row
            for (int x = 0; x < 3 ; x++) // for each column
            Entries[y, x] = x == y ? 1 : 0;
    } 

    public HMatrix2D(float[,] multiArray)
    {
        for (int y = 0; y < 3; y++)
        { 
            for (int x = 0; x < 3; x++)
            {
                Entries[y, x] = multiArray[y, x];
            }
        }
    }

    public HMatrix2D(float m00, float m01, float m02,
            float m10, float m11, float m12,
            float m20, float m21, float m22)
    {
        Entries[0, 0] = m00;
        Entries[0, 1] = m01;
        Entries[0, 2] = m02;

        Entries[1, 0] = m10;
        Entries[1, 1] = m11;
        Entries[1, 2] = m12;
        
        Entries[2, 0] = m20;
        Entries[2, 1] = m21;
        Entries[2, 2] = m22;
    }

    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D addResult = new HMatrix2D();
        for (int y = 0; y < 3; y++) //checks each row
            for (int x = 0; x < 3; x++) //checks each column
                addResult.Entries[y, x] = left.Entries[y, x] + right.Entries[y, x];
        return addResult;
    }

    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D subResult = new HMatrix2D();
        for (int y = 0; y < 3; y++) //checks each row
            for (int x = 0; x < 3; x++) //checks each column
                subResult.Entries[y, x] = left.Entries[y, x] - right.Entries[y, x];
        return subResult;
    }

    public static HMatrix2D operator *(HMatrix2D left, float scalar)
    {
        HMatrix2D multiplyResult = new HMatrix2D();
        for (int y = 0; y < 3; y++) //checks each row
            for (int x = 0; x < 3; x++) //checks each column
                multiplyResult.Entries[y, x] = left.Entries[y, x] * scalar;
        return multiplyResult;
    }

    // Note that the second argument is a HVector2D object
    //
    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        return new HVector2D(
            left.Entries[0, 0] * right.x + left.Entries[0, 1] * right.y + left.Entries[0, 2] * right.h, 
            left.Entries[1, 0] * right.x + left.Entries[1, 1] * right.y + left.Entries[1, 2] * right.h
        );
    }

    // Note that the second argument is a HMatrix2D object
    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
        return new HMatrix2D
        (
            // First row
            left.Entries[0, 0] * right.Entries[0, 0] + left.Entries[0, 1] * right.Entries[1, 0] + left.Entries[0, 2] * right.Entries[2, 0],
            left.Entries[0, 0] * right.Entries[0, 1] + left.Entries[0, 1] * right.Entries[1, 1] + left.Entries[0, 2] * right.Entries[2, 1],
            left.Entries[0, 0] * right.Entries[0, 2] + left.Entries[0, 1] * right.Entries[1, 2] + left.Entries[0, 2] * right.Entries[2, 2],

            // Second row
            left.Entries[1, 0] * right.Entries[0, 0] + left.Entries[1, 1] * right.Entries[1, 0] + left.Entries[1, 2] * right.Entries[2, 0],
            left.Entries[1, 0] * right.Entries[0, 1] + left.Entries[1, 1] * right.Entries[1, 1] + left.Entries[1, 2] * right.Entries[2, 1],
            left.Entries[1, 0] * right.Entries[0, 2] + left.Entries[1, 1] * right.Entries[1, 2] + left.Entries[1, 2] * right.Entries[2, 2],

            // Third row
            left.Entries[2, 0] * right.Entries[0, 0] + left.Entries[2, 1] * right.Entries[1, 0] + left.Entries[2, 2] * right.Entries[2, 0],
            left.Entries[2, 0] * right.Entries[0, 1] + left.Entries[2, 1] * right.Entries[1, 1] + left.Entries[2, 2] * right.Entries[2, 1],
            left.Entries[2, 0] * right.Entries[0, 2] + left.Entries[2, 1] * right.Entries[1, 2] + left.Entries[2, 2] * right.Entries[2, 2]
        );
    }

    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {
        for (int y = 0; y < 3; y++) //checks each row
            for (int x = 0; x < 3; x++) //checks each column
                if (left.Entries[y, x] != right.Entries[y, x]) //check if any two corresponding elements are not equal 
                    return false; // returns false if there are elements not corresponding
        return true; //returns true if all the elements are corresponding, matrices are the same
    }

    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        for (int y = 0; y < 3; y++)
            for (int x = 0; x < 3; x++)
                if (left.Entries[y, x] != right.Entries[y, x]) //check if any two corresponding elements are not equal 
                    return true; // returns true if there are elements not corresponding
        return false; //returns false if all the elements are corresponding, matrices not the same
    }

    //public HMatrix2D transpose()
    //{
        //return // your code here
    //}

    //public float GetDeterminant()
    //{
        //return // your code here
    //}

    public void SetIdentity()
    {
        for (int y = 0; y < 3 ; y++) // for each row
            for (int x = 0; x < 3 ; x++) // for each column
            Entries[y, x] = x == y ? 1 : 0;
        //for (int y = 0; y < 3 ; y++) // for each row
        //{
            //for (int x = 0; x < 3 ; x++) // for each column
            //{
                //if (x == y)
                //{
                    //Entries[y, x] = 1;
                //}
                //else
                //{
                    //Entries[y, x] = 0;
                //}
            //}
        //}
    }

    public void SetTranslationMatrix(float transX, float transY)
    {
        SetIdentity(); // set the matrix to an identity matrix
        Entries[0, 2] = transX; // set the translation in the x-axis
        Entries[1, 2] = transY; // set the translation in the y-axis
    }

    public void SetRotationMatrix(float rotDeg)
    {
        SetIdentity(); // set the matrix to an identity matrix
        float rad = rotDeg * Mathf.Deg2Rad; // converts the rotation angle from degrees to radians
        Entries[0, 0] = Mathf.Cos(rad);
        Entries[0, 1] = -Mathf.Sin(rad);
        Entries[1, 0] = Mathf.Sin(rad);
        Entries[1, 1] = Mathf.Cos(rad);
    }

    //public void SetScalingMat(float scaleX, float scaleY)
    //{
        // your code here
    //}

    public void Print()
    {
        string result = "";
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                result += Entries[r, c] + "  ";
            }
            result += "\n";
        }
        Debug.Log(result);
    }
}
