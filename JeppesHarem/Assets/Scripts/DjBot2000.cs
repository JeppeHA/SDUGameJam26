using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;
using UnityEngine.Timeline;


public class DjBot2000 : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioSource track0;
    [SerializeField] private AudioSource track1;
    [SerializeField] private AudioClip track0Clip;
    [SerializeField] private AudioClip track1Clip;
    [SerializeField] private AudioClip track2Clip;
    [SerializeField] private AudioClip track3Clip;

    public List<AudioClip> trackList = new List<AudioClip>();
    public List<AudioClip> playList = new List<AudioClip>();
    public int randomInt;

    void Start()
    {
        trackList.Add(track0Clip);
        trackList.Add(track1Clip);
        trackList.Add(track2Clip);
        trackList.Add(track3Clip);

        track0.clip = track0Clip;
        track1.clip = track1Clip;
        track0.Stop();
        track1.Stop();
        track0.PlayDelayed(8f);
        track1.PlayDelayed(16f);
    }
    private void Update()
    {
        if (!track0.isPlaying)
        {
            randomInt = Random.Range(0, trackList.Count);
            track0.clip = trackList[randomInt];
            track0.PlayDelayed(8f);
            //Aktiver Noder til om 8 sekunder

        }
        if (!track1.isPlaying)
        {
            randomInt = Random.Range(0, trackList.Count);
            track1.clip = trackList[randomInt];
            track1.PlayDelayed(8f);
            //Aktiver Noder til om 8 sekunder
        }
    }

}
