using UnityEngine;

public class EnemiesActivator : MonoBehaviour
{
    [SerializeField] private Enemy[] enemies;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Player")) return;
        foreach (var enemy in enemies)
            enemy.gameObject.SetActive(true);
    }
}
