using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureInstance : MonoBehaviour
{
    
    private SpriteRenderer spriteRenderer;

    public string name;
    public float hp;
    public float atkSpeed;
    public float atk;
    public Sprite sprite;
    private Typing type;
    public Animator animator;
    public bool canAttack;
    private float cooldown = 0f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
    }

    public void SetStats(CreatureSO creatureData)
    {
        name = creatureData.name;
        hp = creatureData.hp;
        atk = creatureData.atk;
        atkSpeed = creatureData.atkSpeed;
        sprite = creatureData.sprite;
        animator = creatureData.animator;
        canAttack = creatureData.canAttack;
        type = creatureData._type;
        cooldown = creatureData.cooldown;
        
    }

    public IEnumerator StartCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(cooldown);
        canAttack = true;
    }

    public void Attack(List<EnemyInstance> enemies)
    {
        StartCoroutine(StartCooldown());
        EnemySelection(enemies).hp -= atk;
    }

    private EnemyInstance EnemySelection(List<EnemyInstance> enemies)
    {
        if (enemies.Count == 0) return null;
        EnemyInstance currentTarget = enemies[0];
        float lowestHealth = enemies[0].hp;
        foreach (var enemy in enemies)
        {
            if (enemy.hp <= lowestHealth)
            {
                currentTarget = enemy;
                lowestHealth = enemy.hp;
            }
        }
        return currentTarget;
    }
    
    
}
