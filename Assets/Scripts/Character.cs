using System;
using Unity.VisualScripting;
using UnityEngine;

public class Character : Unit
{
    [SerializeField] private int lives = 3;
    [SerializeField] private float speed = 4.0f;
    [SerializeField] private float jumpForce = 10.0f;
    [SerializeField] private float jumpTime = 0.35f;
    [SerializeField]private float startRecharge = 0.1f;
    
    private static readonly int State = Animator.StringToHash("State");
    
    private new Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;
    private new Transform transform;
    
    //Attack
    private LayerMask selectedEnemy;
    private float attackRadius;
    private int damage;
    private float recharge;

    //Moving
    private float jumpTimeCounter;
    private bool isJumping;
    private bool isGrounded;
    

    private CharacterState state
    {
        get => (CharacterState)animator.GetInteger(State);
        set => animator.SetInteger(State, (int)value);
    }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        transform = GetComponent<Transform>();
    }
    
    private void Update()
    {
        if (isGrounded) state = CharacterState.Idle;
        if (IsAttack()) MakeAttack();
        if (Input.GetButton("Horizontal")) Run();
        if (Input.GetButton("Jump")) Jump();
        if (transform.localPosition.y < -20) LifeSubtraction();
    }

    private void FixedUpdate()
    {
        
    }

    private void Run()
    {
        var direction = transform.right * Input.GetAxis("Horizontal");
        var position = transform.position;
        position = Vector3.MoveTowards(position, position + direction, speed * Time.deltaTime);
        transform.position = position;
        sprite.flipX = direction.x < 0.0;
        if (isGrounded) state = CharacterState.Run;
    }

    private void Jump()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rigidbody.velocity = transform.up * jumpForce;
            jumpTimeCounter = jumpTime;
            isJumping = true;
        }
        
        if (Input.GetButton("Jump") && isJumping)
        {
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

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }
        
        isGrounded = false;
        state = CharacterState.Idle; // нужна анимация прыжка
    }
    
    private bool IsAttack()
    {
        if (recharge <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                // attack animation
            }

            recharge = startRecharge;
            return true;
        }
    
        recharge -= Time.deltaTime;
        return false;
    }

    private void MakeAttack()
    {
        var enemies = Physics2D.OverlapCircleAll(transform.position, attackRadius, selectedEnemy);
        foreach (var enemy in enemies)
        {
            enemy.GetComponent<Unit>().ReceiveDamage(damage);
        }
    }
    
    private void LifeSubtraction()
    {
        if (lives <= 0) return;
        lives -= 1;
        transform.position = new Vector3(-3f, 0f, 0);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("OneWayPlatform");
    }
}

public enum CharacterState
{
    Idle = 0,
    Run = 1,
    Jump = 3,
    Attack = 4
}