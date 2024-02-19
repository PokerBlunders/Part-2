using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public GameObject item;
    public GameObject itemPic;

    void OnTriggerStay2D(Collider2D collision)
        {
        if (Input.GetMouseButtonDown(1))
            {
            item.SetActive(false);
            SetItemImageActive();
            }
        }

    public void SetItemImageActive()
    {
        itemPic.SetActive(true);
    }
}
