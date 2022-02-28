using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip ballMovementSound;
    public AudioClip buttonSound;
    public AudioClip gameOverSound;
    private AudioSource audioSrc;
    
    void Awake()
    {
        //ballMovementSound = Resources.Load<AudioClip>("moveSound2");
        Debug.Log("ismi: "+ballMovementSound.name);
        //buttonSound = Resources.Load<AudioClip>("buttonClick");
        //gameOverSound = Resources.Load<AudioClip>("gameOverSound");
        audioSrc = GetComponent<AudioSource>();

    }
    void Update()
    {
        
    }

    public void playSounds(string clip)
    {
        switch (clip)
        {
            case "moveSound2":
                audioSrc.PlayOneShot(ballMovementSound);
                break;
            case "buttonClick":
                audioSrc.PlayOneShot(buttonSound);
                break;
            case "gameOverSound":
                audioSrc.PlayOneShot(gameOverSound);
                break;
        }
    }

 
}
