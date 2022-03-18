using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameScene : MonoBehaviour
{
    [SerializeField] TMP_Text score1;
    [SerializeField] TMP_Text score2;

    private void OnGUI()
    {
        score1.text = GameManager.instance.score1.ToString();
        score2.text = GameManager.instance.score2.ToString();
    }
}
