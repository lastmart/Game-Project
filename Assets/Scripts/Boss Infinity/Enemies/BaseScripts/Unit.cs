using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    protected int Damage { get; set; }
    
    public virtual void ReceiveDamage(int damage)
    {
       
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D col) => Attack(col);

    protected virtual void OnTriggerStay2D(Collider2D other) => Attack(other);

    private void Attack(Collider2D collider)
    {
        var character = collider.GetComponent<Character>();
        if (character is null) return;
        character.ReceiveDamage(Damage);
    }
    
}
