using UnityEngine;

public class ShopCardDropArea : MonoBehaviour, ICardDropArea
{
    [SerializeField] private GameObject spawnObject;

    public void OnCardDrop(ShopCard card)
    {
        Destroy(card.gameObject);
        Instantiate(spawnObject, transform.position, transform.rotation);
    }
}
