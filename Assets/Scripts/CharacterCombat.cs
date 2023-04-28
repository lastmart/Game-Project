using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    private Animator animator;
    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Attack();
        }
    }

    private void Attack()
    {
        // animator.SetTrigger("Attack"); // turn attack animation
    }
}
