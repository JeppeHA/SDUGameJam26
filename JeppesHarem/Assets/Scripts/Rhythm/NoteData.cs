using System;
using UnityEngine;

//Simple data class that contains the beat to hit the note on and which lane is should be played in
[Serializable]
public class NoteData
{
    public double beat;
    public int lane;
}
