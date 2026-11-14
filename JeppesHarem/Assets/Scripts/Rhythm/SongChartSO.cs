using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SongChartSO", menuName = "Scriptable Objects/SongChartSO")]

// Scriptable object that contains the bpm and all the notes that needs to be hit
public class SongChartSO : ScriptableObject
{
    public float bpm = 120;
    public List<NoteData> notes;
}
