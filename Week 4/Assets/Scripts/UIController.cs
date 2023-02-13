using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public TMP_Text scoreText;
    public GameObject player;
    public GameObject animalSpawner;
    public GameObject loseScreen;
    public Image rightHeart;
    public Image middleHeart;
    public Image leftHeart;
    public static int score = 0;
    public static int heart = 3;

    private void Update()
    {
        UpdateScoreText();
        LoseHeartUI();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public static void WinScore()
    {
        score++;
    }

    public static void LoseHeart()
    {
        heart--;
    }

    private void LoseHeartUI()
    {
        if (heart == 2)
        {
            leftHeart.color = Color.black;
        }
        if (heart == 1)
        {
            middleHeart.color = Color.black;
        }
        if (heart == 0)
        {
            rightHeart.color = Color.black;
            GameOver();
        }
    }

    private void GameOver()
    {
        player.SetActive(false);
        loseScreen.SetActive(true);
        animalSpawner.SetActive(false);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(0);
        score = 0;
        heart = 3;
    }

}
