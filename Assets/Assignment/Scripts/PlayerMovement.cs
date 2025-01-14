using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public Animator animator;
    public Vector2 destination;
    public Vector2 movement;
    public float speed = 3;
    public AnimationCurve slowdown;
    float timer;
    Transform playerTransform;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerTransform = GetComponent<Transform>();

        destination = new Vector2(transform.position.x, 0f);
    }

    private void FixedUpdate()
    {
        movement = destination - (Vector2)transform.position;

        if (movement.magnitude < 1)
        {
            timer = 1f * Time.deltaTime;
            float interpolation = slowdown.Evaluate(timer);
            rb.MovePosition(Vector2.Lerp(rb.position, destination, interpolation));
        }
        if (movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
        }
        else
        {
            rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            destination.y = destination.y + (playerTransform.localScale.y/2);
        }
       
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
        }
    }
}