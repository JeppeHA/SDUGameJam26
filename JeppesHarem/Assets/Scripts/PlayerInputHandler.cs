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
        laneControllers[lane].LightUp(GetKeyColor(lane));
    }

    private Color GetKeyColor(int lane)
    {
        Color color =  Color.white;
        switch (lane)
        {
            case 0:
                color = new Color32(68, 57, 163,255);
                break;
            case 1:
                color = new  Color32(228, 66, 67,255);
                break;
            case 2:
                color = new Color32(37, 150, 190,255);
                break;
            case 3:
                color = new Color32(112, 62, 179,255);
                break;
        }
        return color;
    }

    public void Start()
    {
        combatManager = FindFirstObjectByType<CombatManager>();
        playerInstance = FindFirstObjectByType<PlayerInstance>();
        creatureInstance = FindFirstObjectByType<CreatureInstance>();
    }


}