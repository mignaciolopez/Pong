using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] 
public class Ball : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] AudioSource audioSource;

    [SerializeField] float initialSpeed = 5f;
    [SerializeField] float maxSpeed = 15f;
    [SerializeField] float forceMagnitude = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameManager.instance.Restart();
    }

    public void Launch()
    {
        rb.position = Vector2.zero;
        rb.velocity = Vector2.zero;

        Vector2 randomVel = Vector2.zero;
        randomVel.x = Random.Range(0, 2) == 0 ? 1 : -1;
        randomVel.y = Random.Range(0, 2) == 0 ? 1 : -1;

        randomVel.x *= initialSpeed;
        //randomVel.y *= initialSpeed / 2.0f;

        rb.velocity = randomVel;
    }

    private void FixedUpdate()
    {
        if (rb.velocity.x > maxSpeed)
        {
            Vector2 vel = rb.velocity;
            vel.x *= 0.8f;
            rb.velocity = vel;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            if (audioSource.isPlaying)
                audioSource.Stop();

            audioSource.Play();
            ContactPoint2D contact = collision.GetContact(0);
            Vector2 localPosition = collision.gameObject.transform.InverseTransformPoint(contact.point);
            
            rb.AddForce(transform.up * localPosition.y * forceMagnitude, ForceMode2D.Impulse);
        }
    }
}
