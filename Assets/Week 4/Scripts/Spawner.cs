using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> prefabs;
    float spawnTime = 1f;
    float lastSpawn = 0f;

    void Update()
    {
        lastSpawn += Time.deltaTime;
        if(lastSpawn >= spawnTime)
        {
            SpawnPlanes();
            lastSpawn = 0f;
            spawnTime = Random.Range(1f, 5f);
        }
    }

    void SpawnPlanes()
    {
        int rangeRandom = Random.Range(0, prefabs.Count);
        Vector3 positionRandom = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
        Quaternion rotationRandom = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

        Instantiate(prefabs[rangeRandom], positionRandom, rotationRandom);
    }
}
