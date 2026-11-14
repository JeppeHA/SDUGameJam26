using System;
using UnityEngine;
using System.Collections.Generic;

public class PartyManager : MonoBehaviour
{

    private GameObject starterCreaturePrefab;
    public CreatureSO starterCreatureData;
    public static PartyManager Instance {  get; private set; }

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

    public List<CreatureInstance> team = new List<CreatureInstance>();
    public int teamCap = 3;
    private PlayerSO player;

    private void Start()
    {
        CreatureFactory creatureFactory = GetComponent<CreatureFactory>();
        starterCreaturePrefab = creatureFactory.CreatureInstance(starterCreatureData);
        AddCreature(starterCreaturePrefab.GetComponent<CreatureInstance>());
        PrintParty();
    }

    public void AddCreature(CreatureInstance newCreature)
    {
        if (team.Count >= teamCap)
        {
            return;
        }
        team.Add(newCreature);
    }

    public void RemoveCreature(CreatureInstance oldCreature)
    {
        if (team.Count <= 0)
        {
            return;
        }
        team.Remove(oldCreature);
    }

    public void PlaceCreature(CreatureInstance creature, Vector3 position)
    {
        creature.transform.position = position;
    }

    public void PrintParty()
    {
        foreach (CreatureInstance creatureInstance in team)
        {
            Debug.Log(creatureInstance.name);
        }
    }
}
