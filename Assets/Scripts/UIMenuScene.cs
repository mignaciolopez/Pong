using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenuScene : MonoBehaviour
{
    public void OnClickPlay()
    {
        GameManager.Instance.OnClickPlay();
    }
}
