using TMPro;
using UnityEngine;

public class CardController : MonoBehaviour
{
    private Canvas canvas;
    private TMP_Text text;
    private string info;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Vector3 spawnPos;
    public CreatureSO creatureToSpawn;
    public AbilitySO abilityToSpawn;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvas = GetComponentInChildren<Canvas>();
        canvas.worldCamera = Camera.main;
        text = GetComponentInChildren<TMP_Text>();
        canvas.enabled = false;
    }

    public void infoDump(string name, string type, string desc, Sprite sprite, Vector3 spawnPos, CreatureSO creatureToSpawn)
    {
        info = $"{name}\n{type}\n{desc}";
        spriteRenderer.sprite = sprite;
        this.spawnPos = spawnPos;
        this.creatureToSpawn = creatureToSpawn;

    }

    public void infoDump(string name, string type, string desc, Sprite sprite, Vector3 spawnPos, AbilitySO abilityToSpawn)
    {
        info = $"{name}\n{type}\n{desc}";
        spriteRenderer.sprite = sprite;
        this.spawnPos = spawnPos;
        this.abilityToSpawn = abilityToSpawn;

    }

    private void OnMouseEnter() 
    {
        canvas.enabled = true;
        text.text = info;
    }

    private void OnMouseExit()
    {
        canvas.enabled = false;
    }

    private void OnMouseDown()
    {
        canvas.enabled = false;
    }

    private void OnMouseUp()
    {
        canvas.enabled = true;
        //transform.position = spawnPos;

    }
}
