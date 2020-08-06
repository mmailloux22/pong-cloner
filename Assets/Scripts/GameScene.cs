using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    private Paddle playerOnePaddle;
    private Paddle playerTwoPaddle;
    private Rigidbody2D rbPlayerOne;
    private Rigidbody2D rbPlayerTwo;

    void Awake() {
        GameObject playerOne = GameObject.Find("PlayerOne");
        GameObject playerTwo = GameObject.Find("PlayerTwo");

        rbPlayerOne = playerOne.GetComponent<Rigidbody2D>();
        rbPlayerTwo = playerTwo.GetComponent<Rigidbody2D>();
        playerOnePaddle = new Paddle("VerticalPlayerOne", rbPlayerOne);
        playerTwoPaddle = new Paddle("VerticalPlayerTwo", rbPlayerTwo);
    }

    void FixedUpdate()
    {
        playerOnePaddle.move();
        playerTwoPaddle.move();
    }
}
