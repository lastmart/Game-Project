using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Integral : Enemy
{
    [SerializeField] private float speed = 4.0f;
    
    private Rigidbody2D rb;
    public Vector3 direction;
    
    private void Start()
    {
        Damage = 1;
        rb = GetComponent<Rigidbody2D>();
        direction = transform.right;
    }
    
    private void FixedUpdate()
    {
        var position = transform.position;
        var newPosition = Vector2.MoveTowards(position, position + direction,
            speed * Time.deltaTime);
        rb.MovePosition(newPosition);
    }

    public override void ReceiveDamage(int damage)
    {
        
    }
}
