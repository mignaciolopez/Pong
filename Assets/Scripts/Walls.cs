using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioSource.Play();
        GameManager.instance.Score(tag);
    }
}
