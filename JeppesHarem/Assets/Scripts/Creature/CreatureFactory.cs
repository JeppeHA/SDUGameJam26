using UnityEngine;

public class CreatureFactory : MonoBehaviour
{
    public GameObject creaturePrefab;
    
    public GameObject CreatureInstance(CreatureSO creatureData)
    {
        GameObject creatureInstance = Instantiate(creaturePrefab);
        creatureInstance.GetComponent<CreatureInstance>().SetStats(creatureData);
        return creatureInstance;
    }
}
