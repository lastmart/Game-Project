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
}
