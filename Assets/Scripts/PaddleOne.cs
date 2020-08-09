using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleOne : MonoBehaviour
{
    private string verticalControls;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    public float speed = 12;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        verticalControls = "VerticalPlayerOne";
    }

    public void move() {
        Vector2 moveInput = new Vector2(0, Input.GetAxisRaw(verticalControls));
        moveVelocity = moveInput * speed;
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    void FixedUpdate()
    {
        move();
    }
}
