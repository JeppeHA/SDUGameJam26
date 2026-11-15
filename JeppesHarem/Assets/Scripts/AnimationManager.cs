using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    int count = 0;

    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("Animal", 0);
    }

   
    void FixedUpdate()
    {
       if  (count > 250){
            animator.SetTrigger("Attack");
            count = 0;
        }
       count++;
    }
}
