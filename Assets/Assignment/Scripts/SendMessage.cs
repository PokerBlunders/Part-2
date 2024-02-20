using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class SendMessage : MonoBehaviour
{
    public GameObject CollectedItem;
    bool collected = false;

    public void Update()
    {
        if (CollectedItem.activeInHierarchy == false && collected == false)
        {
            SendMessage("ItemsCollected", CollectedItem.name);
            collected = true;
        }
    }
}
