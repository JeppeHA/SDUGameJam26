using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SongChartSO", menuName = "Scriptable Objects/SongChartSO")]
public class SongChartSO : ScriptableObject
{
    public float bpm = 120;
    public List<NoteData> notes;
}
