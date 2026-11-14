using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneFader : MonoBehaviour
{
    public Image image;
    public string sceneName;
    public float duration = 1;
    private void Start()
    {
        StartCoroutine(FadeOut());
    }
    
    public void FadeAndLoadScene()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        image.enabled = true;
        float t = 0;
        Color c = image.color;
        while (t < duration)
        {
            t += Time.deltaTime;
            c.a = t / duration;
            image.color = c;
            yield return null;
        }
        SceneManager.LoadScene(sceneName);
        
    }
    
    IEnumerator FadeOut()
    {
        float t = 0;
        Color c = image.color;
        while (t < 1)
        {
            t += Time.deltaTime;
            c.a = 1 - (t / 1f);
            image.color = c;
            yield return null;
        }
        image.enabled = false;
    }
}
