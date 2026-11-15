using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "AbilitySO", menuName = "Scriptable Objects/AbilitySO")]
public class AbilitySO : ScriptableObject
{
    public float cooldown;
    public float duration;
    public bool canUse;
    public bool active;
    public AbilityType abilityType;
    public string name;
    public string desc;
    public Sprite sprite;
    public float healValue;
    public float buffMult;
    //public Soundtrack
}

public enum AbilityType
{
    Heal,
    AttackBuff,
    AttackSpeedBuff,
};

public enum AbilityTargetType
{
    Player,
    Creature,
    Enemy
};
