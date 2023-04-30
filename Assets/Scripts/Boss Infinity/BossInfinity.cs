using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossInfinity : MonoBehaviour
{
    [SerializeField] public int maxLeaves = 20;
    [SerializeField] public int lives;

    public void Start()
    {
        lives = maxLeaves;
    }

    public void ReceiveDamage(int damage)
    {
        lives -= damage;
        
        // Unit hurt animation
        
        if(lives <= 0)
            Die();
    }

    private void Die()
    {
        //Destroy(gameObject);
        Debug.Log("Die!");
        // Die animation
        
        // Disable the unit
    }
}
