using UnityEngine;

public class RhythmNote : MonoBehaviour
{
    /*
     * The node object class this class initialize an RhythmNote object
     * and its reponsable for moving the object towards the key 
     */
    [SerializeField] private float hitX = -7f;

    private double hitTime;
    private float approachTime;
    private float spawnX;
    private RhythmManager rhythmManager;

    public double HitTime => hitTime;

    public void Initialize(RhythmManager manager, double hitTime, float spawnX, float approachTime)
    {
        rhythmManager = manager;
        this.hitTime = hitTime;
        this.spawnX = spawnX;
        this.approachTime = approachTime;
    }

    void Update()
    {
        double remaining = hitTime - rhythmManager.songTime();
        float progress = 1f - (float)(remaining / approachTime);

        Vector3 pos = transform.localPosition;
        pos.x = Mathf.LerpUnclamped(spawnX, hitX, progress);
        transform.localPosition = pos;
    }
}