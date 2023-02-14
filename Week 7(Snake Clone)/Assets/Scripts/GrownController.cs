using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrownController : MonoBehaviour
{
    [SerializeField] private PlayerCotroller playerCotroller;
    public List<GameObject> snake = new List<GameObject>();
    [SerializeField] private GameObject tail;
    
    private void Awake()
    {
        snake.Add(playerCotroller.gameObject);
    }

    public void TailMove()
    {
        for (int i = snake.Count-1; i > 0; i--)
        {
            snake[i].transform.position = snake[i - 1].transform.position;
        }
    }

    public void Grown()
    {
        GameObject newTail = Instantiate(tail, snake[^1].transform.position, Quaternion.identity);
        snake.Add(newTail);
        snake[1].GetComponent<Collider2D>().enabled = false;
    }
}
