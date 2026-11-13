using System.Collections;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public PartyManager partyManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        partyManager = GameObject.Find("PartyManager").GetComponent<PartyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CalculateTeamDamage(EnemySO enemy)
    {
        float totalDamage = 0;
        foreach (CreatureSO creature in partyManager.team)
        {
            totalDamage += creature.atk;
        }
        enemy.hp -= totalDamage;
    }

    public void EnemyDamage(EnemySO enemy)
    {
        if (enemy.canAttack == false) //check if attack is off cooldown
        {
            return;
        }
        
        //Insert logic for enemy damage applied to player

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
