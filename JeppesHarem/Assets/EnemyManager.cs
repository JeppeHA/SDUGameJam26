using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    CombatManager cm;
    public static EnemyManager Instance { get; private set; }
    private void Awake()
        {
    
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
            DontDestroyOnLoad(this);
            
        }
        
    public void SetEnemiesCount()
    {
        cm = FindFirstObjectByType<CombatManager>();
        cm.combatCount++;
    }
        
    
}
