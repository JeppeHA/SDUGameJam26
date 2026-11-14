using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "AbilitySO", menuName = "Scriptable Objects/AbilitySO")]
public class AbilitySO : ScriptableObject
{
    public float damage;
    public float cost;
    public float cooldown;
    public bool canUse;
    public AffinityType affinity;
    public string desc;
    public Sprite sprite;
    public AbilityTargetType targetType;
    public float healValue;
    //public Soundtrack
    
    public IEnumerator StartCooldown()
    {
        canUse = false;
        yield return new WaitForSeconds(cooldown);
        canUse = true;
    }
}

public enum AffinityType
{
    None,
    Water,
    Fire,
    Earth,
    Wind
};

public enum AbilityTargetType
{
    Player,
    Creature,
    Enemy
};
