using UnityEngine;
using System.Collections.Generic;

public class AbilityShop : Shop
{
    public override void InfoDump(GameObject cardPrefab, GameObject[] spawnPos)
    {
        AbilitySO itemInfo = (AbilitySO)allShopItems[Random.Range(0, allShopItems.Length)];
        shopItems.Add(itemInfo);
        GameObject shopItem = GameObject.Instantiate(cardPrefab, spawnPos[shopItems.Count - 1].transform.localPosition, Quaternion.identity);
        shopItem.GetComponent<CardController>().infoDump(itemInfo.name, itemInfo.affinity.ToString(), itemInfo.desc, itemInfo.sprite, spawnPos[shopItems.Count - 1].transform.localPosition, itemInfo);
    }
}