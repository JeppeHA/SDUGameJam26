using UnityEngine;

[CreateAssetMenu(fileName = "CreatureSO", menuName = "Scriptable Objects/Creature")]
public class CreatureSO : ScriptableObject
{
    public float hp;
    public float atkSpeed;
    public float atk;
    public Sprite sprite;
    private Typing _type;
    public Animator animator;
    
    
    
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
