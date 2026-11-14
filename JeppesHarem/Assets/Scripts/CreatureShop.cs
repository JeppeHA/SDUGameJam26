using UnityEngine;
using System.Collections.Generic;

public class CreatureShop : Shop
{
    public override void InfoDump(GameObject cardPrefab, GameObject[] spawnPos)
    {
        CreatureSO itemInfo = (CreatureSO)allShopItems[Random.Range(0, allShopItems.Length)];
        shopItems.Add(itemInfo);
        Debug.Log(cardPrefab.gameObject.name);
        GameObject shopItem = GameObject.Instantiate(cardPrefab, spawnPos[shopItems.Count - 1].transform.localPosition, Quaternion.identity);
        shopItem.GetComponent<CardController>().infoDump(itemInfo.name, itemInfo._type.ToString(), $"speed: {itemInfo.atkSpeed}\n dmg: {itemInfo.atk}\n hp: {itemInfo.hp}", itemInfo.sprite, spawnPos[shopItems.Count - 1].transform.localPosition, itemInfo);
    }
}