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

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clickClip;

    public void On2PlayersButton_Clicked()
    {
        audioSource.clip = clickClip;
        audioSource.Play();
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        GameManager.instance.SetMode(GameManager.GameMode.pvp);
    }

    public void OnVSCompButton_Clicked()
    {
        audioSource.clip = clickClip;
        audioSource.Play();
        vSCompButton.gameObject.SetActive(false);
        easyButton.gameObject.SetActive(true);
        mediumButton.gameObject.SetActive(true);
        hardButton.gameObject.SetActive(true);
    }

    public void OnEasyButton_Clicked()
    {
        audioSource.clip = clickClip;
        audioSource.Play();
        GameManager.instance.aiDelay = 0.02f;
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        GameManager.instance.SetMode(GameManager.GameMode.vsComp);
    }

    public void OnMediumButton_Clicked()
    {
        audioSource.clip = clickClip;
        audioSource.Play();
        GameManager.instance.aiDelay = 0.008f;
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        GameManager.instance.SetMode(GameManager.GameMode.vsComp);
    }

    public void OnHardButton_Clicked()
    {
        audioSource.clip = clickClip;
        audioSource.Play();
        GameManager.instance.aiDelay = 0f;
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        GameManager.instance.SetMode(GameManager.GameMode.vsComp);
    }
}
