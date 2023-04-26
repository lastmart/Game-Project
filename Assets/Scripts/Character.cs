using Unity.VisualScripting;
using UnityEngine;

public class Character : Unit
{
    [SerializeField] private int lives = 3;
    [SerializeField] private float speed = 4.0f;
    [SerializeField] private float jumpForce = 10.0f;
    [SerializeField] private float jumpTime = 0.35f;
    
    private static readonly int State = Animator.StringToHash("State");
    
    private new Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;
    
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
    }

    private void Update()
    {
        if (isGrounded) state = CharacterState.Idle;
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
    
    private void LifeSubtraction()
    {
        if (lives > 0)
        {
            lives -= 1;
            transform.position = new Vector3(-3f, 0f, 0);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = collision.gameObject.CompareTag($"Ground");
    }
}

public enum CharacterState
{
    Idle = 0,
    Run = 1,
    Jump = 3
}