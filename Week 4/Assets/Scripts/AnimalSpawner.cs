using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class AnimalSpawner : MonoBehaviour
{
    public GameObject[] animals;
    public float range;
    public float yPos;
    public float zPos;
    public float spawnPerSecond;
    public float minSpawnRate;
    
    private void Start()
    {
        StartCoroutine(AnimalSpawn());
    }

    private IEnumerator AnimalSpawn()
    {
        int counter = 0;
        while (true)
        {
            counter++;
            if (counter % 5 == 0 && spawnPerSecond > minSpawnRate)
            {
                spawnPerSecond -= spawnPerSecond / 5;
            }
            int randomAnimal = Random.Range(0, animals.Length);
            Instantiate(animals[randomAnimal], RandomPosition(),animals[randomAnimal].transform.rotation);

            yield return new WaitForSeconds(spawnPerSecond);
        }
    }

    private Vector3 RandomPosition()
    {
        float randomx = Random.Range(-range, range);
        Vector3 spawnPosition = new Vector3(randomx, yPos, zPos);
        return spawnPosition;
    }
    
    
}
