using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioSource audioJump, audioCrash;

    public void PlayJumpSound()
    {
        audioJump.Play();
    }

    public void PlayCrashSound()
    {
        audioCrash.Play();
    }
    
}
