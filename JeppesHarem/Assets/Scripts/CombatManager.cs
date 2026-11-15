using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class CombatManager : MonoBehaviour
{
    public static CombatManager Instance { get; private set; }
    [SerializeField]
    private List<Transform> creaturePositions = new List<Transform>();
    
    [SerializeField] private List<Transform> enemiesPositions = new List<Transform>();
    public Transform playerPos;

    [SerializeField] public List<CreatureInstance> instantiatedPartyMembers = new List<CreatureInstance>();

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
    private AbilityManager abilityManager;
    [SerializeField] private PlayerInstance player;

    public UnityEvent combatInitiated;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.FindFirstObjectByType<GameManager>();
        partyManager = GameObject.FindFirstObjectByType<PartyManager>();
        player = GetComponent<PlayerInstance>();
        
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
            if (enemiesPrefabs[i] == null || enemiesPositions[i] == null)
                continue;
            GameObject go = Instantiate(enemiesPrefabs[i].gameObject, enemiesPositions[i].position, Quaternion.identity);
            Debug.Log("livenemies add");
            liveEnemies.Add(go.GetComponent<EnemyInstance>());
        }
    }

    public void SpawnPlayer()
    {
        Instantiate(player, playerPos.position, Quaternion.identity);
    }

    public void StartCombat()
    {
        Debug.Log("start combat");
        if (partyManager.team.Count == 0)
            return;
        SetPositions();
        SpawnEnemies();
        //SpawnPlayer();
    }
    
    private void SetPositions()
    {
        for (int i = 0; i < partyManager.team.Count; i++)
        {
            if (partyManager.team[i] == null)
            {
                continue;
            }
            GameObject memberToInstatiate = gameManager.GetComponent<CreatureFactory>().CreatureInstance(partyManager.team[i]);
            instantiatedPartyMembers.Add(memberToInstatiate.GetComponent<CreatureInstance>().creatureInstance);
            instantiatedPartyMembers[i].transform.position = creaturePositions[i].position;
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
        foreach (CreatureInstance creature in instantiatedPartyMembers) 
        { 
            if (creature.canAttack)
            {
                creature.Attack(liveEnemies);
                
                
                for (int i = 0; i < liveEnemies.Count; i++)
                {
                    if (liveEnemies[i].health < 0)
                    {
                        liveEnemies.Remove(liveEnemies[i]);
                    }
                    if (liveEnemies.Count == 0)
                    {
                        //Win
                        Debug.Log("Win!");
                    }
                }
            }
        }

        foreach (EnemyInstance enemy in liveEnemies)
        {
            if (enemy.canAttack) 
            {
                StartCoroutine(enemy.StartCooldown()); //Starts enemy attack cooldown
                player.TakeDamage(enemy);
                if (player.playerHp < 0)
                {
                    //Lose
                    Debug.Log("Lose");
                }
            }
        }

    }
}
