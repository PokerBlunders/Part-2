using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSpawner : MonoBehaviour
{
    public GameObject prefab;

    public void SpawnWeapon()
    {
        Instantiate(prefab);
    }
}
