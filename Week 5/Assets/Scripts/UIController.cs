using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private WorldMovement worldMovement;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] public int score = 1;
    
    public GameObject startScreen, finishScreen;
    public bool isStart = false;
    private int counter = 1;

    private void Start()
    {
        startScreen.SetActive(true);
        finishScreen.SetActive(false);
    }

    private void Update()
    {
        if (!isStart)
        {
            return;
        }
        ScoreSpeed();
    }

    private void ScoreSpeed()
    {
        if (gameManager.isGameOver)
        {
            return;
        }
        counter++;
        if (counter % 10 == 0 && worldMovement.worldSpeed != 0)
        {
            WinScore();
        }
    }
    
    private void WinScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void IsStart()
    {
        startScreen.SetActive(false);
        isStart = true;
    }
}
