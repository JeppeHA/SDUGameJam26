using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public static CombatManager Instance { get; private set; }

    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private GameManager gameManager;
    private PartyManager partyManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        partyManager = GameObject.Find("PartyManager").GetComponent<PartyManager>();
    }

    private List<EnemySO> enemies = new List<EnemySO>();
    private float enemyHP;
    // Call from GameManager (yet to be implemented)
    public void PopulateCombat(List<EnemySO> enemies)
    {
        this.enemies = enemies;
        foreach (EnemySO enemy in enemies) 
        {
            enemyHP += enemy.hp;
        }
    }


    // Update is called once per frame
    void Update()
    {
        foreach (CreatureSO creature in partyManager.team) 
        { 
            if (creature.canAttack)
            {
                CreatureAttack(creature);
            }
        }

        foreach (EnemySO enemy in enemies)
        {
            if (enemy.canAttack) 
            {
                EnemyDamage(enemy);
            }
        }

    }

    public void CreatureAttack(CreatureSO creature)
    {
        enemyHP -= creature.atk;

        StartCoroutine(creature.StartCooldown()); //Starts creature attack cooldown
    }

    public void EnemyDamage(EnemySO enemy)
    {
        gameManager.player.playerHp -= enemy.atk;

        StartCoroutine(enemy.StartCooldown()); //Starts enemy attack cooldown
    }

    public void UseAbility(AbilitySO ability, EnemySO enemy)
    {
        if (ability.canUse == false) //check if ability is off cooldown
        {
            return;
        }

        enemy.hp -= ability.damage; //Applies ability dmg to enemy
        
        StartCoroutine(ability.StartCooldown()); //Starts ability cooldown
    }
}
