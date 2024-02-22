using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalkeeperController : MonoBehaviour
{
    public Rigidbody2D GoalkeeperRb;
    public Transform goalCenter;
    public float maxDistance = 3f;
    public float speed = 5f;

    private Vector2 targetPosition;

    private void Start()
    {
        targetPosition = GoalkeeperRb.position;
    }

    void Update()
    {
        if (Controller.CurrentSelection != null)
        {
            Vector2 playerPosition = Controller.CurrentSelection.transform.position;
            targetPosition = GetGoalkeeperPosition(playerPosition);
        }
        Vector2 currentPosition = GoalkeeperRb.position;
        GoalkeeperRb.MovePosition(Vector2.MoveTowards(currentPosition, targetPosition, speed * Time.deltaTime));
    }

    Vector2 GetGoalkeeperPosition(Vector2 playerPosition)
    {
        Vector2 goalLineCenter = goalCenter.position;
        Vector2 midpoint = (playerPosition + goalLineCenter) / 2f;
        Vector2 toMidpoint = midpoint - goalLineCenter;
        Vector2 goalkeeperPosition = goalLineCenter + Vector2.ClampMagnitude(toMidpoint, maxDistance);
        return goalkeeperPosition;
    }
}
