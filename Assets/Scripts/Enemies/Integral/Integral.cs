using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Integral : Unit
{
    [SerializeField] private float speed = 4.0f;
    private const int Damage = 1;
    private new Rigidbody2D rigidbody;
    public Vector3 direction;
    public LayerMask playerLayer;
    
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        direction = transform.right;
    }
    
    private void FixedUpdate()
    {
        var position = transform.position;
        var newPosition = Vector2.MoveTowards(position, position + direction,
            speed * Time.deltaTime);
        rigidbody.MovePosition(newPosition);
        CheckCharacter();
    }

    public override void ReceiveDamage(int damage)
    {
        
    }
    
    private void CheckCharacter()
    {
        var hitPlayer = Physics2D.OverlapCircle(transform.position, 1.0f, playerLayer);
        if (hitPlayer is null) return;
        hitPlayer.GetComponent<Character>().ReceiveDamage(Damage);
    }
}
