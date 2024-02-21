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
    Rigidbody2D rb;
    float speed = 50;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
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

    public void Move(Vector2 direction)
    {
        rb.AddForce(direction * speed, ForceMode2D.Impulse);
    }
}
