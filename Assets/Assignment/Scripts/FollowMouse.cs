using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public float speed = 2f;
    public float stopDistance = 0.5f;
    float angle;
    float distanceToMouse;
    Vector2 mousePosition;
    Vector2 direction;

    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        direction = (Vector2)mousePosition - (Vector2)transform.position;

        distanceToMouse = direction.magnitude;

        if(distanceToMouse > stopDistance)
        {
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle + 25, Vector3.forward);
            transform.position = Vector2.MoveTowards(transform.position, mousePosition, speed * Time.deltaTime);
        }
    }
}
