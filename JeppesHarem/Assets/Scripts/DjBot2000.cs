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
        track0.clip = track0Clip;
        track0.Play();
    }
    

}
