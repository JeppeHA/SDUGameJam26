using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void SelectNode()
    {
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
}
