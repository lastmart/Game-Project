using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public virtual void ReceiveDamage(int damage)
    {
       
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
