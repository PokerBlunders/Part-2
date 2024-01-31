using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> prefabs;
    public float timeDelay;

    private void Start()
    {
        timeDelay = Random.Range(1, 5);
    }

    void Update()
    {
        Instantiate(prefabs[0]);
    }
}
