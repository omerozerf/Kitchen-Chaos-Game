using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauseUI : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.OnGamePaused += GameManagerOnOnGamePaused;
        GameManager.Instance.OnGameUnpaused += GameManagerOnOnGameUnpaused;
        
        Hide();
    }

    private void GameManagerOnOnGameUnpaused(object sender, EventArgs e)
    {
        Hide();
    }

    private void GameManagerOnOnGamePaused(object sender, EventArgs e)
    {
        Show();
    }


    private void Show()
    {
        gameObject.SetActive(true);
    }


    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
