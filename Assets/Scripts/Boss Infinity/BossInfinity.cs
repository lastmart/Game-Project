using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class BossInfinity : Unit
{
    [SerializeField] public int maxLives = 20;
    [SerializeField] public int lives;

    public HealthBar healthBar;
    private new Rigidbody2D rigidbody;
    private Animator animator;
    public BossInfinityLevelController controller;

    public bool isInvulnerable;
    private int CurrentLives { get => lives; set => lives = value; }
    
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
    
    private void Start()
    {
        CurrentLives = maxLives;
        healthBar.SetMaxHealth(maxLives);
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isInvulnerable = true;
    }

    private void FixedUpdate()
    {
        if (lives <= maxLives / 2)
        {
            animator.SetBool("IsEnraged", true);
            controller.SetSecondStage();
        }
        if (lives <= 0)
        {
            Die();
            controller.DisableAll();
        }
    }

    public override void ReceiveDamage(int damage)
    {
        if (isInvulnerable) return;
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
