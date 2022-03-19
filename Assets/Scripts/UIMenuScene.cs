using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuScene : MonoBehaviour
{
    public void On2PlayersButton_Clicked()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        GameManager.instance.SetMode(GameManager.GameMode.pvp);
    }

    public void OnVSCompButton_Clicked()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        GameManager.instance.SetMode(GameManager.GameMode.vsComp);
    }
}
