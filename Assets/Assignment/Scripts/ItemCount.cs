using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCount : MonoBehaviour
{
    public void ItemsCollected(string itemName)
    {
        Debug.Log(itemName + " Collected!");
    }
}
