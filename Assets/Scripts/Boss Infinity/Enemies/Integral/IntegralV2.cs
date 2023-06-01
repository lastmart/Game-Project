using UnityEngine;
using Random = UnityEngine.Random;

public class IntegralV2 : Integral
{
    private Rigidbody2D rb;
    
    private void Start()
    {
        speed = 5.0f;
        Damage = 1;
        rb = GetComponent<Rigidbody2D>();
        direction = transform.right;
    }

    private void FixedUpdate()
    {
        if (direction.y == 0 && Random.Range(0,1000) % 200 == 0)
            direction = new Vector3(0,transform.position.y > 0 ? -1 : 1);
        var position = transform.position;
        var newPosition = Vector2.MoveTowards(position, position + direction,
            speed * Time.deltaTime);
        rb.MovePosition(newPosition);
    }
}

