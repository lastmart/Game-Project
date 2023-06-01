using UnityEngine;

public class FallingPlant : StaticEnemy
{ 
    [SerializeField] private float speed = 8f;
    [SerializeField] private AudioSource music;
    private Rigidbody2D rb;
    private Vector3 direction;
    private GameObject deathEffect;
    
    private void Awake()
    {
        deathEffect = Resources.Load<GameObject>("RunAndGun/Effects/FallingPlantDestroy");
        rb = GetComponent<Rigidbody2D>();
        direction = transform.up;
        Damage = 1;
    }
    
    private void FixedUpdate()
    {
        var position = transform.position;
        var newPosition = Vector2.MoveTowards(position, position + direction,
            speed * Time.deltaTime);
        rb.MovePosition(newPosition);
    }

    protected override void OnTriggerEnter2D(Collider2D col)
    {
        Attack(col);
        var position = transform.position;
        Instantiate(deathEffect, position, Quaternion.identity);
        Instantiate(music, position, Quaternion.identity);
        Destroy(gameObject);
    }
    
    public override void ReceiveDamage(int damage)
    {
        
    }
}
