using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsController : MonoBehaviour
{
    public float speed;
    public float destroyRange;

    private void Update()
    {
        Move();
        DestroyAnimal();
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            
            Destroy(other.gameObject);
            Destroy(gameObject);
            UIController.WinScore();
        }
    }

    private void DestroyAnimal()
    {
        if (transform.position.z < destroyRange)
        {
            Destroy(gameObject);
            UIController.LoseHeart();
        }
    }
}
