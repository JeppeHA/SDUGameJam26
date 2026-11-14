using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CombatManager : MonoBehaviour
{
    public static CombatManager Instance { get; private set; }
    [SerializeField]
    private List<Transform> creaturePositions = new List<Transform>();

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

    public UnityEvent combatInitiated;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.FindFirstObjectByType<GameManager>();
        partyManager = GameObject.FindFirstObjectByType<PartyManager>();
        
        combatInitiated.AddListener(FindFirstObjectByType<PartyManager>().PopulateTeam);
        
        combatInitiated.Invoke();
        
        StartCombat();
        
    }

    private List<EnemyInstance> enemies = new List<EnemyInstance>();
    // Call from GameManager (yet to be implemented)
    public void PopulateCombat(List<EnemyInstance> enemies)
    {
        this.enemies = enemies;
    }

    public void StartCombat()
    {
        Debug.Log("Starting Combat");
        Debug.Log(partyManager.team.Count);
        if (partyManager.team.Count == 0)
            return;
        Debug.Log("INIT COMBAT");
        SetCreaturePosition();
        PopulateCombat(enemies);
    }
    
    private void SetCreaturePosition()
    {
        for (int i = 0; i < partyManager.team.Count; i++)
        {
            if (partyManager.team[i] == null)
            {
                continue;
            }
            Debug.Log(partyManager.team[i].name);
            Debug.Log("Creature position: " + creaturePositions[i].position);
            partyManager.team[i].transform.position = creaturePositions[i].position;
        }
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
