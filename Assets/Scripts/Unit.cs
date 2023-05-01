using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public int maxLeaves;
    public int lives;

    public void Start()
    {
        lives = maxLeaves;
    }

    public virtual void ReceiveDamage(int damage)
    {
        lives -= damage;
        
        // Unit hurt animation
        
        if(lives <= 0)
            Die();
    }

    public virtual void Die()
    {
        //Destroy(gameObject);
        // Die animation
        // Disable the unit
    }
}
