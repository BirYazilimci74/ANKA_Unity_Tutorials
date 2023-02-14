using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem bombEffect, particals;
    [SerializeField] private GameManager gameManager;

    private void Update()
    {
        if (gameManager.isGameOver)
        {
            ParticalsDeactive();
        }
    }

    public void ParticalsActive()
    {
        particals.Play();
    }

    public void ParticalsDeactive()
    {
        particals.Stop();
    }
    
    public void BombEffectActive()
    {
        if (gameManager.isGameOver)
        {
            bombEffect.Play();
        }
    }

}
