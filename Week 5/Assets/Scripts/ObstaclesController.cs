using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class ObstaclesController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] public float obstacleSpeed;
    UIController uiController;
    
    private void Awake()
    {
        uiController = FindObjectOfType<UIController>() ;
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (!uiController.isStart)
        {
            return;
        }
        Move();
        DestroyObstacle();
    }
    
    private void Move()
    {
        if (gameManager.isGameOver)
        {
            return;
        }
        transform.Translate(Vector3.left * obstacleSpeed * Time.deltaTime);
    }

    private void DestroyObstacle()
    {
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }

}