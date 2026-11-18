using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Runtime.CompilerServices;

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
    public int rank = 0;
    public List<MapNode> connectedNodes = new List<MapNode>();
    public static int completedNodeRank = -1;
    public SceneFader sceneFader;
    public SpriteChanger spriteChanger;

    [SerializeField] List<MapNode> allMapNodes = new List<MapNode> ();

    private List<int> completedNodes = new List<int>();
    void Start()
    {
        if (completedNodeRank == 4)
        {
            SceneManager.LoadScene("Credits");
        }

        spriteChanger = GetComponent<SpriteChanger>();

        completedNodes = FindFirstObjectByType<GameManager>().GetComponent<MapManager>().completedNodes;
        Debug.Log(completedNodes.Count);

        for (int i = 0; i < allMapNodes.Count; i++) 
        {
            if (completedNodes.Contains(i) /*&& allMapNodes[i].nodeType == NodeType.Combat*/)
            {
                allMapNodes[i].spriteChanger.SpriteChange();
            }
        }

        if (rank == completedNodeRank)
        {               
            foreach (MapNode node in FindObjectsByType<MapNode>(FindObjectsSortMode.None))
            {
                node.GetComponent<Button>().interactable = false;
            }
            CompleteNode(allMapNodes[completedNodes[completedNodes.Count - 1]]);
        }
    }

    public void SelectNode()
    {
        for (int i = 0; i < allMapNodes.Count; i++)
        {
            if (allMapNodes[i].gameObject == this.gameObject)
            {
                completedNodes.Add(i);
            }
        }

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
    public void CompleteNode(MapNode node)
    {
        //GetComponent<UnityEngine.UI.Button>().interactable = false;
        foreach (MapNode connection in node.connectedNodes)
        {
            connection.GetComponent<UnityEngine.UI.Button>().interactable = true;
        }
    }
}