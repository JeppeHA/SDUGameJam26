using UnityEngine;

public class AbilityFactory : MonoBehaviour
{
    public GameObject abilityPrefab;

    public GameObject AbilityInstance(AbilitySO abilityData)
    {
        GameObject abilityInstance = Instantiate(abilityPrefab);
        abilityInstance.GetComponent<AbilityInstance>().Setup(abilityData);
        return abilityInstance; 
    }
}
