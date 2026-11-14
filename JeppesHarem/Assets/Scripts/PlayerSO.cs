using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "Scriptable Objects/PlayerSO")]
public class PlayerSO : ScriptableObject
{
    public float playerHp;
    public int notes; // Income
    public InstrumentSO playerInstrument;
    public CreatureSO startCreature;
    public AbilitySO firstAbility;
    public AbilitySO secondAbility;
    public Animator animator;
    //public Instrument instrument;

}
