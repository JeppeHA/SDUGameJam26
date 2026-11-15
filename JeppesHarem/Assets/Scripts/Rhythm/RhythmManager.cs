using UnityEngine;
using System.Collections;

public class RhythmManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource backingTrackSource;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AudioClip backingTrack;
    [SerializeField] private NoteSpawner noteSpawnerPrefab;
    NoteSpawner notespawner;

    private double songStartTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
    void Start()
    {
        backingTrackSource.clip = backingTrack;
        backingTrackSource.Play();
        StartCoroutine(StopBackingTrack());
        notespawner = Instantiate(noteSpawnerPrefab, transform.position, Quaternion.identity);
        audioSource.clip = audioClip;
        songStartTime = AudioSettings.dspTime + 8;
        audioSource.PlayScheduled(songStartTime);
        StartCoroutine(Replay((float)(AudioSettings.dspTime + 40)));
        StartCoroutine(Replay((float)(AudioSettings.dspTime + 72)));
        StartCoroutine(Replay((float)(AudioSettings.dspTime + 104)));
    }
    IEnumerator StopBackingTrack()
    {
        yield return new WaitForSeconds(8);
        backingTrackSource.Stop();
        //audioSource.Play();
    }
    IEnumerator Replay(float delay){
        yield return new WaitForSeconds(delay);
        Destroy(notespawner.gameObject);
        notespawner = Instantiate(noteSpawnerPrefab, transform.position, Quaternion.identity);
        audioSource.Play();
    }

    public double SongTime()
    {
        return AudioSettings.dspTime - songStartTime;
    }
}
