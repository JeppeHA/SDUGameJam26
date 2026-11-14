using UnityEngine;

public class RhythmManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;

    private double songStartTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        songStartTime = AudioSettings.dspTime + 1;
        audioSource.PlayScheduled(songStartTime);
    }

    public double songTime()
    {
        return AudioSettings.dspTime - songStartTime;
    }
}
