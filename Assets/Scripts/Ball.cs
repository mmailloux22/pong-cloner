using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball
{
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    public float speed = 10f;

    public Ball(Rigidbody2D ballRigidBody){
        rb = ballRigidBody;
    }

    public void move(){
        Vector2 moveDirection = new Vector2(30, speed);
        moveVelocity = moveDirection;
        rb.AddForce(moveVelocity);
    }
}
