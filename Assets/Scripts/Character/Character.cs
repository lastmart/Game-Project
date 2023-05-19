using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class Character : Unit
{
    [SerializeField] public int lives = 3;
    [SerializeField] private float speed = 4.0f;
    [SerializeField] private float jumpForce = 10.0f;
    [SerializeField] private float jumpTime = 0.25f;
    [SerializeField] private float invulnerabilityDuration;
    [SerializeField] private float timeOfInvulnerability = 1.5f;
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private int attackDamage = 1;
    [SerializeField] private float groundCheck = 0.3f;
    
    private static readonly int State = Animator.StringToHash("State");

    private new Rigidbody2D rigidbody;
    private Animator animator;
    private new Transform transform;
    public CharLivesBar charLivesBar;
    public Transform attackPoint;
    public Transform groundPosition;
    public LayerMask enemyLayers;
    [FormerlySerializedAs("groundLayer")] public LayerMask groundLayers;
    
    private float invulnerabilityTimer;
    private float jumpTimeCounter;
    private float nextAttackTime;
    public float attackRate = 2f;
    
    private bool isJumping;
    private bool isGrounded;
    private bool isFacingRight;
    private bool inInvulnerability;
    
    
    private CharacterState state
    {
        get => (CharacterState)animator.GetInteger(State);
        set => animator.SetInteger(State, (int)value);
    }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        transform = GetComponent<Transform>();
    }
    
    private void FixedUpdate()
    {
        if (isGrounded) state = CharacterState.Idle;
        UpdateInvulnerability();
        if (Input.GetButton("Horizontal")) Run();
        if (Input.GetButton("Fire1") && Time.time >= nextAttackTime) Attack();
        else if (Input.GetButton("Jump")) Jump();
        if (Input.GetButtonUp("Jump")) isJumping = false;
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundPosition.position, groundCheck, groundLayers);
    }

    private void UpdateInvulnerability()
    {
        if (!inInvulnerability) return;
        invulnerabilityDuration -= Time.deltaTime;
        if (invulnerabilityDuration < 0) inInvulnerability = false;
    }

    private void Run()
    {
        var direction = transform.right * Input.GetAxis("Horizontal");
        var position = transform.position; 
        transform.position = Vector3.MoveTowards(position, position + direction, speed * Time.deltaTime);
        if (direction.x < 0 && !isFacingRight || direction.x > 0 && isFacingRight) Flip();
        if (isGrounded) state = CharacterState.Run;
    }
    
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        var theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void Jump()
    {
        if (isGrounded)
        {
            state = CharacterState.Jump;
            rigidbody.velocity = transform.up * jumpForce;
            jumpTimeCounter = jumpTime;
            isJumping = true;
            isGrounded = false;
        }

        if (!isJumping) return;
        
        if (jumpTimeCounter > 0)
        {
            rigidbody.velocity = transform.up * jumpForce;
            jumpTimeCounter -= Time.deltaTime;
        }
        else
        {
            isJumping = false;
        }
    }
    
    public override void ReceiveDamage(int damage)
    {
        if (inInvulnerability) return;
        lives -= damage;
        charLivesBar.Refresh();
        if (lives <= 0) Die();
        inInvulnerability = true;
        invulnerabilityDuration = timeOfInvulnerability;
        animator.SetTrigger("IsAttacked");
    }

    protected override void Die()
    {
        
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void Attack()
    {
        animator.SetTrigger("IsAttack");
        state = CharacterState.Idle;
        var hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (var enemy in hitEnemies)
        {
            enemy.GetComponent<BossInfinity>()?.ReceiveDamage(attackDamage);
            enemy.GetComponent<StaticPsi>()?.ReceiveDamage(attackDamage);
            Debug.Log("We hit "+ enemy.name);
        }
        nextAttackTime = Time.time + 1f / attackRate;
    }
    
    private void OnDrawGizmosSelected()
    {
        if (attackPoint is null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        Gizmos.DrawWireSphere(groundPosition.position, groundCheck);
    }
}

public enum CharacterState
{
    Idle = 0,
    Run = 1,
    Jump = 2,
    Died = 3
}