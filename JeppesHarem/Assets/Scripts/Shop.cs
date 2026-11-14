using UnityEngine;
using System.Collections.Generic;

public abstract class Shop : MonoBehaviour
{
    public Object[] allShopItems;
    public List<Object> shopItems = new List<Object>(4);
    [SerializeField] private GameObject[] spawnPos;
    private int shopCap = 4;
    private ShopManager shopManager;
    
    public void LoadShop(string path)
    {
        shopManager = GetComponent<ShopManager>();
        spawnPos = GameObject.FindGameObjectsWithTag("shopSpawn");
        allShopItems = Resources.LoadAll(path, typeof(ScriptableObject));

        shopItems.Clear();
        if (allShopItems.Length != 0)
        {
            while (shopItems.Count < shopCap)
            {
                InfoDump(shopManager.cardPrefab, spawnPos);
            }
        }
    }

    public abstract void InfoDump(GameObject cardPrefab, GameObject[] spawnPos);
}
