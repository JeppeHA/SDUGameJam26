using System.Collections;
using UnityEngine;

public class EnemyInstance : MonoBehaviour
{
    public EnemySO enemyData;
    
    public float atk;
    public float hp;
    public float cooldown = 0f;
    public bool canAttack;
    private SpriteRenderer spriteRenderer;
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void InitalizeValues()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = enemyData.sprite;
        atk = enemyData.atk;
        hp = enemyData.hp;
        cooldown = enemyData.cooldown;
        canAttack = enemyData.canAttack;
    }
    
    public IEnumerator StartCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(cooldown);
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
