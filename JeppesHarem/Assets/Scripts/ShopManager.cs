using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ShopManager : MonoBehaviour
{
    public GameObject cardPrefab;
    private PartyManager partyManager;
    private AbilityManager abilityManager;
    [SerializeField] List<GameObject> slots = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (MapNode.selectedShopType == MapNode.ShopType.CreatureShop)
        {
            CreatureShop creatureShop = gameObject.AddComponent<CreatureShop>();
            partyManager = FindFirstObjectByType<GameManager>().gameObject.GetComponent<PartyManager>();
            creatureShop.LoadShop("CreatureItems");

            for (int i = 0; i < partyManager.team.Count; i++)
            {
                Debug.Log(i);
                slots[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = partyManager.team[i].sprite;
                slots[i].transform.GetChild(1).gameObject.SetActive(true);
            }

        }
        else if (MapNode.selectedShopType == MapNode.ShopType.AbilityShop)
        {
            AbilityShop abilityShop = gameObject.AddComponent<AbilityShop>();
            abilityManager = FindFirstObjectByType<GameManager>().gameObject.GetComponent<AbilityManager>();
            abilityShop.LoadShop("AbilityItems");

            Destroy(slots[1]);
            slots.RemoveAt(1);

            for (int i = 0; i < abilityManager.abilities.Count; i++)
            {
                Debug.Log(i);
                slots[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = partyManager.team[i].sprite;
                slots[i].transform.GetChild(1).gameObject.SetActive(true);
            }
        }
    }
}