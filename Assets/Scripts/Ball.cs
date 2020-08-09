using System;
using Random = System.Random;
using Debug = UnityEngine.Debug;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Diagnostics;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform tr;
    private SpriteRenderer sr;
    private Random rnd;
    private float horizontal;
    private float vertical;
    private Vector2 moveVelocity;
    private TextMeshProUGUI scoreText1;
    private TextMeshProUGUI scoreText2;
    private TextMeshProUGUI winText;
    private int score1;
    private int score2;
    public float speed;
    public GameObject winTextObject;
    public GameObject scoreTextObjectOne;
    public GameObject scoreTextObjectTwo;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();
        scoreText1 = scoreTextObjectOne.GetComponent<TextMeshProUGUI>();
        scoreText2 = scoreTextObjectTwo.GetComponent<TextMeshProUGUI>();
        winText = winTextObject.GetComponent<TextMeshProUGUI>();
        rnd = new Random();
        startBall();
    }

    public void startBall(){
        while (horizontal == 0 || vertical == 0) {
            horizontal = (float)(rnd.Next(-1, 2));
            vertical = (float)(rnd.Next(-1, 2));
        }
        Vector2 moveDirection = new Vector2(horizontal, vertical);
        moveVelocity = moveDirection * speed;
        rb.AddForce(moveVelocity);
    }


    void ResetBall()
    {
        rb.velocity = Vector2.zero;
        tr.position = Vector2.zero;
        horizontal = 0;
        vertical = 0;
        sr.color = Color.black;
    }

    void RestartGame()
    {
        ResetBall();
        Invoke("startBall", 1);
    }

    void OnCollisionEnter2D(Collision2D coll) {
        
        if (coll.gameObject.name == "PlayerTwo")
        {
            SoundManagerScript.PlaySound("hitPaddle");
            sr.color = Color.blue;
            speedIncrease();
        }
        else if (coll.gameObject.name == "PlayerOne")
        {
            SoundManagerScript.PlaySound("hitPaddle");
            sr.color = Color.red;
            speedIncrease();
        }
        else if (coll.gameObject.name == "borders")
        {
            SoundManagerScript.PlaySound("wallSound");
        }
    }

    void speedIncrease() {
        float speedBoost = 1.2f;
        rb.velocity *= speedBoost;
    }

    void FixedUpdate() {
        if (score1 >= 11 && Mathf.Abs((float)(score1 - score2)) >= 2)
        {
            Time.timeScale = 0;
            winText.text = "Red Wins!";
            winText.color = Color.red;
        }
        else if (score2 >= 11 && Mathf.Abs((float)(score1 - score2)) >= 2)
        {
            Time.timeScale = 0;
            winText.text = "Blue Wins!";
            winText.color = Color.blue;
        }
        if (tr.position.x > 9) {
            SoundManagerScript.PlaySound("increaseScore");
            score1++;
            scoreText1.text = score1.ToString();
            RestartGame();
        } else if (tr.position.x < -9) {
            SoundManagerScript.PlaySound("increaseScore");
            score2++;
            scoreText2.text = score2.ToString();
            RestartGame();
        }
    }
}
