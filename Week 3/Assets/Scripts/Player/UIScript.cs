using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public GameObject gameOverScreen;
    public void tryAgain()
    {
        gameOverScreen.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
