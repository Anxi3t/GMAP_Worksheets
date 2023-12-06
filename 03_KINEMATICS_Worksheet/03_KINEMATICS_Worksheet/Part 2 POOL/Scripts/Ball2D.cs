using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2D : MonoBehaviour
{
    public HVector2D Position = new HVector2D(0, 0);
    public HVector2D Velocity = new HVector2D(0, 0);
    
    [HideInInspector]
    public float Radius;

    private void Start()
    {
        Position.x = transform.position.x;
        Position.y = transform.position.y;

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Vector2 sprite_size = sprite.rect.size;
        Vector2 local_sprite_size = sprite_size / sprite.pixelsPerUnit;
        Radius = local_sprite_size.x / 2f;
    }

    public bool IsCollidingWith(float x, float y)
    {
        // using pythagoras theorem: c = square root of (a^2 + b^2)
        // use unity's Mathf
        // difference between the ball's position of x and y and the point at x and y
        // find the square of a: (x - Position.x)^2 
        // find the square of b: (y - p1.y)^2
        // square root of a^2 + b^2 to get c
        float distance = Mathf.Sqrt(Mathf.Pow(x - Position.x, 2f) + Mathf.Pow(y - Position.y, 2f));
        return distance <= Radius; //compare the distance with the ball's rad
    }

    public bool IsCollidingWith(Ball2D other)
    {
        float distance = Util.FindDistance(Position, other.Position);
        return distance <= Radius + other.Radius;
    }

    public void FixedUpdate()
    {
        UpdateBall2DPhysics(Time.deltaTime);
        Debug.Log("Ball Velocity: " + Velocity);
    }

    private void UpdateBall2DPhysics(float deltaTime)
    {
        float displacementX = Velocity.x * deltaTime; // calculates the displacement of the ball's x position
        float displacementY = Velocity.y * deltaTime; // calculates the displacement of the ball's y position

        Position.x += displacementX; // increments the x coordinate of the ball's pos by the displacement x
        Position.y += displacementY; // increments the y coordinate of the ball's pos by the displacement y

        transform.position = new Vector2(Position.x, Position.y); // updates the pos of the ball 
    }
}

