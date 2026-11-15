using UnityEngine;
using System.Collections;

public class RhythmManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource backingTrackSource;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AudioClip backingTrack;
    NoteSpawner notespawner;

    private double songStartTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
    void Start()
    {
        backingTrackSource.clip = backingTrack;
        backingTrackSource.Play();
        StartCoroutine(StopBackingTrack());
        notespawner = FindFirstObjectByType<NoteSpawner>();
        notespawner.enabled = true;
        audioSource.clip = audioClip;
        songStartTime = AudioSettings.dspTime + 8;
        audioSource.PlayScheduled(songStartTime);
    }
    IEnumerator StopBackingTrack()
    {
        yield return new WaitForSeconds(8);
        backingTrackSource.Stop();
        //audioSource.Play();
    }

    public double SongTime()
    {
        return AudioSettings.dspTime - songStartTime;
    }
}
