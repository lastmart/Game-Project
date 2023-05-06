using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharLivesBar : MonoBehaviour
{
    private Transform[] hearts = new Transform[3];
    public Character character;

    private void Awake()
    {
        for (var i = 0; i < hearts.Length; i++)
        {
            hearts[i] = transform.GetChild(i);
        }
    }

    public void Refresh()
    {
        for (var i = 0; i < hearts.Length; i++)
        {
            hearts[i].gameObject.SetActive(i < character.lives);
        }
    }
}
