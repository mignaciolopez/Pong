using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] 
public class Ball : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] float initialSpeed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Launch();
    }

    public void Launch()
    {
        transform.position = Vector3.zero;

        Vector2 randomVel = Vector2.zero;
        randomVel.x = Random.Range(0, 2) == 0 ? 1 : -1;
        randomVel.y = Random.Range(0, 2) == 0 ? 1 : -1;

        rb.velocity = randomVel * initialSpeed;
    }
}
