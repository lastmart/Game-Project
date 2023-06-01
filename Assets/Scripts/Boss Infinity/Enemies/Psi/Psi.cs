using UnityEngine;

public class Psi : Enemy
{
    [SerializeField] protected AudioManager audioManager;
    [SerializeField] protected float speed = 4.0f;
    [SerializeField] protected Vector3 targetPosition;
    
    private Rigidbody2D rb;
    public Vector3 direction;

    protected virtual void Start()
    {
        Damage = 1;
        rb = GetComponent<Rigidbody2D>();
        var transform1 = transform;
        direction = transform1.up;
    }
    
    private protected virtual void FixedUpdate()
    {
        var position = transform.position;
        if ((position - targetPosition).magnitude < 0.1)
        {
            audioManager.Play("Appear");
            direction.y *= -1;
        }
        var newPosition = Vector2.MoveTowards(position, position + direction,
            speed * Time.deltaTime);
        rb.MovePosition(newPosition);
    }

    public override void ReceiveDamage(int damage)
    {
        
    }
    
    public void SetTarget(Vector3 target) => targetPosition = target;
}
