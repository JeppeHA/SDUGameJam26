using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private InputActionReference[] laneActions; 
    [SerializeField] private ButtonController[] laneControllers; 

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
}