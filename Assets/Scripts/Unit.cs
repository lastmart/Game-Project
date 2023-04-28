using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public int maxLeaves;
    public int currentLeaves;

    public void Start()
    {
        currentLeaves = maxLeaves;
    }

    public void ReceiveDamage(int damage)
    {
        currentLeaves -= damage;
        
        // Player hurt animation
        
        if(currentLeaves <= 0)
            Die();
    }

    protected virtual void Die()
    {
        //Destroy(gameObject);
        Debug.Log("Die!");
        // Die animation
        
        // Disable the unit
    }
}
