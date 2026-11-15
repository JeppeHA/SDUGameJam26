using UnityEngine;

public class CreditScript : MonoBehaviour
{
    public float scrollSpeed = 80f;
    
    private RectTransform _rectTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        _rectTransform.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);
    }

    
}
