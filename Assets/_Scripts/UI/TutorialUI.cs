using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    private void Start()
    {
        Show();
        GameManager.Instance.OnStateChanged+= GameManagerOnOnStateChanged;
    }

    private void GameManagerOnOnStateChanged(object sender, EventArgs e)
    {
        if (GameManager.Instance.IsCountdownToStartActive())
        {
            Hide();
        }
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
