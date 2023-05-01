using UnityEngine;

public sealed class Enemy : MonoBehaviour
{
    public  int maxLeaves = 20;
    public  int currentLeaves;

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

    private void Die()
    {
        // Destroy(gameObject);
        Debug.Log("Die!");
        // Die animation

        enabled = false; // Disable the unit
    }
}