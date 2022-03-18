using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Ball ball;

    public static GameManager instance { private set; get; }

    public int score1, score2;    

    private void Awake()
    {
        if(instance)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Score(string tag)
    {
        if (tag == "Paddle_1")
            score2++;
        else
            score1++;

        ball.Launch();
    }
}
