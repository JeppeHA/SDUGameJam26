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
    [SerializeField] private AudioClip track0Clip;
 

    void Start()
    {
        track0.clip = track0Clip;
        track0.Play();
    }
    

}
