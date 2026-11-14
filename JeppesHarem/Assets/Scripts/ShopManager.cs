using UnityEngine;

public class ShopManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (MapNode.selectedShopType == MapNode.ShopType.CreatureShop)
        {
            gameObject.AddComponent<CreatureShop>();
        }
        else if (MapNode.selectedShopType == MapNode.ShopType.AbilityShop)
        {
            gameObject.AddComponent<AbilityShop>();
        }
    }
}