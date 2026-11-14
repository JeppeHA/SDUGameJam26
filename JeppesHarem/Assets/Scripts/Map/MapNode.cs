using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;

public class MapNode : MonoBehaviour
{
    public enum NodeType
    {
        Combat,
        Shop
    }
public enum ShopType
    {
        CreatureShop,
        AbilityShop
    }

    public NodeType nodeType;
    public ShopType shopType;
    public static ShopType selectedShopType;
    public int rank;
    public List<MapNode> connectedNodes = new List<MapNode>();
    public static MapNode selectedNode;
    public static int completedNodeRank = -1;
    void Start()
    {
        if (rank == completedNodeRank)
        {
            foreach (MapNode node in FindObjectsByType<MapNode>(FindObjectsSortMode.None))
            {
                node.GetComponent<Button>().interactable = false;
            }
            CompleteNode();
        }
    }
    public void SelectNode()
    {
        completedNodeRank = rank;
        selectedNode = this;

        if (nodeType == NodeType.Combat)
        {
            SceneManager.LoadScene("Gameplay");
        }
        else if (nodeType == NodeType.Shop)
        {
            selectedShopType = shopType;
            SceneManager.LoadScene("Shop");
        }    
    }
    public void CompleteNode()
    {
        GetComponent<UnityEngine.UI.Button>().interactable = false;

        foreach (MapNode node in connectedNodes)
        {
            node.GetComponent<UnityEngine.UI.Button>().interactable = true;
        }
    }
}