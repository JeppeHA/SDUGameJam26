using System.Collections.Generic;
using UnityEngine;

// Contains all the spawning logic for when notes should be spawned
public class NoteSpawner : MonoBehaviour
{
    public SongChartSO songChart;
    public GameObject rhythmNotePrefab;
    public Transform[] lanePositions;
    [SerializeField] private ButtonController[] laneControllers;
    public RhythmManager rhythmManager;
    [SerializeField] private float approachTime = 2f; // must be > 0
    private Canvas canvas;
    private GameObject nodeLayout;

    private int nextNoteIndex;

    private List<NoteData> sortedNotes;

    void Start()
    {
        canvas = GameObject.FindFirstObjectByType<Canvas>();
        nodeLayout = canvas.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        Debug.Log(nodeLayout.name);
        sortedNotes = new List<NoteData>(songChart.notes);
        sortedNotes.Sort((a, b) => a.beat.CompareTo(b.beat));
        rhythmManager = GameObject.FindFirstObjectByType<RhythmManager>();
    }
   
    void Update()
    {
        if (songChart == null) return;

        while (nextNoteIndex < songChart.notes.Count)
        {
            NoteData note = sortedNotes[nextNoteIndex];
            // Converts beats to seconds
            double hitTime = note.beat * (60.0 / songChart.bpm);

            // is the time remaining until the note must be hit
            // If the note is still more than approachTime seconds away, it’s too early to spawn, so stop
            if (hitTime - rhythmManager.SongTime() > approachTime) break;

            SpawnNote(note, hitTime);
            nextNoteIndex++;
        }
    }

    void SpawnNote(NoteData data, double hitTime)
    {
        int lane = data.lane - 1;
        Vector3 pos = lanePositions[lane].position;
        //Debug.Log(pos);
        GameObject go = Instantiate(rhythmNotePrefab, new Vector3(pos.x, pos.y, transform.position.z),
            Quaternion.identity,nodeLayout.transform);
        RhythmNote note = go.GetComponent<RhythmNote>();
        note.Initialize(rhythmManager, hitTime, 1000 , approachTime);
        laneControllers[lane].Register(note);
    }
}
