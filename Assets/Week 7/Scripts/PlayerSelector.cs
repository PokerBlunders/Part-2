using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    public Color selectedColor;
    public Color unselectedColor;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Selected(false);
    }
    private void OnMouseDown()
    {
        Controller.SetCurrentSelection(this);
    }
    public void Selected(bool selected)
    {
        if (selected == true)
        {
            spriteRenderer.color = selectedColor;
        }
        else
        {
            spriteRenderer.color = unselectedColor;
        }
    }
}
