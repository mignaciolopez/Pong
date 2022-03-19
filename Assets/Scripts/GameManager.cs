using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Ball ball;
    PaddleController paddle1;
    PaddleController paddle2;

    [SerializeField] AudioClip startGameAudio;
    [SerializeField] AudioSource audioSource;

    private static GameManager m_instance = null;

    public enum GameMode
    {
        pvp = 0,
        vsComp
    }
    GameMode gameMode = GameMode.vsComp;

    [HideInInspector] public float aiDelay = 0f;

    public static GameManager instance
    {
        private set { }

        get
        {
            if (!m_instance)
            {
                GameObject gameManager = new GameObject("GameManager");
                GameManager manager = gameManager.AddComponent<GameManager>();
                m_instance = manager;
            }
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

            switch (gameMode)
            {
                case GameMode.pvp:
                    paddle2.aiControlled = false;
                    break;
                case GameMode.vsComp:
                    paddle2.aiControlled = true;
                    paddle2.aiDelay = aiDelay;
                    break;
                default:
                    break;
            }
        }
    }

    public void SetMode(GameMode mode)
    {
        audioSource.clip = startGameAudio;
        audioSource.Play();
        gameMode = mode;
    }
}
