using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityInput : MonoBehaviour
{
    private CombatManager combatManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        combatManager = FindFirstObjectByType<CombatManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
