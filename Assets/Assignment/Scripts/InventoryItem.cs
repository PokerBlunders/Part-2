using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public GameObject item;
    Image image;

    public void SetItemImageActive()
    {
        if (item.activeInHierarchy)
        {
            item.SetActive(true);
        }
        else
        {
            item.SetActive(false);
        }
    }
}
