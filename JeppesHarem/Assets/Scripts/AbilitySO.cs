using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "AbilitySO", menuName = "Scriptable Objects/AbilitySO")]
public class AbilitySO : ScriptableObject
{
    public float damage;
    public float cost;
    public float cooldown;
    public bool canUse;
    
    public IEnumerator StartCooldown()
    {
        canUse = false;
        yield return new WaitForSeconds(cooldown);
        canUse = true;
    }
}
