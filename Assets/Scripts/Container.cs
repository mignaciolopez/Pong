using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.position.x > 0)
            GameManager.instance.Score("Paddle_2");
        else if(collision.transform.position.x < 0)
            GameManager.instance.Score("Paddle_1");
        else
            GameManager.instance.Restart();
    }
}
