using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    [SerializeField] private string gameSceneName;

    public void Play()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
