using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneFader : MonoBehaviour
{
    [SerializeField] private Image image;
    //public string sceneName;
    private float duration = 0.75f;
    private AudioSource audioSource;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += LoadedScene;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void LoadedScene(Scene current, LoadSceneMode loadMode)
    {
        image = GameObject.FindGameObjectWithTag("sceneFade").GetComponent<Image>();
        StartCoroutine(FadeOut());
    }

    public void FadeAndLoadScene(string sceneName)
    {
        audioSource.Play();
        StartCoroutine(FadeIn(sceneName));
    }

    IEnumerator FadeIn(string sceneName)
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
        float t = duration;
        Color c = image.color;
        while (t > 0)
        {
            t -= Time.deltaTime;
            c.a = t / duration;
            Debug.Log(t / duration);
            Debug.Log(c);
            image.color = c;
            yield return null;
        }
        image.enabled = false;
    }
}
