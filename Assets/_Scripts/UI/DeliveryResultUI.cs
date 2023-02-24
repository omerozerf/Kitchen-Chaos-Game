using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryResultUI : MonoBehaviour
{
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private Color successColor;
    [SerializeField] private Color failedColor;
    [SerializeField] private Sprite successSprite;
    [SerializeField] private Sprite failedSprite;
    

    private void Start()
    {
        DeliveryManager.Instance.OnRecipeSuccess += InstanceOnOnRecipeSuccess;
        DeliveryManager.Instance.OnRecipeFailed += InstanceOnOnRecipeFailed;
        
        gameObject.SetActive(false);
    }

    private void InstanceOnOnRecipeFailed(object sender, EventArgs e)
    {
        gameObject.SetActive(true);
        backgroundImage.color = failedColor;
        iconImage.sprite = failedSprite;
        messageText.text = "DELIVERY\nFAILED";
    }

    private void InstanceOnOnRecipeSuccess(object sender, EventArgs e)
    {
        gameObject.SetActive(true);
        backgroundImage.color = successColor;
        iconImage.sprite = successSprite;
        messageText.text = "DELIVERY\nSUCCESS";
    }
}
