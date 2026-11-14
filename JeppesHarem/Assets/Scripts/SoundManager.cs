using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip btnClick;
    [SerializeField] private AudioClip abilityClick;
    [SerializeField] private AudioClip shopEnter;
    [SerializeField] private AudioClip shopExit;
    [SerializeField] private AudioClip combatAttack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    public void PlaySound(string name)
    {
        switch (name)
        {
            case "btnClick":
                audioSource.clip = btnClick;
                break;

            case "abilityClick":
                audioSource.clip = abilityClick;
                break;

            case "shopEnter":
                audioSource.clip = shopEnter;
                break;

            case "shopExit": 
                audioSource.clip = shopExit;   
                break;

            case "combatAttack":
                audioSource.clip = combatAttack;
                break;

            default:
                Debug.LogWarning("No Audioclip found");
                break;
        }

        audioSource.Play();
    }
}
