using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopCardDropArea : MonoBehaviour
{
    [SerializeField] private CreatureSO creatureSO;
    [SerializeField] private AbilitySO abilitySO;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private ShopManager shopManager;
    private GameObject gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController");
    }

    public void OnCardDrop(GameObject card)
    {
        Debug.Log("test");
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();

        shopManager = FindFirstObjectByType<ShopManager>();
        if (shopManager.TryGetComponent(out CreatureShop creatureShop))
        {
            creatureSO = (CreatureSO)card.GetComponent<CardController>().creatureToSpawn;
            spriteRenderer.sprite = creatureSO.sprite;
            GameObject creature = gameManager.GetComponent<CreatureFactory>().CreatureInstance(creatureSO);
            gameManager.GetComponent<PartyManager>().AddCreature(creature.GetComponent<CreatureInstance>().creature);
            Destroy(creature);

        }
        else if (shopManager.TryGetComponent(out AbilityShop abilityShop))
        {
            abilitySO = (AbilitySO)card.GetComponent<CardController>().abilityToSpawn;
            spriteRenderer.sprite = abilitySO.sprite;
        }
        Destroy(card.gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (!collision.GetComponent<DragAndDrop>().isDragging)
        {
            OnCardDrop(collision.gameObject);
        }
    }
}
