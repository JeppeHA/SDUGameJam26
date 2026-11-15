using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CombatAbilityController : MonoBehaviour
{
    [SerializeField] private Image[] abilityImages;
    private AbilityManager abilityManager;

    public CreatureInstance creatureInstance;
    public ButtonController btnController;

    [SerializeField] private Slider[] sliders;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Creature instance eksistere ikke endnu vi finder den aldrig. Find listen af instatiatedcreatures istedet
        creatureInstance = FindFirstObjectByType<CreatureInstance>();
        btnController = FindFirstObjectByType<ButtonController>();

        abilityManager = GameObject.FindFirstObjectByType<AbilityManager>();

        for (int i = 0; i < abilityManager.abilities.Count; i++)
        {
            abilityImages[i].sprite = abilityManager.abilities[i].sprite;
        }
    }

    private void Update()
    {
        AbilityInput();

        /*for (int i = 0; i < abilityManager.abilities.Count; i++)
        {
            if (!abilityManager.abilities[i].canUse)
            {
                sliders[i].value -= Time.deltaTime;
                if (sliders[i].value == sliders[i].minValue)
                {
                    sliders[i].value = sliders[i].maxValue;
                }
            }
        }*/
    }

    public void AbilityInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UseAbility(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UseAbility(2);
        }
    }

    public IEnumerator StartCooldown(int i)
    {
        abilityManager.abilities[i].canUse = false;
        yield return new WaitForSeconds(abilityManager.abilities[i].cooldown);
        abilityManager.abilities[i].canUse = true;
    }

    public IEnumerator Duration(int i)
    {
        abilityManager.abilities[i].active = true;
        yield return new WaitForSeconds(abilityManager.abilities[i].duration);
        abilityManager.abilities[i].active = false;
    }

    public void UseAbility(int i)
    {
        StartCoroutine(StartCooldown(i));
        StartCoroutine(Duration(i));
        switch (abilityManager.abilities[i].abilityType)
        {
            case AbilityType.AttackBuff:
                float orgAtk = creatureInstance.atk;
                float buffedAtk = orgAtk * abilityManager.abilities[i].buffMult;
                while (abilityManager.abilities[i].active)
                {
                    creatureInstance.atk = buffedAtk;
                }
                creatureInstance.atk = orgAtk;
                break;
            case AbilityType.Heal:
                float tmpPerfect = btnController.perfectModifier;
                float tmpGood = btnController.goodModifier;
                float buffedPerfectVibes = tmpPerfect * abilityManager.abilities[i].buffMult;
                float buffedGoodVibes = tmpGood * abilityManager.abilities[i].buffMult;
                while (abilityManager.abilities[i].active)
                {
                    btnController.perfectModifier = buffedPerfectVibes;
                    btnController.goodModifier = buffedGoodVibes;
                }
                btnController.perfectModifier = tmpPerfect;
                btnController.goodModifier = tmpGood;
                break;
            case AbilityType.AttackSpeedBuff:
                float orgAtkSpd = creatureInstance.cooldown;
                float buffedAtkSpeed = orgAtkSpd / abilityManager.abilities[i].buffMult;
                while (abilityManager.abilities[i].active)
                {
                    creatureInstance.cooldown = buffedAtkSpeed;
                }
                creatureInstance.cooldown = orgAtkSpd;
                break;
            default:
                break;
        }
    }
}
