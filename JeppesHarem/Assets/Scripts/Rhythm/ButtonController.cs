using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private RhythmManager rhythmManager;
    [SerializeField] private KeyIndicator indicator;
    [SerializeField] private float indicationTime;

    [Header("Timing windows (seconds)")]
    [SerializeField] private double perfectWindow = 0.05;
    [SerializeField] private double goodWindow = 0.10;
    [SerializeField] private double missWindow = 0.15;

    private readonly Queue<RhythmNote> notes = new Queue<RhythmNote>();

    public void Register(RhythmNote note) => notes.Enqueue(note);



    void Update()
    {
        // Auto miss notes the player let pass
        while (notes.Count > 0 &&
               rhythmManager.songTime() - notes.Peek().HitTime > missWindow)
        {
            Destroy(notes.Dequeue().gameObject);
            Debug.Log("Miss (late)");
        }
    }

    public void CheckHit()
    {
        Debug.Log(notes.Count);
        if (notes.Count == 0) return;

        // negative = early
        double diff = rhythmManager.songTime() - notes.Peek().HitTime; 
        double abs = Math.Abs(diff);

        // too early, ignore the press
        if (abs > missWindow) return; 

        RhythmNote note = notes.Dequeue();
        Destroy(note.gameObject);

        if (abs <= perfectWindow)
        {
            Debug.Log($"Perfect ({diff:F3})");
            indicator.SetText("Perfect!", Color.yellow);
            indicator.EnableKeyIndicator();
        }
        else if (abs <= goodWindow)
        {
            Debug.Log($"Good ({diff:F3})");
            indicator.SetText("Good", Color.green);
            indicator.EnableKeyIndicator();
        }
        else
        {
            Debug.Log($"Bad ({diff:F3})");
            Debug.Log($"Good ({diff:F3})");
            indicator.SetText("Bad!", Color.red);
            indicator.EnableKeyIndicator();
        }

        StartCoroutine(HideIndicator());
    }

    private IEnumerator HideIndicator()
    {
        yield return new WaitForSeconds(indicationTime);
        indicator.DisableKeyIndicator();
    }
}