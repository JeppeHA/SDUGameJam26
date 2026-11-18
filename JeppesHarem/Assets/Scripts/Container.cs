using UnityEngine;

public class Container : MonoBehaviour
{
    [SerializeField] private PartyManager _partyManager;
    [SerializeField] private AbilityManager _abilityManager;
    [SerializeField] private CombatManager _combatManager;
    
    private ObjectResolver _objectResolver;

    private void Awake()
    {
        _objectResolver = new ObjectResolver();
        
        _objectResolver.RegisterInstance(_partyManager);
        _objectResolver.RegisterInstance(_abilityManager);
        _objectResolver.RegisterInstance(_combatManager);
        
        _objectResolver.Resolve<PartyManager>();
        _objectResolver.Resolve<AbilityManager>();
        _objectResolver.Resolve<CombatManager>();
        
    }
}
