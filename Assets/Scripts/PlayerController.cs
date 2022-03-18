using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] KeyCode up;
    [SerializeField] KeyCode down;

    [SerializeField] float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(up))
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else if(Input.GetKey(down))
        {
            transform.Translate(Vector2.up * -speed * Time.deltaTime);
        }
    }
}
