using UnityEngine;
using System.Collections.Generic;

public class Shop : MonoBehaviour
{
    public Object[] allShopItems;
    public List<Object> shopItems = new List<Object>(4);
    private Transform[] spawnPos;
    private int shopCap = 4;
    private GameObject cardPrefab;
    public void LoadShop(string path)
    {
        allShopItems = Resources.LoadAll(path, typeof(ScriptableObject));

        shopItems.Clear();
        if (allShopItems.Length != 0)
        {
            while (shopItems.Count < shopCap)
            {
                CreatureSO itemInfo = (CreatureSO)allShopItems[Random.Range(0, allShopItems.Length)];
                shopItems.Add(itemInfo);
                GameObject shopItem = GameObject.Instantiate(cardPrefab, spawnPos[shopItems.Count - 1].transform);
                shopItem.GetComponent<CardController>().infoDump(itemInfo.name, itemInfo._type.ToString(), $"speed: {itemInfo.atkSpeed}\n dmg: {itemInfo.atk}\n hp: {itemInfo.hp}");
            }
        }
    }
}
