using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private int attackDamage = 5;
    
    public float attackRate = 2f;
    private float nextAttackTime;
    
    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    
    private void FixedUpdate()
    {
        if (!(Time.time >= nextAttackTime)) return;
        if (Input.GetMouseButton(0))
        {
            Attack();
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void Attack()
    {
        animator.SetTrigger("IsAttack");
        var hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (var enemy in hitEnemies)
        {
            enemy.GetComponent<BossInfinity>().ReceiveDamage(attackDamage);
            Debug.Log("We hit "+ enemy.name);
        }
        nextAttackTime = Time.time + 1f / attackRate;
    }
    
    private void OnDrawGizmosSelected()
    {
        if (attackPoint is null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
