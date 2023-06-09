using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Collider areaSpawnObject;
    [SerializeField] private GameObject[] objectsToSpawn;

    private void Start()
    {
        var bounds = areaSpawnObject.bounds.size;
        float randomX = Random.Range(-bounds.x, +bounds.x);
        float randomZ = Random.Range(-bounds.z, +bounds.z);
        Vector3 randomPos = new Vector3(randomX, areaSpawnObject.transform.position.y,randomZ);

        for (int i = 0; i < objectsToSpawn.Length; i++)
        {
            Instantiate(objectsToSpawn[i], randomPos, Quaternion.identity);
        }     
    }
}
