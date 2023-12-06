using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMesh : MonoBehaviour
{
    [HideInInspector]
    public Vector3[] vertices { get; private set; }

    private HMatrix2D transformMatrix = new HMatrix2D();
    private HMatrix2D toOriginMatrix = new HMatrix2D();
    private HMatrix2D fromOriginMatrix = new HMatrix2D();
    private HMatrix2D rotateMatrix = new HMatrix2D();

    private MeshManager meshManager;
    HVector2D pos = new HVector2D();

    void Start()
    {
        meshManager = GetComponent<MeshManager>();
        pos = new HVector2D(gameObject.transform.position.x, gameObject.transform.position.y);

        //Translate(1 , 1);
        Rotate(315);
    }


    void Translate(float x, float y)
    {
        transformMatrix.SetIdentity(); //set transform matrix to identity matrix
        transformMatrix.SetTranslationMatrix(x, y); //translate the sprite by the x and y values  
        Transform();

        pos = transformMatrix * pos; //update the sprites position to the current new position
    }

    void Rotate(float angle)
    {
        HMatrix2D toOriginMatrix = new HMatrix2D();
        HMatrix2D fromOriginMatrix = new HMatrix2D();
        HMatrix2D rotateMatrix = new HMatrix2D();

        toOriginMatrix.SetTranslationMatrix(-pos.x, -pos.y); //sets the matrix back to the origin
        fromOriginMatrix.SetTranslationMatrix(pos.x, pos.y); //sets the matrix back to the position

        rotateMatrix.SetRotationMatrix(angle); //sets the matrix to rotate with the angle


        transformMatrix.SetIdentity(); // sets the transformation matrix to identity matrix 
        transformMatrix = fromOriginMatrix * rotateMatrix * toOriginMatrix; // transformation matrix concatenates all the matrices 

        Transform();
    }

    private void Transform()
    {
        vertices = meshManager.clonedMesh.vertices; //get the cloned mesh vertices from the mesh manager

        for (int i = 0; i < vertices.Length; i++)
        {
                HVector2D vert = new HVector2D(vertices[i].x, vertices[i].y); // update the x and y values of the vertices 
                vert = transformMatrix * vert;
                vertices[i].x = vert.x;  //new value of the vertices x value
                vertices[i].y = vert.y;  //new value of the vertices y value
        }

        meshManager.clonedMesh.vertices = vertices; 
    }
}
