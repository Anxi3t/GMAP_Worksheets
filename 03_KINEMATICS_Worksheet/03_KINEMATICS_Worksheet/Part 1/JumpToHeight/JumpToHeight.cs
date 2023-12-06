using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpToHeight : MonoBehaviour
{
    public float Height = 1f;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Jump()
    {
        // v*v = u*u + 2as
        // u*u = v*v - 2as
        // u = sqrt(v*v - 2as)
        // v = 0, u = ?, a = Physics.gravity, s = Height

        // using u = sqrt(v*v - 2as) to calculate the jump height
        // use Physics.gravity.y as the acceleration and the var Height as the displacement
        float u = Mathf.Sqrt(-2 * Physics.gravity.y * Height); 
        rb.velocity = new Vector3(0, u, 0); // update the y coordinates to jump

        //float jumpForce = Mathf.Sqrt(-2 * Physics2D.gravity.y * Height);
        //rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
}

