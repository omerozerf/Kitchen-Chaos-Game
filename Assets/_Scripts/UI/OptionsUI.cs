using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour
{
    public static OptionsUI Instance { get; private set; }
    
    
    [SerializeField] private Button soundEffectsButton;
    [SerializeField] private Button musicButton;
    [SerializeField] private Button closeButton;
    
    [SerializeField] private TextMeshProUGUI musicText;
    [SerializeField] private TextMeshProUGUI soundEffectsText;


    private void Awake()
    {
        Instance = this;
        
        
        soundEffectsButton.onClick.AddListener(() =>
        {
            SoundManager.Instance.ChangeVolume();
            UpdateVisual();
        });
        
        musicButton.onClick.AddListener(() =>
        {
            MusicManager.Instance.ChangeVolume();
            UpdateVisual();
        });
        
        closeButton.onClick.AddListener(() =>
        {
            Hide();
        });
    }


    private void Start()
    {
        UpdateVisual();
        Hide();
        
        
        GameManager.Instance.OnGameUnpaused += GameManagerOnOnGameUnpaused;
    }

    private void GameManagerOnOnGameUnpaused(object sender, EventArgs e)
    {
        Hide();
    }


    private void UpdateVisual()
    {
        soundEffectsText.text ="Sound Effects: " + Mathf.Round(SoundManager.Instance.GetVolume() * 10f);
        musicText.text = "Music: " + Mathf.Round(MusicManager.Instance.GetVolume() * 10);
    }

    
    public void Show()
    {
        gameObject.SetActive(true);
    }


    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
