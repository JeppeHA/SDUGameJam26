using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject cardPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (MapNode.selectedShopType == MapNode.ShopType.CreatureShop)
        {
            CreatureShop creatureShop = gameObject.AddComponent<CreatureShop>();
            creatureShop.LoadShop("CreatureItems");
        }
        else if (MapNode.selectedShopType == MapNode.ShopType.AbilityShop)
        {
            gameObject.AddComponent<AbilityShop>();
            AbilityShop abilityShop = gameObject.AddComponent<AbilityShop>();
            abilityShop.LoadShop("AbilityItems");
        }
    }
}