using UnityEngine;

public class FallingPlant : StaticEnemy
{ 
    [SerializeField] private float speed = 8f;
    private AudioManager audioManager;
    [SerializeField] private AudioSource music;
    private Rigidbody2D rb;
    private Vector3 direction;
    private GameObject deathEffect;
    
    private void Awake()
    {
        deathEffect = Resources.Load<GameObject>("RunAndGun/Effects/FallingPlantDestroy");
        audioManager = gameObject.GetComponentInChildren<AudioManager>();
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
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Instantiate(music, transform.position, Quaternion.identity);
        //audioManager.Play("Destroy");
        Destroy(gameObject);
    }
    
    public override void ReceiveDamage(int damage)
    {
        
    }
}
