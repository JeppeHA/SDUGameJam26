using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private RhythmManager rhythmManager;
    [SerializeField] private KeyIndicator indicator;
    [SerializeField] private float indicationTime;
    [SerializeField] private float lightUpTime = 0.1f;
    [SerializeField] private float visibleTime = 0.5f;
    private Coroutine lightRoutine;
    private Color baseColor;
    
    [Header("Timing windows (seconds)")]
    [SerializeField] private double perfectWindow = 0.05;
    [SerializeField] private double goodWindow = 0.10;
    [SerializeField] private double missWindow = 0.15;
    public float perfectModifier = 1f;
    public float goodModifier = 0.50f;
    [SerializeField] private float missModifier = -0.1f;


    private readonly Queue<RhythmNote> notes = new Queue<RhythmNote>();

    private PlayerInstance player;

    private void Start()
    {
        baseColor = GetComponent<Image>().color;
        player = FindFirstObjectByType<PlayerInstance>();
    }
    

    public void Register(RhythmNote note) => notes.Enqueue(note);

    void Update()
    {
        // Auto miss notes the player let pass
        while (notes.Count > 0 &&
               rhythmManager.SongTime() - notes.Peek().HitTime > missWindow)
        {
            Destroy(notes.Dequeue().gameObject);
        }
    }

    public void LightUp(Color color)
    {

        GetComponent<Image>().color = color;
        if (lightRoutine != null) StopCoroutine(lightRoutine);
        lightRoutine = StartCoroutine(LightRoutine());
    }
    
    private IEnumerator LightRoutine()
    {
        float time = 0f;
        while (time < lightUpTime)
        {
            float s = time / lightUpTime;
            transform.localScale = new Vector3(s, s, s);
            time += Time.deltaTime;
            yield return null;
        }
        transform.localScale = Vector3.one;
        
        yield return new WaitForSeconds(visibleTime);
        lightRoutine = null;
        GetComponent<Image>().color = baseColor;
    }

    public void CheckHit()
    {
        if (notes.Count == 0) return;

        double diff = rhythmManager.SongTime() - notes.Peek().HitTime;
        double abs = Math.Abs(diff);

        if (abs > missWindow)
        {
            indicator.Show("Miss!", Color.red);
            return;
        }

        RhythmNote note = notes.Dequeue();
        Destroy(note.gameObject);

        if (abs <= perfectWindow)
        {
            indicator.Show("Perfect!", Color.softYellow);
            player.playerHp += perfectModifier;
        }
        else if (abs <= goodWindow)
        {
            indicator.Show("Good", Color.softGreen);
            player.playerHp += goodModifier;
        }
        else
        {
            indicator.Show("Bad!", Color.softRed);
            player.playerHp += missModifier;
        }
    }
}