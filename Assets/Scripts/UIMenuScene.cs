using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMenuScene : MonoBehaviour
{
    [SerializeField] Button vSCompButton;
    [SerializeField] Button easyButton;
    [SerializeField] Button mediumButton;
    [SerializeField] Button hardButton;

    public void On2PlayersButton_Clicked()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        GameManager.instance.SetMode(GameManager.GameMode.pvp);
    }

    public void OnVSCompButton_Clicked()
    {
        vSCompButton.gameObject.SetActive(false);
        easyButton.gameObject.SetActive(true);
        mediumButton.gameObject.SetActive(true);
        hardButton.gameObject.SetActive(true);

        GameManager.instance.SetMode(GameManager.GameMode.vsComp);
    }

    public void OnEasyButton_Clicked()
    {
        GameManager.instance.aiDelay = 0.02f;
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    public void OnMediumButton_Clicked()
    {
        GameManager.instance.aiDelay = 0.01f;
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    public void OnHardButton_Clicked()
    {
        GameManager.instance.aiDelay = 0f;
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }
}
