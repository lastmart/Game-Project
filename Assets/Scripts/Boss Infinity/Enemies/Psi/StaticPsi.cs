using UnityEngine;

public class StaticPsi : Psi
{
    [SerializeField] private int healths = 3;
    
    private float invulnerabilityTimer;
    private bool inInvulnerability;
    
    private Rigidbody2D rb;
    private Animator animator;
    public SpawnerSt2 spawner;
    
    protected override void Start()
    {
        Damage = 1;
        rb = GetComponent<Rigidbody2D>();
    }
    
    private protected override void FixedUpdate()
    {
        var position = transform.position;
        if ((position - targetPosition).magnitude < 0.1) return;
        var newPosition = Vector2.MoveTowards(position, position + direction,
            speed * Time.deltaTime);
        rb.MovePosition(newPosition);
    }
    
    public override void ReceiveDamage(int damage)
    {
        healths -= damage;
        if (healths <= 0) Die();
    }

    protected override void Die()
    {
        spawner.psiIsSpawned = false;
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision) => Attack(collision);

    private void OnCollisionStay2D(Collision2D collision) => Attack(collision);

    private void Attack(Collision2D collision)
    {
        var character = collision.gameObject.GetComponent<Character>();
        if (character is null) return;
        audioManager.Play("Appear");
        character.ReceiveDamage(Damage);
    }
}
