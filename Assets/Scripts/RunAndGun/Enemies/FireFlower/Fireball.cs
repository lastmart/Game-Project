using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private int damage = 1;
    
    private GameObject explosion;
    
    private void Start()
    {
        Destroy(gameObject, 3f);
        explosion = Resources.Load<GameObject>("RunAndGun/Enemies/Explosion");
    }
    
    private void FixedUpdate()
    {
        var transform1 = transform;
        var position = transform1.position;
        transform.position = Vector3.MoveTowards(position, position + transform1.right, 
            speed * Time.deltaTime);
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        var character = col.gameObject.GetComponent<Character>();
        Destroy(gameObject);
        Instantiate(explosion, transform.position, Quaternion.identity);
        character?.ReceiveDamage(damage);
    }
}
