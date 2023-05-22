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
    public BossInfinityLevelController controller;

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

    protected override void OnTriggerEnter2D(Collider2D col) { }

    protected override void OnTriggerStay2D(Collider2D other) { }
}
