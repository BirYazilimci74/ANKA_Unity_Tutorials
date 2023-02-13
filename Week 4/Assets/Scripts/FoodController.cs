using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    public float speed;
    public float destroyRange;

    private void Update()
    {
        Move();
        DestroyFood();
    }
    
    
    private void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void DestroyFood()
    {
        if (transform.position.z > destroyRange)
        {
            Destroy(gameObject);
        }
    }
}
