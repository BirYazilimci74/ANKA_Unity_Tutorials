using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMovement : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Transform[] transforms; // I will use this for everything that transform.
    [SerializeField] public float worldSpeed;
    [SerializeField] private UIController uiController;
    

    private void Update()
    {
        if (!uiController.isStart)
        {
            return;
        }
        Move();
    }

    private void Move()
    {
        if (gameManager.isGameOver)
        {
            return;
        }
        transform.position += Vector3.left * worldSpeed * Time.deltaTime;
        var transformLength = 2 * Mathf.Abs(transforms[0].position.x - transforms[1].position.x);
        
        foreach (var subTransform in transforms)
        {
            if (subTransform.position.x < -61)
            {
                subTransform.position += Vector3.right * transformLength; 
            }
        }
    }
}
