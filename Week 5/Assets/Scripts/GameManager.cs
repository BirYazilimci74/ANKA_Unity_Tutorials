using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private EffectManager effectManager;
    [SerializeField] private WorldMovement worldMovement;
    [SerializeField] private UIController uiController;
    [SerializeField] private ObstaclesController[] oC;
    public bool isGameOver;
    
    private void Start()
    {
        foreach (var obstacles in oC)
        {
            obstacles.obstacleSpeed = 7;
        }
        //oC[0].obstacleSpeed = 7;
        //oC[1].obstacleSpeed = 7;
        //oC[2].obstacleSpeed = 7;
        //oC[3].obstacleSpeed = 7;
        effectManager.ParticalsActive();
    }

    private void Update()
    {
        Difficulty();
    }
    
    private void Difficulty()
    {
        if (uiController.score % 100 == 0)
        {
            worldMovement.worldSpeed += 2;
            foreach (var obstacles in oC)
            {
                obstacles.obstacleSpeed = worldMovement.worldSpeed;
            }
            //oC[0].obstacleSpeed = worldMovement.worldSpeed;
            //oC[1].obstacleSpeed = worldMovement.worldSpeed;
            //oC[2].obstacleSpeed = worldMovement.worldSpeed;
            //oC[3].obstacleSpeed = worldMovement.worldSpeed;
            uiController.score++;
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }
}