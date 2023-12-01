using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMatrix : MonoBehaviour
{
    private HMatrix2D mat = new HMatrix2D();

    void Start()
    {
        //mat.SetIdentity();
        Question2();
        //mat.Print();

    }

    public static void Question2()
    {
        HMatrix2D mat1 = new HMatrix2D(new float[,] {{ 1, 2, 1 }, { 0, 1, 0 }, { 2, 3, 4 }});
        HMatrix2D mat2 = new HMatrix2D(new float[,] {{ 2, 5, 1 }, { 6, 7, 1 }, { 1, 8, 1 }});
        HVector2D vec1 = new HVector2D(2, 3); //matrix represented as a vector

        // Test matrix multiplication
        HMatrix2D resultMat1 = mat1 * mat2;

        // Test matrix and vector multiplication
        HVector2D resultVec1 = mat1 * vec1;

        // Display the results
        Debug.Log("Matrix multiplication: mat1 * mat2");
        resultMat1.Print();

        Debug.Log("Matrix-vector multiplication: mat1 * vec1");
        resultVec1.Print();
    }
}
