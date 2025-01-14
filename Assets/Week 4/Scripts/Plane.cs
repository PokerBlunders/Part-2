using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public List<Vector2> points;
    public float newPointThreshold = 0.2f;
    Vector2 lastPosition;
    LineRenderer lineRenderer;
    Vector2 currentPosition;
    Rigidbody2D rb;
    float speed;
    public AnimationCurve landing;
    float landingTimer;
    SpriteRenderer spriteRenderer;

    bool isLanding = false;
    private Collider2D runwayCollider;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);

        rb = GetComponent<Rigidbody2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        speed = Random.Range(1, 3);

        runwayCollider = FindAnyObjectByType<Collider2D>();
    }

    private void FixedUpdate()
    {
        currentPosition = transform.position;

        if (isLanding)
        {
            landingTimer += 0.1f * Time.deltaTime;
            float interpolation = landing.Evaluate(landingTimer);

            if (transform.localScale.x < 1f)
            {
                Destroy(gameObject);
            }

            transform.localScale = Vector3.Lerp(new Vector3(4,4,0), Vector3.zero, interpolation);
            rb.MovePosition(rb.position + (Vector2)transform.up/2 * Time.deltaTime);
        }
        else
        {

            if (points.Count > 0)
            {
                Vector2 direction = points[0] - currentPosition;
                float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
                rb.rotation = -angle;
            }
            rb.MovePosition(rb.position + (Vector2)transform.up * speed * Time.deltaTime);
        }
    }

    private void Update()
    {

        /*   if(Input.GetKey(KeyCode.Space))
           {
               landingTimer += 0.1f * Time.deltaTime;
               float interpolation = landing.Evaluate(landingTimer);
               if (transform.localScale.x < 0.1f)
               {
                   Destroy(gameObject);
               }
               transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, interpolation);
           } */

        if (IsInsideRunwayCollider())
        {
            isLanding = true;
        }

        lineRenderer.SetPosition(0, transform.position);
        if(points.Count > 0)
        {
            if (Vector2.Distance(currentPosition, points[0]) < newPointThreshold)
            {
                points.RemoveAt(0);

                for (int i = 0; i < lineRenderer.positionCount - 1; i++)
                {
                    lineRenderer.SetPosition(i, lineRenderer.GetPosition(i+1));
                }
                lineRenderer.positionCount = Mathf.Max(1, lineRenderer.positionCount - 1);
            }
        }
    }
    private bool IsInsideRunwayCollider()
    {
        return runwayCollider.OverlapPoint(transform.position);
    }

    private void OnMouseDown()
    {
        points = new List<Vector2>();
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        points.Add(newPosition);
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }

    private void OnMouseDrag()
    {
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Vector2.Distance(lastPosition, newPosition) > newPointThreshold)
        {
            points.Add(newPosition);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPosition);
            lastPosition = newPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spriteRenderer.color = Color.red;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteRenderer.color = Color.white;
    }
}
