using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AbilityInstance : MonoBehaviour
{
    public CreatureInstance creatureInstance;
    public ButtonController btnController;
    
    private SpriteRenderer sr;
    
    public AbilitySO ability;
    public AbilityInstance abilityInstance;
    public float buffMult;
    public float healValue;
    public float cooldown;
    public float duration;
    public AbilityType abilityType;
    public AbilityTargetType targetType;
    public string description;
    public string name;
    public Sprite sprite;
    public bool canUse;
    public bool active;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        creatureInstance = FindFirstObjectByType<CreatureInstance>();
        btnController = FindFirstObjectByType<ButtonController>();
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = sprite;
    }

    public void Setup(AbilitySO abilityData)
    {
        abilityInstance = GetComponent<AbilityInstance>();
        ability = abilityData;
        name = abilityData.name;
        buffMult = abilityData.buffMultiplier;
        healValue = abilityData.healValue;
        cooldown = abilityData.cooldown;
        abilityType = abilityData.abilityType;
        targetType = abilityData.targetType;
        description = abilityData.desc;
        name = abilityData.name;
        sprite = abilityData.sprite;
        canUse = abilityData.canUse;
        duration = abilityData.duration;
        active = abilityData.active;
    }
    
    public IEnumerator StartCooldown()
    {
        canUse = false;
        yield return new WaitForSeconds(cooldown);
        canUse = true;
    }

    public IEnumerator Duration()
    {
        active = true;
        yield return new WaitForSeconds(duration);
        active = false;
    }

    public void UseAbility(AbilityInstance abilityIns)
    {
        StartCoroutine(StartCooldown());
        StartCoroutine(Duration());
        switch (abilityIns.abilityType)
        {
            case AbilityType.AttackBuff:
                float orgAtk = creatureInstance.atk;
                while (active)
                {
                    creatureInstance.atk = creatureInstance.atk * buffMult;
                }
                creatureInstance.atk = orgAtk;
                break;
            case  AbilityType.Heal:
                float tmpPerfect = btnController.perfectModifier;
                float tmpGood = btnController.goodModifier;
                while (active)
                {
                    btnController.perfectModifier = btnController.perfectModifier * buffMult;
                    btnController.goodModifier = btnController.goodModifier * buffMult;
                }
                btnController.perfectModifier = tmpPerfect;
                btnController.goodModifier = tmpGood;
                break;
            case AbilityType.AttackSpeedBuff:
                float orgAtkSpd = creatureInstance.atkSpeed;
                while (active)
                {
                    creatureInstance.atkSpeed = creatureInstance.atkSpeed * buffMult;
                }
                creatureInstance.atkSpeed = orgAtkSpd;
                break;
            default:
                break;
        }
    }
}
