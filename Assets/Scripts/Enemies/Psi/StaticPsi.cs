using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

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
    public SpawnerV2 spawner;
    

    protected override void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    
    private protected override void FixedUpdate()
    {
        var position = transform.position;
        if ((position - TargetPosition).magnitude < 0.1) enabled = false;
        var newPosition = Vector2.MoveTowards(position, position + direction,
            speed * Time.deltaTime);
        rigidbody.MovePosition(newPosition);
        CheckCharacter();
        UpdateInvulnerability();
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
    
    private void CheckCharacter()
    {
        var hitPlayer = Physics2D.OverlapCircle(transform.position, 1.0f, playerLayer);
        if (hitPlayer is null) return;
        hitPlayer.GetComponent<Character>().ReceiveDamage(Damage);
    }
}
