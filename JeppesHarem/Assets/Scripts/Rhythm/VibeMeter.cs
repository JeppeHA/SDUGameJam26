using UnityEngine;
using UnityEngine.UI;

public class VibeMeter : MonoBehaviour
{
    [SerializeField] private Slider vibeMeter;
    private PlayerInstance player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<PlayerInstance>();
        vibeMeter.maxValue = player.playerHp;
        player.playerHp = player.playerHp/2;
    }

    // Update is called once per frame
    void Update()
    {
        vibeMeter.value = player.playerHp;
    }
}
