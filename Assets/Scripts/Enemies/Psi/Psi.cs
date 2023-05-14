using UnityEngine;

public class Psi : Unit
{
    [SerializeField] protected float speed = 4.0f;
    private const int Damage = 1;
    
    private new Rigidbody2D rigidbody;
    public Vector3 direction;
    public LayerMask playerLayer;
    protected Vector3 TargetPosition;

    protected virtual void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        var transform1 = transform;
        direction = transform1.up;
    }

    private protected virtual void FixedUpdate()
    {
        var position = transform.position;
        if ((position - TargetPosition).magnitude < 0.1) direction.y *= -1;
        var newPosition = Vector2.MoveTowards(position, position + direction,
            speed * Time.deltaTime);
        rigidbody.MovePosition(newPosition);
        CheckCharacter();
    }

    public override void ReceiveDamage(int damage)
    {
        
    }
    
    public void SetTarget(Vector3 target) => TargetPosition = target;
    
    private void CheckCharacter()
    {
        var hitPlayer = Physics2D.OverlapCircle(transform.position, 1.0f, playerLayer);
        if (hitPlayer is null) return;
        hitPlayer.GetComponent<Character>().ReceiveDamage(Damage);
    }
}
