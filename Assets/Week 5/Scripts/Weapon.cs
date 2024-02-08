using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float destroyTimer = 3f;

    private void Start()
    {
        rb= GetComponent<Rigidbody2D>();

        rb.velocity = Vector2.right * speed;

        Destroy(gameObject, destroyTimer);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SendMessage("TakeDamage", 1, SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }
}
