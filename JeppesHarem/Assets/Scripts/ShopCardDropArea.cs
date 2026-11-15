using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopCardDropArea : MonoBehaviour
{
    [SerializeField] private CreatureSO creatureSO;
    [SerializeField] private AbilitySO abilitySO;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private GameObject shadow;
    private ShopManager shopManager;
    private GameObject gameManager;
    private PartyManager partyManager;
    private AbilityManager abilityManager;

    private void Start()
    {
        gameManager = GameObject.FindFirstObjectByType<GameManager>().gameObject;
        partyManager = gameManager.GetComponent<PartyManager>();
        abilityManager = gameManager.GetComponent<AbilityManager>();

        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        shadow = transform.GetChild(1).gameObject;

        shopManager = FindFirstObjectByType<ShopManager>();
    }

    public void OnCardDrop(GameObject card)
    {
        Debug.Log("test");

        if (shopManager.TryGetComponent(out CreatureShop creatureShop))
        {
            if (creatureSO != null) 
            {
                partyManager.RemoveCreature(creatureSO);
            }
            creatureSO = (CreatureSO)card.GetComponent<CardController>().creatureToSpawn;
            spriteRenderer.sprite = creatureSO.sprite;
            shadow.SetActive(true);
            partyManager.AddCreature(creatureSO);

        }
        else if (shopManager.TryGetComponent(out AbilityShop abilityShop))
        {
            if (abilitySO != null)
            {
                abilityManager.RemoveAbility(abilitySO);
            }
            abilitySO = (AbilitySO)card.GetComponent<CardController>().abilityToSpawn;
            spriteRenderer.sprite = abilitySO.sprite;
            shadow.SetActive(true);
            abilityManager.AddAbility(abilitySO);
        }

        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Card"))
        {
            Destroy(item);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (!collision.GetComponent<DragAndDrop>().isDragging)
        {
            OnCardDrop(collision.gameObject);
        }
    }
}
