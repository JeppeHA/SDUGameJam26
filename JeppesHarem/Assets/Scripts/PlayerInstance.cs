using UnityEngine;
using System.Collections.Generic;

public class PlayerInstance : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    public PlayerSO player;
    public float playerHp;
    public Sprite playerSprite;
    public Animator anim;
    public AbilitySO ability1;
    public AbilitySO ability2;


    private void Awake()
    {
        InitializeValues(player);
    }

    public void InitializeValues(PlayerSO playerData)
    {
        player = playerData;
        playerHp = playerData.playerHp;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        //_spriteRenderer.sprite = playerSprite;
        anim = playerData.animator;
        ability1 = playerData.firstAbility;
        ability2 = playerData.secondAbility;
    }

    public void TakeDamage(EnemyInstance enemy)
    {
        playerHp -= enemy.atk;
    }

    public void HealPlayer(AbilitySO ability)
    {
        playerHp += ability.healValue;
    }
}
