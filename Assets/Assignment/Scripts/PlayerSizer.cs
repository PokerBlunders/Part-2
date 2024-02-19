using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Schema;

public class PlayerSizer : MonoBehaviour
{
    public Slider scaleSlider;
    public Transform playerTransform;

    public void ChangeSize()
    {
        float newScale = scaleSlider.value;
        playerTransform.localScale = new Vector2(newScale, newScale);
    }
}
