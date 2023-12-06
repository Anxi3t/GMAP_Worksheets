using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    public Vector3 Velocity;

    void FixedUpdate()
    {
        float dt = Time.deltaTime;

        float dx = Velocity.x * dt; // calculates distance with the x velocity multiplying with time
        float dy = Velocity.y * dt; // calculates distance with the y velocity multiplying with time
        float dz = Velocity.z * dt; // calculates distance with the z velocity multiplying with time

        transform.Translate(new Vector3(dx, dy, dz)); // updates the pos of the ball
    }
}
