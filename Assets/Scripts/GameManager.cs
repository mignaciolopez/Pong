using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Ball ball;
    [SerializeField] PaddleController paddle1;
    [SerializeField] PaddleController paddle2;

    private static GameManager m_instance = null;
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
        ball.Launch();
        paddle1.RestartPosition();
        paddle2.RestartPosition();
    }
}
