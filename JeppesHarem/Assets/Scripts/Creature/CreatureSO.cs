using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "CreatureSO", menuName = "Scriptable Objects/Creature")]
public class CreatureSO : ScriptableObject
{
    public string name;
    public float hp;
    public float atkSpeed;
    public float atk;
    public Sprite sprite;
    public Typing _type;
    public int animator;
    public bool canAttack;
    public float cooldown = 0f;


    public Typing Get()
    {
        return _type;
    }
}

public enum Typing
{
    water,
    fire,
    grass,
    ground
};
