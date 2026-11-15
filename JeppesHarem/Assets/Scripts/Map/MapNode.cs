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
    public static int completedNodeRank = -1;
    public SceneFader sceneFader;
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

        if (nodeType == NodeType.Combat)
        {
            sceneFader.sceneName = "NotePixels";
        }
        else if (nodeType == NodeType.Shop)
        {
            selectedShopType = shopType;
            sceneFader.sceneName = "Shop";
        }
        sceneFader.FadeAndLoadScene();
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