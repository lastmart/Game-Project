using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterOneWayPlatform : MonoBehaviour
{
    [SerializeField] private Collider2D characterCollider;
    private GameObject currentOneWayPlatform;
    private IEnumerator enumerator;
    
    void Update()
    {
        if (!Input.GetButtonDown("Vertical") || !(Input.GetAxis("Vertical") < 0)) return;
        if (currentOneWayPlatform is not null)
        {
            StartCoroutine(DisableCollision());
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("OneWayPlatform"))
        {
            currentOneWayPlatform = col.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("OneWayPlatform"))
        {
            currentOneWayPlatform = null;
        }
    }

    private IEnumerator DisableCollision()
    {
        var platformCollider = currentOneWayPlatform.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(characterCollider, platformCollider);
        yield return new WaitForSeconds(0.25f);
        Physics2D.IgnoreCollision(characterCollider, platformCollider, false);
    }
}