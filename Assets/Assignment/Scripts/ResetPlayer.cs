using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayer : MonoBehaviour
{
    Vector2 startPosition;
    public Transform playerTransform;
    public PlayerMovement playerMovement;

    private void Start()
    {
        startPosition = new Vector2(0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerTransform.position = startPosition;
        playerMovement.destination = startPosition;
    }
}
