using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class StaticPsi : Psi
{
    [SerializeField] private int healths = 3;
    private const int Damage = 1;
    
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
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        var obj = collision.gameObject.GetComponent<Character>();
        if (obj is null) return;
        obj.ReceiveDamage(Damage);
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
}
