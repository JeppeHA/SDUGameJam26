using UnityEngine;
using System.Collections.Generic;

public class CreatureShop : Shop
{
    public List<CreatureSO> shopCreatures = new List<CreatureSO>(4);
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shopCreatures.Clear();
        if (allShopItems.Count != 0)
        {
            while (shopCreatures.Count < 4)
            {
                foreach (ScriptableObject obj in allShopItems)
                {
                    if (obj is CreatureSO)
                    {
                        shopCreatures.Add((CreatureSO)allShopItems[Random.Range(0, allShopItems.Count)]);
                    }
                }
            }
        }
    }
}