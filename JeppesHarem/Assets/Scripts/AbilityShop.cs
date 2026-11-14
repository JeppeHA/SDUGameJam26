using UnityEngine;
using System.Collections.Generic;

public class AbilityShop : Shop
{
    public List<AbilitySO> shopAbilities = new List<AbilitySO>(4);
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shopAbilities.Clear();
        if (allShopItems.Count != 0)
        {
            while (shopAbilities.Count < 4)
            {
                foreach (ScriptableObject obj in allShopItems)
                {
                    if (obj is CreatureSO)
                    {
                        shopAbilities.Add((AbilitySO)allShopItems[Random.Range(0, allShopItems.Count)]);
                    }
                }
            }
        }
    }
}