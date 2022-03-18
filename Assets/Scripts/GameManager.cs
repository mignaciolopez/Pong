using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Ball ball;
    [SerializeField] PaddleController paddle1;
    [SerializeField] PaddleController paddle2;

    public static GameManager instance { private set; get; }

    [HideInInspector] public int score1, score2;    

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

        Restart();
    }

    public void Restart()
    {
        ball.Launch();
        paddle1.RestartPosition();
        paddle2.RestartPosition();
    }
}
