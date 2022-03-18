using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public void Awake()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(Random.Range(-2f, 2f), Random.Range(-1f, 1f));
    }
}
