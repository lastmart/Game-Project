using UnityEngine;

public class BossInfinity : MonoBehaviour
{
    [SerializeField] public int maxLeaves = 20;
    [SerializeField] public int lives;

    public GameObject deathEffect;
    private Rigidbody2D rigidbody;
    private Transform transform;
    private Animator animator;
    
    private void Awake()
    {
        lives = maxLeaves;
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        transform = GetComponent<Transform>();
    }

    private void Update()
    {
        if (lives <= maxLeaves / 2) animator.SetBool("IsEnraged", true);
    }

    public void ReceiveDamage(int damage)
    {
        lives -= damage;
        
        // Boss hurt animation
        
        if (lives <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
    }
}
