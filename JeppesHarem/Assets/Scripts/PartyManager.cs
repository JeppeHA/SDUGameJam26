using UnityEngine;
using System.Collections.Generic;

public class PartyManager : MonoBehaviour
{
    public List<CreatureSO> team = new List<CreatureSO>();
    public int teamCap = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void AddCreature(CreatureSO newCreature)
    {
        if (team.Count >= teamCap)
        {
            return;
        }
        team.Add(newCreature);
    }

    public void RemoveCreature(CreatureSO oldCreature)
    {
        if (team.Count <= 0)
        {
            return;
        }
        team.Remove(oldCreature);
    }
}
