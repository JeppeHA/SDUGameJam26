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
    
    [SerializeField] private List<Transform> enemiesPositions = new List<Transform>();

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

    [SerializeField]
    private List<EnemyInstance> enemies = new List<EnemyInstance>();
    
    // Call from GameManager (yet to be implemented)
    public void PopulateCombat(List<EnemyInstance> enemies)
    {
        this.enemies = enemies;
    }

    public void SpawnEnemies()
    {

        for (int i = 0; i < enemies.Count; i++)
        {
            if(enemies[i] == null)
                continue;
            GameObject go = Instantiate(enemies[i].gameObject, enemiesPositions[i].position, Quaternion.identity);
            go.GetComponent<EnemyInstance>().InitalizeValues();
        }

    }

    public void StartCombat()
    {
        if (partyManager.team.Count == 0)
            return;
        SetPositions();
        PopulateCombat(enemies);
        SpawnEnemies();
    }
    
    private void SetPositions()
    {
        for (int i = 0; i < partyManager.team.Count; i++)
        {
            if (partyManager.team[i] == null)
            {
                continue;
            }
            partyManager.team[i].transform.position = creaturePositions[i].position;
        }
        
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i] == null)
            {
                continue;
            }
            enemies[i].transform.position = enemiesPositions[i].position;
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
                double totalHealt = 0;
                foreach (EnemyInstance enemy in enemies)
                {
                    Debug.Log(enemy.gameObject.name + " : " + enemy.hp);
                }
                Debug.Log("EnemyHP: " + totalHealt);
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
