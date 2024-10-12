using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;

    public AudioClip jumpSound;
    public AudioClip landSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("jump_trig");
        }
    }

    public void PlayJumpSound(AnimationEvent animationEvent)
    {
        Debug.Log("Play jump sound");
        playerAudio.PlayOneShot(jumpSound, 2.0f);
    }

    public void PlayLandSound(AnimationEvent animationEvent)
    {
        Debug.Log("Play land sound");
        playerAudio.PlayOneShot(landSound, 1.0f);

    }

    public void PrintEvent(string s)
    {
        Debug.Log("PrintEvent called at " + Time.time + " with a value of " + s);
    }

}
