using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] public float spawnRate;
    
    
    private void Start()
    {
        StartCoroutine(CreatObstacle());
    }
    
    private IEnumerator CreatObstacle()
    {
        while (true)
        {
            Instantiate(obstacles[RandomInt(0, obstacles.Length)], transform.position, transform.rotation);
            yield return new WaitForSeconds(spawnRate);
            if (gameManager.isGameOver)
            {
                break;
            }
        }
    }
    
    private int RandomInt(int min, int max) // to create random int value
    {
        int num;
        num = Random.Range(min, max);
        return num;
    }
}
