using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BossInfinity : Unit
{
    [SerializeField] public int maxLives = 20;
    [SerializeField] public int lives;

    public BossInfinityLevelController controller;
    public HealthBar healthBar;
    private new Rigidbody2D rigidbody;
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
        healthBar.SetMaxHealth(maxLives);
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isInvulnerable = true;
    }

    private void UpdateStageState()
    {
        if (lives <= maxLives / 2)
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
        UpdateStageState();
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
