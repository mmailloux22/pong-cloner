using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    private Paddle playerOnePaddle;
    private Paddle playerTwoPaddle;
    private Ball ball;
    private Rigidbody2D rbPlayerOne;
    private Rigidbody2D rbPlayerTwo;
    private Rigidbody2D rbBall;

    void Awake() {
        GameObject playerOne = GameObject.Find("PlayerOne");
        GameObject playerTwo = GameObject.Find("PlayerTwo");

        rbPlayerOne = playerOne.GetComponent<Rigidbody2D>();
        rbPlayerTwo = playerTwo.GetComponent<Rigidbody2D>();
        playerOnePaddle = new Paddle("VerticalPlayerOne", rbPlayerOne);
        playerTwoPaddle = new Paddle("VerticalPlayerTwo", rbPlayerTwo);

        GameObject pongBall = GameObject.Find("Ball");
        rbBall = pongBall.GetComponent<Rigidbody2D>();
        ball = new Ball(rbBall);
        ball.move();
    }

    void Start() {
        
    }

    void FixedUpdate()
    {
        playerOnePaddle.move();
        playerTwoPaddle.move();
    }
}
