using UnityEngine;
using UnityEngine.Video;

public class Backtrack : MonoBehaviour
{
    public AudioSource audio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.loop = true;
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
