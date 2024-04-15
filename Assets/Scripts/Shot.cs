using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public float speed = 200.0f;

    Rigidbody2D rb;

    void Start()
    {
        Destroy(gameObject, 5.0f);
    }

    public void SetVelocity(Vector2 vec)
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }

        rb.velocity = vec;
    }
}
