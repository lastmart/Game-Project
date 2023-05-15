using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BossInfinity : Unit
{
    [SerializeField] public int maxLives = 20;
    [SerializeField] public int lives;

    public HealthBar healthBar;
    private new Rigidbody2D rigidbody;
    private Animator animator;
    public bool inRange;

    protected int CurrentLives { get => lives; set => lives = value; }
    
    public Dictionary<Vector2, Vector2> GetFirstStageWay { get; } = new()
    {
        { new Vector2(11,-4), new Vector2(11, 2) },
        { new Vector2(11, 2), new Vector2(-11, 2) },
        { new Vector2(-11, 2), new Vector2(-11, -4) },
        { new Vector2(-11, -4), new Vector2(11, -4) }
    };
    
    public Dictionary<Vector2, Vector2> GetSecondStageWay { get; } = new()
    {
        { new Vector2(11,-4), new Vector2(11, 2) },
        { new Vector2(11, 2), new Vector2(-11, -4) },
        { new Vector2(-11, -4), new Vector2(-11, 2) },
        { new Vector2(-11, 2), new Vector2(11, -4) }
    };
    
    private void Awake()
    {
        CurrentLives = maxLives;
        healthBar.SetMaxHealth(maxLives);
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (lives <= maxLives / 2)
        {
            animator.SetBool("IsEnraged", true);
            inRange = true;
        }
        if (lives <= 0) Die();
    }

    public override void ReceiveDamage(int damage)
    {
        lives -= damage;
        healthBar.SetHealth(lives);
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
