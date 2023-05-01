using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Integral : Unit
{
    [SerializeField] private float speed = 4.0f;
    private const int Damage = 1;

    private new Rigidbody2D rigidbody;
    private new Transform transform;
    private readonly Vector3 direction = new (1,0);
    public LayerMask playerLayer;
    
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
    }
    
    private void Update()
    {
        var position = transform.position;
        var newPosition = Vector2.MoveTowards(position, position + direction,
            speed * Time.deltaTime);
        transform.position = newPosition;
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
        Debug.Log("We hit "+ hitPlayer.name);
    }
}
