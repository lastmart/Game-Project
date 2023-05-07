using UnityEngine;
using UnityEngine.Serialization;

public class Integral : Unit
{
    [SerializeField] private float speed = 4.0f;
    private const int Damage = 1;
    private new Rigidbody2D rigidbody;
    private new Transform transform;
    public Vector3 direction;
    public LayerMask playerLayer;

    public Integral(Vector3 direction)
    {
        this.direction = direction;
    }
    
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
    }
    
    private void FixedUpdate()
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
