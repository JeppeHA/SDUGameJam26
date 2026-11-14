using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "CreatureSO", menuName = "Scriptable Objects/Creature")]
public class CreatureSO : ScriptableObject
{
    public float hp;
    public float atkSpeed;
    public float atk;
    public Sprite sprite;
    private Typing _type;
    public Animator animator;
    public bool canAttack;
    private float cooldown = 0f;


    public IEnumerator StartCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(cooldown);
        canAttack = true;
    }


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
