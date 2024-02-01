using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> prefabs;
    float spawnTime = 1f;
    float lastSpawn = 0f;

    public float warningThreshold = 2.0f;

    List<GameObject> spawnedPlanes = new List<GameObject>();
    List<GameObject> planesToDestroy = new List<GameObject>();

    void Update()
    {
        lastSpawn += Time.deltaTime;
        if(lastSpawn >= spawnTime)
        {
            SpawnPlanes();
            lastSpawn = 0f;
            spawnTime = Random.Range(1f, 5f);
        }

        CheckPlaneDistance();
    }

    void SpawnPlanes()
    {
        int rangeRandom = Random.Range(0, prefabs.Count);
        Vector3 positionRandom = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
        Quaternion rotationRandom = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

        GameObject newPlane = Instantiate(prefabs[rangeRandom], positionRandom, rotationRandom);
        spawnedPlanes.Add(newPlane);
    }

    void CheckPlaneDistance()
    {
        planesToDestroy.Clear();

        for (int i = 0; i < spawnedPlanes.Count; i++)
        {
            for (int j = i + 1; j < spawnedPlanes.Count; j++)
            {
                float distance = Vector3.Distance(spawnedPlanes[i].transform.position, spawnedPlanes[j].transform.position);

                if (distance < warningThreshold)
                {
                    Debug.Log("WARNING: Planes are too close!!");
                    if(distance < 0.5f)
                    {
                        planesToDestroy.Add(spawnedPlanes[i]);
                        planesToDestroy.Add(spawnedPlanes[j]);
                    }
                }
            }
        }

        foreach (GameObject plane in planesToDestroy)
        {
            spawnedPlanes.Remove(plane);
            Destroy(plane);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
