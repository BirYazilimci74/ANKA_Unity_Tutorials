using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCotroller : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private AppleController appleController;
    [SerializeField] private GrownController grownController;
    [SerializeField] private GameObject finishScreen;
    
    private Vector3 diraction;
    private Vector3 wantedDirection;

    private void Start()
    {
        finishScreen.SetActive(false);
        wantedDirection = Vector3.up;
        StartCoroutine(Move());
    }

    private void Update()
    {
        ChangeDiraction();
    }

    private IEnumerator Move()
    {
        while (true)
        {
            yield return new WaitForSeconds(1 / speed);
            
            grownController.TailMove();
            diraction = wantedDirection;
            transform.position += diraction;
        }
    }
    
    private void ChangeDiraction()
    {
        if (Input.GetKeyDown(KeyCode.W) && diraction != Vector3.down)
        {
            wantedDirection = Vector3.up;
        }
        else if (Input.GetKeyDown(KeyCode.A) && diraction != Vector3.right)
        {
            wantedDirection = Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.S) && diraction != Vector3.up)
        {
            wantedDirection = Vector3.down;
        }
        else if (Input.GetKeyDown(KeyCode.D) && diraction != Vector3.left)
        {
            wantedDirection = Vector3.right;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Apple"))
        {
            grownController.Grown();
            appleController.RePosition();
            appleController.EarnPoint();
        }
        else if (col.CompareTag("Wall") || col.CompareTag("Tail"))
        {
            finishScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
