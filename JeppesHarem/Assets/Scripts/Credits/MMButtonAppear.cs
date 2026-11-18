using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MMButtonAppear : MonoBehaviour
{
    private Image btn;
    private SceneFader sceneFader;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        btn = GetComponent<Image>();
        sceneFader = FindFirstObjectByType<GameManager>().GetComponent<SceneFader>();
        StartCoroutine(BtnApear());
    }

    public void GoToMainMenu()
    {
        sceneFader.FadeAndLoadScene("MainMenu");
    }
    
    IEnumerator BtnApear()
    {
        btn.enabled = false;
        yield return new WaitForSeconds(25);
        btn.enabled = true;
    }
    
}
