using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Ball ball;
    PaddleController paddle1;
    PaddleController paddle2;

    private static GameManager m_instance = null;

    public enum GameMode
    {
        pvp = 0,
        vsComp
    } 
    GameMode gameMode;

    public static GameManager instance
    {
        private set { }

        get
        {
            return m_instance;
        }
    }

    [HideInInspector] public int score1, score2;    

    private void Awake()
    {
        if(m_instance)
        {
            Destroy(gameObject);
            return;
        }

        m_instance = this;
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
        GameObject obj;

        if (!ball)
        {
            obj = GameObject.Find("Ball");
            if (obj)
                ball = obj.GetComponent<Ball>();
            else
                Debug.Log("Ball Not Found.");
        }

        if (!paddle1)
        {
            obj = GameObject.Find("Paddle1");
            if (obj)
                paddle1 = obj.GetComponent<PaddleController>();
            else
                Debug.Log("Paddle1 Not Found.");
        }

        if (!paddle2)
        {
            obj = GameObject.Find("Paddle2");
            if (obj)
                paddle2 = obj.GetComponent<PaddleController>();
            else
                Debug.Log("Paddle2 Not Found.");
        }

        if (ball && paddle1 && paddle2)
        {
            ball.Launch();
            paddle1.RestartPosition();
            paddle2.RestartPosition();
        }
    }

    public void SetMode(GameMode mode)
    {
        gameMode = mode;      
    }
}
