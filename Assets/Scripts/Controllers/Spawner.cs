using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float reloadFrequency = 20.0f;
    [SerializeField] public int maxCapacity = 3;
    
    public GameObject integral;
    public GameObject psi;
    public GameObject sigma;
    
    private float reloadTime; 
    public int currentCapacity;

    private void Awake()
    {
        reloadTime = reloadFrequency;
        currentCapacity = maxCapacity;
    }

    private void FixedUpdate()
    {
        reloadTime -= 0.01f;
        if (reloadTime > 0) return;
        Debug.Log("I am reload");
        reloadTime = reloadFrequency;
        currentCapacity = maxCapacity;
    }

    public void SpawnEnemy(Enemies enemies)
    {
        switch (enemies) 
        {
            case Enemies.Sigma: SpawnSigma();
                break;
            case Enemies.Integral: SpawnIntegral();
                break;
            case Enemies.Psi: SpawnPsi();
                break;
        }
    }

    private void SpawnIntegral()
    {
        currentCapacity--;
        if (transform.rotation.y == 0)
        {
            Instantiate(integral, transform.position, Quaternion.identity);
        }
        else
        {
            var transform1 = transform;
            var obj = Instantiate(integral, transform1.position, transform1.rotation);
            var localScale = obj.transform.localScale;
            obj.transform.localScale = new Vector3(-localScale.x, localScale.y);
        }
    }

    private void SpawnSigma()
    {
        currentCapacity -= 3;
        var transform1 = transform;
        var position = transform1.position;
        var obj = Instantiate(sigma, position, transform1.rotation);
        var sigmaObj = obj.GetComponent<Sigma>();
        sigmaObj.SetTarget(position + transform1.right * 2);
    }

    private void SpawnPsi()
    {
        currentCapacity--;
        var transform1 = transform;
        var position = transform1.position;
        var obj = Instantiate(psi, position, Quaternion.identity);
        var psiObj = obj.GetComponent<Psi>();
        psiObj.SetTarget(position + transform1.up * 3);
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }
}

public enum Enemies
{
    Integral,
    Sigma,
    Psi
}