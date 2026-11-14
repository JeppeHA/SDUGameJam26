using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyIndicator : MonoBehaviour
{
    private TextMeshProUGUI textElement;
    private string text = "";
    [SerializeField] private float popUpTime = 0.1f;

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
        DisableKeyIndicator();
        gameObject.SetActive(true);
        PopUp();
    }

    public void PopUp()
    {
        StartCoroutine(PopUpCoroutine());
    }

    private IEnumerator PopUpCoroutine()
    {
        float time = 0;

        while (time < popUpTime)
        {
            float t = time / popUpTime;
            float s = Mathf.Lerp(0, 1, t);
            gameObject.transform.localScale = new Vector3(s, s, s);
            time += Time.deltaTime;
            
            yield return null;
        }
    }

    public void DisableKeyIndicator()
    {
        gameObject.SetActive(false);
    }


}


