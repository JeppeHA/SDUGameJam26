using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyIndicator : MonoBehaviour
{
    private TextMeshProUGUI textElement;
    private string text = "";

    private void Start()
    {
        textElement = GetComponent<TextMeshProUGUI>();
        DisableKeyIndicator();
    }

    public void SetText(string text, Color color)
    {
        this.text = text;
        textElement.text = text;
        textElement.color = color;
    }

    public void EnableKeyIndicator()
    {
        gameObject.SetActive(true);
    }

    public void DisableKeyIndicator()
    {
        gameObject.SetActive(false);
    }


}


