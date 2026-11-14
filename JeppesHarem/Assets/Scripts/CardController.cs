using TMPro;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public string _name;
    public string _type;
    public string _description;
    public Sprite _sprite;

    private Canvas _canvas;
    private TMP_Text text;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _canvas = GetComponentInChildren<Canvas>();
    }

    public void infoDump(string name, string type, string desc)
    {
        _name = name;
        _type = type;
        _description = desc;

        text.text = $"{name}\n{type}\n{desc}";

    }

    private void OnMouseOver()
    {
        _canvas.gameObject.SetActive(true);
    }
}
