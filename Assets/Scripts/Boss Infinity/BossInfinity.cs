using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BossInfinity : MonoBehaviour
{
    [SerializeField] public int maxLeaves = 20;
    [SerializeField] public int lives;

    private Rigidbody2D rigidbody;
    private Transform transform;
    private Animator animator;

    public Dictionary<Vector2, Vector2> GetFirstStageWay { get; } = new()
    {
        { new Vector2(8,-3), new Vector2(8, 3) },
        { new Vector2(8, 3), new Vector2(-8, 3) },
        { new Vector2(-8, 3), new Vector2(-8, -3) },
        { new Vector2(-8, -3), new Vector2(8, 3) }
    };

    public Dictionary<Vector2, Vector2> GetSecondStageWay { get; } = new()
    {
        { new Vector2(8,-3), new Vector2(8, 3) },
        { new Vector2(8, 3), new Vector2(-8, -3) },
        { new Vector2(-8, -3), new Vector2(-8, 3) },
        { new Vector2(-8, 3), new Vector2(8, 3) }
    };
    
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

    public Vector2 GetClosestTarget()
    { 
        return GetFirstStageWay
            .Select(t => ((rigidbody.position - t.Key).magnitude, t.Key))
            .Min()
            .Key;
    }
        
    private void Die()
    {
        animator.SetBool("IsDied", true);
    }
}
