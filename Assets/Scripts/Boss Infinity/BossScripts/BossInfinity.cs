using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BossInfinity : Unit
{
    [Header("Physics parameters")]
    [SerializeField] private int maxLives = 20;
    [SerializeField] private int lives;
    private int lifeAtBeginningSecondStage;
    
    [Header("Related objects")]
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private GameObject hurtEffect;
    public BossInfinityLevelController controller;
    private Rigidbody2D rb;
    private Animator animator;

    public bool isInvulnerable;
    private int CurrentLives { get => lives; set => lives = value; }

    static BossInfinity()
    {
        GetFirstStageWay = new Dictionary<Vector2, Vector2>
        {
            { new Vector2(10,-4), new Vector2(10, 3) },
            { new Vector2(10, 3), new Vector2(-10, 3) },
            { new Vector2(-10, 3), new Vector2(-10, -4) },
            { new Vector2(-10, -4), new Vector2(10, -4) }
        };
        
        GetSecondStageWay = new Dictionary<Vector2, Vector2>()
        {
            { new Vector2(10,-4), new Vector2(10, 3) },
            { new Vector2(10, 3), new Vector2(-10, -4) },
            { new Vector2(-10, -4), new Vector2(-10, 3) },
            { new Vector2(-10, 3), new Vector2(10, -4) }
        };
    }
    
    public static Dictionary<Vector2, Vector2> GetFirstStageWay { get; } 
    
    public static Dictionary<Vector2, Vector2> GetSecondStageWay { get; }
    
    
    private void Start()
    {
        CurrentLives = maxLives;
        lifeAtBeginningSecondStage = maxLives / 2;
        healthBar.SetMaxHealth(maxLives);
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isInvulnerable = true;
    }

    private void UpdateStageState()
    {
        if (lives <= lifeAtBeginningSecondStage)
        {
            controller.Stage = BossInfinityStages.Second;
            animator.SetBool("IsEnraged", true);
        }
        if (lives <= 0)
        {
            controller.Stage = BossInfinityStages.End;
            Die();
        }
    }

    public override void ReceiveDamage(int damage)
    {
        if (isInvulnerable) return;
        lives -= damage;
        healthBar.SetHealth(lives);
        animator.SetTrigger("IsAttacked");
        Instantiate(hurtEffect, transform.position, Quaternion.identity);
        UpdateStageState();
    }

    public Vector2 GetClosestTarget()
    {
        return GetFirstStageWay
            .OrderBy(t => (rb.position - t.Key).magnitude)
            .First()
            .Key;
    }

    protected override void Die()
    {
        animator.SetBool("IsDied", true);
    }
}
