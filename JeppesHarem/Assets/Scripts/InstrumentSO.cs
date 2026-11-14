using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "InstrumentSO", menuName = "Scriptable Objects/InstrumentSO")]
public class InstrumentSO : ScriptableObject
{
    public AbilitySO ability;
    public Sprite sprite;
}

public enum Affinity
{
    None,
    Water,
    Fire,
    Earth,
    Wind
};

