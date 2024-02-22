using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class Ball : MonoBehaviour
{
    public Transform kickoffSpot;
    Rigidbody2D rb;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
            Controller.UpdateScore(Controller.score + 1, scoreText);
            transform.position = kickoffSpot.position;
            rb.velocity = Vector2.zero;
    }
}
