using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class Character : Unit
{
    [SerializeField] public AudioManager amanager;
    [SerializeField] public int lives;
    [SerializeField] private float speed = 4.0f;
    [SerializeField] private float jumpForce = 10.0f;
    [SerializeField] private float jumpTime = 0.25f;
    [SerializeField] private float timeOfInvulnerability = 0.6f;
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private int attackDamage = 1;
    [SerializeField] private float groundCheck = 0.3f;
    public float attackRate = 2f;
    public int maxLives = 3;

    private new Rigidbody2D rigidbody;
    private Animator animator;
    private new Transform transform;
    public CharLivesBar charLivesBar;
    public Transform attackPoint;
    public Transform groundPosition;
    public LayerMask enemyLayers;
    public LayerMask groundLayers;
    public LevelManager manager;
    
    private float invulnerabilityTimer;
    private float jumpTimeCounter;
    private float nextAttackTime;
    
    private bool isJumping;
    private bool isGrounded;
    public bool isFacingRight;
    public bool inInvulnerability;
    
    private static readonly int State = Animator.StringToHash("State");
    
    private CharacterState state
    {
        get => (CharacterState)animator.GetInteger(State);
        set => animator.SetInteger(State, (int)value);
    }

    private void Awake()
    {
        lives = maxLives;
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
        if (isGrounded) isJumping = false;
    }

    private void UpdateInvulnerability()
    {
        if (!inInvulnerability) return;
        invulnerabilityTimer -= Time.deltaTime;
        if (invulnerabilityTimer < 0)
        {
            inInvulnerability = false;
        }
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
        if (isGrounded && !isJumping)
        {
            amanager.Play("Jump");
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
        amanager.Play("ReceiveDamage");
        animator.SetTrigger("IsAttacked");
        lives -= damage;
        state = CharacterState.Attacked;
        charLivesBar.Refresh();
        if (lives <= 0) Die();
        inInvulnerability = true;
        invulnerabilityTimer = timeOfInvulnerability;
    }

    protected override void Die()
    {
        state = CharacterState.Died;
        manager.ShowGameOverWindow();
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void Attack()
    {
        animator.SetTrigger("IsAttack");
        state = CharacterState.Idle;
        var hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        if (hitEnemies.Length == 0) amanager.Play("MissSword");
        foreach (var enemy in hitEnemies)
        { 
            if (enemy.GetComponent<Unit>() != null)
            {
                amanager.Play("NotMissSword");
                enemy.GetComponent<Unit>().ReceiveDamage(attackDamage);
            }
            //enemy.GetComponent<Unit>()?.ReceiveDamage(attackDamage);
            Debug.Log("We hit "+ enemy.name);
        }
        nextAttackTime = Time.time + 1f / attackRate;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Spores"))
        {
            ReceiveDamage(1);
            // poisoned character animation
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint is null || groundPosition is null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        Gizmos.DrawWireSphere(groundPosition.position, groundCheck);
    }
}

public enum CharacterState
{
    Idle = 0,
    Run = 1,
    Jump = 2,
    Died = 3,
    Attacked = 4
}