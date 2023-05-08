using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float lifetime = 8.0f;
    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
