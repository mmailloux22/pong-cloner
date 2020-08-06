using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Paddle
{
    private string verticalControls;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    public float speed = 10;

    public Paddle(string controls, Rigidbody2D playerRigidBody) {
        verticalControls = controls;
        rb = playerRigidBody;
    }

    public void move() {
        Vector2 moveInput = new Vector2(0, Input.GetAxis(verticalControls));
        moveVelocity = moveInput * speed;
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}
