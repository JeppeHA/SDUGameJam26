using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private InputActionReference[] laneActions; 
    [SerializeField] private ButtonController[] laneControllers; 
    private CombatManager combatManager;
    private PlayerInstance playerInstance;
    private CreatureInstance creatureInstance;
    
    void OnEnable()
    {
        for (int i = 0; i < laneActions.Length; i++)
        {
            int lane = i;
            laneActions[i].action.performed += ctx => OnLanePressed(lane);
            laneActions[i].action.Enable();
        }
    }

    void OnDisable()
    {
        foreach (var a in laneActions)
            a.action.Disable();
    }

    private void OnLanePressed(int lane)
    {
        laneControllers[lane].CheckHit();
    }

    public void Start()
    {
        combatManager = FindFirstObjectByType<CombatManager>();
        playerInstance = FindFirstObjectByType<PlayerInstance>();
        creatureInstance = FindFirstObjectByType<CreatureInstance>();
    }

    public void AbilityInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            switch (playerInstance.ability1.targetType)
            {
                case AbilityTargetType.Player:
                    playerInstance.HealPlayer(playerInstance.ability1);
                    break;
                case AbilityTargetType.Creature:
                    //Logic
                    break;
                case AbilityTargetType.Enemy:
                    //logic for applying dmg to enemy if damaging ability type
                    break;
                default:
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            switch (playerInstance.ability2.targetType)
            {
                case AbilityTargetType.Player:
                    playerInstance.HealPlayer(playerInstance.ability2);
                    break;
                case AbilityTargetType.Creature:
                    //logic
                    break;
                case AbilityTargetType.Enemy:
                    //logic for applying dmg to enemy if damaging ability type
                    break;
                default:
                    break;
            }
        }
    }
}