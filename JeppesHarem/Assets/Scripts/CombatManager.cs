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

    private List<EnemyInstance> enemies = new List<EnemyInstance>();
    // Call from GameManager (yet to be implemented)
    public void PopulateCombat(List<EnemyInstance> enemies)
    {
        this.enemies = enemies;
    }


    // Update is called once per frame
    void Update()
    {
        foreach (CreatureInstance creature in partyManager.team) 
        { 
            if (creature.canAttack)
            {
                creature.Attack(enemies);
            }
        }

        foreach (EnemyInstance enemy in enemies)
        {
            if (enemy.canAttack) 
            {
                StartCoroutine(enemy.StartCooldown()); //Starts enemy attack cooldown
                gameManager.player.playerHp -= enemy.atk;
            }
        }

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
