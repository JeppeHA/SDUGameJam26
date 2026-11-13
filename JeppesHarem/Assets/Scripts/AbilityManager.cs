using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public List<AbilitySO> abilities = new List<AbilitySO>();

    public void AddAbility(AbilitySO ability)
    {
        abilities.Add(ability);
    }

    public void RemoveAbility(AbilitySO ability)
    {
        abilities.Remove(ability);
    }
}