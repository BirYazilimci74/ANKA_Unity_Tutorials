using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SearchService;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float range;
    public GameObject food;

    private void Update()
    {
        StayInRange();
        Move();
        ThrowFood();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

    private void StayInRange()
    {
        if (transform.position.x > range)
        {
            transform.position = new Vector3(range,transform.position.y,transform.position.z);
        }
        else if (transform.position.x < -range)
        {
            transform.position = new Vector3(-range,transform.position.y,transform.position.z);
        }
    }

    private void ThrowFood()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(food, transform.position, transform.rotation);
        }
    }

    public void GameOver()
    {
        speed = 0f;
    }
}