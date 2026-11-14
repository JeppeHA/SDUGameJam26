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
    private List<EnemyInstance> liveEnemies = new List<EnemyInstance>();
    [SerializeField]
    private List<GameObject> enemiesPrefabs = new List<GameObject>();
    

    public void SpawnEnemies()
    {

        for (int i = 0; i < enemiesPrefabs.Count; i++)
        {
            if(enemiesPrefabs[i] == null)
                continue;
            GameObject go = Instantiate(enemiesPrefabs[i].gameObject, enemiesPositions[i].position, Quaternion.identity);
            liveEnemies.Add(go.GetComponent<EnemyInstance>());
        }

    }

    public void StartCombat()
    {
        if (partyManager.team.Count == 0)
            return;
        SetPositions();
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
        
        for (int i = 0; i < liveEnemies.Count; i++)
        {
            if (liveEnemies[i] == null)
            {
                continue;
            }
            liveEnemies[i].transform.position = enemiesPositions[i].position;
        }
    }


    // Update is called once per frame
    void Update()
    {
        foreach (CreatureInstance creature in partyManager.team) 
        { 
            if (creature.canAttack)
            {
                creature.Attack(liveEnemies);
                Debug.Log("EnemyHP: " + liveEnemies[0].health);
            }
        }

        foreach (EnemyInstance enemy in liveEnemies)
        {
            if (enemy.canAttack) 
            {
                StartCoroutine(enemy.StartCooldown()); //Starts enemy attack cooldown
                //gameManager.player.playerHp -= enemy.atk;
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
