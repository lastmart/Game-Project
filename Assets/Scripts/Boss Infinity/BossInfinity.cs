using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BossInfinity : Unit
{
    [SerializeField] public int maxLives = 20;
    [SerializeField] public int lives;

    private new Rigidbody2D rigidbody;
    private Animator animator;

    protected int CurrentLives { get => lives; set => lives = value; }
    
    public Dictionary<Vector2, Vector2> GetFirstStageWay { get; } = new()
    {
        { new Vector2(8,-3), new Vector2(8, 3) },
        { new Vector2(8, 3), new Vector2(-8, 3) },
        { new Vector2(-8, 3), new Vector2(-8, -3) },
        { new Vector2(-8, -3), new Vector2(8, -3) }
    };
    
    public Dictionary<Vector2, Vector2> GetSecondStageWay { get; } = new()
    {
        { new Vector2(8,-3), new Vector2(8, 3) },
        { new Vector2(8, 3), new Vector2(-8, -3) },
        { new Vector2(-8, -3), new Vector2(-8, 3) },
        { new Vector2(-8, 3), new Vector2(8, -3) }
    };
    
    private void Awake()
    {
        CurrentLives = maxLives;
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (lives <= maxLives / 2) animator.SetBool("IsEnraged", true);
        if (lives <= 0) Die();
    }

    public override void ReceiveDamage(int damage)
    {
        lives -= damage;
        
        // Boss hurt animation
    }

    public Vector2 GetClosestTarget()
    {
        return GetFirstStageWay
            .OrderBy(t => (rigidbody.position - t.Key).magnitude)
            .First()
            .Key;
    }

    protected override void Die()
    {
        animator.SetBool("IsDied", true);
    }
}
