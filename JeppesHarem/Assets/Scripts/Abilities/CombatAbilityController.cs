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
    private CombatManager combatManager;

    public List<CreatureInstance> creatureInstances;
    public ButtonController btnController;

    [SerializeField] private Slider[] sliders;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        combatManager = FindFirstObjectByType<CombatManager>();
        btnController = FindFirstObjectByType<ButtonController>();
        abilityManager = FindFirstObjectByType<AbilityManager>();

        creatureInstances = combatManager.instantiatedPartyMembers;

        for (int i = 0; i < abilityManager.abilities.Count; i++)
        {
            abilityImages[i].sprite = abilityManager.abilities[i].sprite;
            sliders[i].value = sliders[i].minValue;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AbilityInput(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AbilityInput(1);
        }


        for (int i = 0; i < abilityManager.abilities.Count; i++)
        {
            if (!abilityManager.abilities[i].canUse)
            {
                sliders[i].value -= Time.deltaTime;
            }
        }
    }

    public void AbilityInput(int i)
    {

        if (abilityManager.abilities[i] != null && abilityManager.abilities[i].canUse)
        {
            Debug.Log($"press {i}");
            UseAbility(i);
        }

        


    }

    public IEnumerator StartCooldown(int i)
    {
        abilityManager.abilities[i].canUse = false;
        sliders[i].value = sliders[i].maxValue;
        yield return new WaitForSeconds(abilityManager.abilities[i].cooldown);
        abilityManager.abilities[i].canUse = true;
    }

    public IEnumerator Duration(int i)
    {
        abilityManager.abilities[i].active = true;
        switch (abilityManager.abilities[i].abilityType)
        {
            case AbilityType.AttackBuff:
                for (int j = 0; j < creatureInstances.Count; j++)
                {
                    float orgAtk = creatureInstances[j].atk;
                    float buffedAtk = orgAtk * abilityManager.abilities[i].buffMult;

                    creatureInstances[j].atk = buffedAtk;
                    yield return new WaitForSeconds(abilityManager.abilities[i].duration);
                    creatureInstances[j].atk = orgAtk;
                }

                break;

            case AbilityType.Heal:

                float tmpPerfect = btnController.perfectModifier;
                float tmpGood = btnController.goodModifier;
                float buffedPerfectVibes = tmpPerfect * abilityManager.abilities[i].buffMult;
                float buffedGoodVibes = tmpGood * abilityManager.abilities[i].buffMult;

                btnController.perfectModifier = buffedPerfectVibes;
                btnController.goodModifier = buffedGoodVibes;
                yield return new WaitForSeconds(abilityManager.abilities[i].duration);

                btnController.perfectModifier = tmpPerfect;
                btnController.goodModifier = tmpGood;

                break;

            case AbilityType.AttackSpeedBuff:
                for (int j = 0; j < creatureInstances.Count; j++)
                {
                    float orgAtkSpd = creatureInstances[j].cooldown;
                    float buffedAtkSpeed = orgAtkSpd / abilityManager.abilities[i].buffMult;

                    creatureInstances[j].cooldown = buffedAtkSpeed;
                    yield return new WaitForSeconds(abilityManager.abilities[i].duration);

                    creatureInstances[j].cooldown = orgAtkSpd;
                }


                break;

            default:
                break;
        }

        abilityManager.abilities[i].active = false;
    }

    public void UseAbility(int i)
    {

        StartCoroutine(StartCooldown(i));
        StartCoroutine(Duration(i));
        
    }
}
