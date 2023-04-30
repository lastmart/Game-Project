using UnityEngine;

public sealed class Enemy : Unit
{
    public new int maxLeaves = 20;
    public new int currentLeaves;

    public void Start()
    {
        currentLeaves = maxLeaves;
    }

    public override void ReceiveDamage(int damage)
    {
        currentLeaves -= damage;
        
        // Player hurt animation
        
        if(currentLeaves <= 0)
            Die();
    }

    public override void Die()
    {
        // Destroy(gameObject);
        Debug.Log("Die!");
        // Die animation

        enabled = false; // Disable the unit
    }
}