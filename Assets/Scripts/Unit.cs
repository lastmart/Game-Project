using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    protected virtual int CurrentLives { get; set; }
    
    public virtual void ReceiveDamage(int damage)
    {
        CurrentLives -= damage;
        
        if(CurrentLives <= 0)
            Die();
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
