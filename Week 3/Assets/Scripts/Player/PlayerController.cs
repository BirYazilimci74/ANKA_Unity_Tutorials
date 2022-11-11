using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public CinemachineVirtualCamera playerFollower, FPSCamera;
    public TMP_Text currentScore, bestScore, coinCounter;
    public GameObject gameOverScreen, Player;
    public float moveSpeed, rotateSpeed;
    public Rigidbody body;
    private int coinCount, best_Score;
    private bool isFPS = false;
    private void Start()
    {
        gameOverScreen.SetActive(false);
        coinCount = 0;
        coinCounter.text = "Coin : " + coinCount.ToString();
    }

    private void Update()
    {
        Movement();
        Rotation();
        HandleCamera();
        best_Score = PlayerPrefs.GetInt("BestCoinScore", coinCount);
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            body.velocity = transform.forward * moveSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            body.velocity = Vector3.zero;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            body.velocity = -transform.forward * moveSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            body.velocity = Vector3.zero;
        }
    }

    private void Rotation()
    {
        if (Input.GetKey(KeyCode.W))
        {
            body.angularVelocity = -transform.right * (rotateSpeed * Time.deltaTime);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            body.angularVelocity = Vector3.zero;
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            body.angularVelocity = transform.right * (rotateSpeed * Time.deltaTime);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            body.angularVelocity = Vector3.zero;
        }
    }

    private void HandleCamera()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            isFPS = !isFPS;
            if (isFPS)
            {
                FPSCamera.Priority = 1;
                playerFollower.Priority = 0;
            }
            else
            {
                FPSCamera.Priority = 0;
                playerFollower.Priority = 1;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            Player.SetActive(false);
            gameOverScreen.SetActive(true);
            currentScore.text = "Current Coin : " + coinCount.ToString();
            bestScore.text = "Best Coin : " + best_Score.ToString();
        }
    }

    private void OnTriggerEnter(Collider other) //if the object is trigger.
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coinCount++;
            coinCounter.text = "Coin : " + coinCount.ToString();
            if (coinCount > best_Score)
                PlayerPrefs.SetInt("BestCoinScore",coinCount);
        }
    }

    
}
