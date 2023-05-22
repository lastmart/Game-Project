using UnityEngine;

public class StaticPsi : Psi
{
    [SerializeField] private float timeOfInvulnerability = 1.5f;
    [SerializeField] private float invulnerabilityDuration;
    [SerializeField] private int healths = 3;
    
    private const int Damage = 1;
    private float invulnerabilityTimer;
    private bool inInvulnerability;
    
    private new Rigidbody2D rigidbody;
    private Animator animator;
    public SpawnerSt2 spawner;
    
    protected override void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    
    private protected override void FixedUpdate()
    {
        var position = transform.position;
        UpdateInvulnerability();
        if ((position - TargetPosition).magnitude < 0.1) return;
        var newPosition = Vector2.MoveTowards(position, position + direction,
            speed * Time.deltaTime);
        rigidbody.MovePosition(newPosition);
    }
    
    private void UpdateInvulnerability()
    {
        if (!inInvulnerability) return;
        invulnerabilityDuration -= Time.deltaTime;
        if (invulnerabilityDuration < 0) inInvulnerability = false;
    }
    
    public override void ReceiveDamage(int damage)
    {
        if (inInvulnerability) return;
        healths -= damage;
        if (healths <= 0) Die();
        inInvulnerability = true;
        invulnerabilityDuration = timeOfInvulnerability;
    }

    protected override void Die()
    {
        spawner.psiIsSpawned = false;
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision) => HitCharacter(collision);

    private void OnCollisionStay2D(Collision2D collision) => HitCharacter(collision);

    private void HitCharacter(Collision2D collision)
    {
        var character = collision.gameObject.GetComponent<Character>();
        if (character is null) return;
        character.ReceiveDamage(Damage);
    }
}
