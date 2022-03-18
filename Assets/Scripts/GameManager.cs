using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager m_instance;
    public static GameManager Instance { get { return m_instance; } }

    public void Awake()
    {
        if (m_instance && m_instance != this)
        {
            Destroy(gameObject);
            return;
        }

        m_instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void OnClickPlay()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    public void OnClickMenu()
    {
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }
}
