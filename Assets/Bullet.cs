using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Range(0, 100)]
    public float speed = 10f;

    [Range(0.01f, 10)]
    public float lifeTime = 3f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
    }
    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }
}
