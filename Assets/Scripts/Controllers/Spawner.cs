using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Spawner : MonoBehaviour
{
    public GameObject integral;
    public GameObject psi;
    public GameObject sigma;
    private float timeBetweenSpawn;
    
    
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
        var transform1 = transform;
        var obj = Instantiate(sigma, transform1.position, transform1.rotation);
        var sigmaObj = obj.GetComponent<Sigma>();
        sigmaObj.SetTarget(transform1.position + transform1.right * 2);
    }

    private void SpawnPsi()
    {
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