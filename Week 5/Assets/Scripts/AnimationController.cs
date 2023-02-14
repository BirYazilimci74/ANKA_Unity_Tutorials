using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private float speed;


    public void IDle()
    {
        playerAnimator.SetFloat("Speed_f", 0f);
    }
    
    public void Run()
    {
        playerAnimator.SetFloat("Speed_f", 1f);
    }

    public void Jump()
    {
        playerAnimator.SetTrigger("Jump_trig");
    }

    public void Death()
    {
        playerAnimator.SetBool("Death_b",true);
    }
}
