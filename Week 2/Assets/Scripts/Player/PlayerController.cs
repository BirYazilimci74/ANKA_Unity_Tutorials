using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Speeds")]
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;
    
    [Header("Screens")]
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;

    private float vertical;
    private float horizontal;
    private bool isFinish;
    
    void Update()
    {
        if (isFinish)
        {
            return;
        }
        Movement();
        End();
    }

    private void End()
    {
        if(transform.position.y < -5)
        {
            loseScreen.SetActive(true);
            isFinish = true;
        }
        else if(transform.position.z > 150)
        {
            winScreen.SetActive(true);
            isFinish = true;
        }
    }
    
    private void Movement()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        
        transform.Translate(Vector3.forward * speed * Time.deltaTime * vertical);
        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * horizontal * vertical);
    }
    
    public void PlayAgain()
    {
        isFinish = false;
        SceneManager.LoadScene(0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            loseScreen.SetActive(true);
        }
    }
}