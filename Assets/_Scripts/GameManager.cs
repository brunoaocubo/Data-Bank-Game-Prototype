using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToSpawn;
    [SerializeField] private float spawnInterval = 10f;
    [SerializeField] private int objectsPerSpawn = 1;
    [SerializeField] private int spawnWaves = 5;

    private float timer = 0f;

    private void Update()
    {
        if(spawnWaves > 0) 
        {
            timer += Time.deltaTime;

            if (timer >= spawnInterval)
            {
                SpawnObjects();
                timer = 0f;
                spawnWaves--;
            }
        }
    }

    private void SpawnObjects()
    {
        for (int i = 0; i < objectsPerSpawn; i++)
        {
            int randomIndex = Random.Range(0, objectsToSpawn.Length);
            Vector3 randomPos = new Vector3(Random.Range(-20f, 15f), 5, Random.Range(-20f, 15f));

            Instantiate(objectsToSpawn[randomIndex], randomPos, Quaternion.identity);
        }
    }
}
