using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuScene : MonoBehaviour
{
    public void OnPlayButton_Clicked()
    {
        SceneManager.LoadScene("GameScene");
    }
}
