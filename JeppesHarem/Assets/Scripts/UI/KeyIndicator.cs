using System.Collections;
using TMPro;
using UnityEngine;

public class KeyIndicator : MonoBehaviour
{
    [SerializeField] private float popUpTime = 0.1f;
    [SerializeField] private float visibleTime = 0.5f;

    private TextMeshProUGUI textElement;
    private Coroutine routine;

    private void Awake()
    {
        textElement = GetComponent<TextMeshProUGUI>();
        gameObject.SetActive(false);
    }

    public void Show(string text, Color color)
    {
        textElement.text = text;
        textElement.color = color;

        gameObject.SetActive(true);

        // Cancel the previous pop-up
        if (routine != null) StopCoroutine(routine);
        routine = StartCoroutine(ShowRoutine());
    }
    

    private IEnumerator ShowRoutine()
    {
        float time = 0f;
        while (time < popUpTime)
        {
            float s = time / popUpTime;
            transform.localScale = new Vector3(s, s, s);
            time += Time.deltaTime;
            yield return null;
        }
        transform.localScale = Vector3.one;
        
        yield return new WaitForSeconds(visibleTime);
        gameObject.SetActive(false);
        routine = null;
    }
}