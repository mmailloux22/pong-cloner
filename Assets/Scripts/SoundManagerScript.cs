using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip ballHitPaddleSound, increaseScoreSound, ballBounceOffWallSound;
    static AudioSource audioSrc;

    void Awake() 
    {
        ballHitPaddleSound = Resources.Load<AudioClip>("phaserUp2");
        increaseScoreSound = Resources.Load<AudioClip>("zap1");
        ballBounceOffWallSound = Resources.Load<AudioClip>("phaserDown2");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip) 
    {
        switch(clip)
        {
            case "hitPaddle":
                audioSrc.PlayOneShot(ballHitPaddleSound);
                break;
            case "increaseScore":
                audioSrc.PlayOneShot(increaseScoreSound);
                break;
            case "wallSound":
                audioSrc.PlayOneShot(ballBounceOffWallSound);
                break;
        }
    }
}
