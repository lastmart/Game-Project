using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private int damage = 1;
    
    private Transform trf;
    private GameObject explosion;
    
    private void Start()
    {
        trf = transform;
        explosion = Resources.Load<GameObject>("RunAndGun/Effects/Explosion");
        Destroy(gameObject, 3f);
    }
    
    private void FixedUpdate()
    {
        var position = trf.position;
        transform.position = Vector3.MoveTowards(position, position + trf.right, 
            speed * Time.deltaTime);
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("OneWayPlatform")) return;
        var character = col.gameObject.GetComponent<Character>();
        Destroy(gameObject);
        Instantiate(explosion, transform.position, Quaternion.identity);
        // ReSharper disable once Unity.NoNullPropagation
        character?.ReceiveDamage(damage);
    }
}
