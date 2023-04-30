using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsiMonster : Unit
{
    private float speed = 0.5f;
    private float rooting = 0.002f;
    [SerializeField] private float secundomer;
    private float delta = 0.01f;
    private bool isAppearance = true;
    private bool isX = true;

    private int delay = 10;
    private int phase = 16;
   
    private void Update()
    {
        if(secundomer < delay + phase + 1) secundomer += delta;
        if(secundomer > delay && isAppearance)  Appearance(); 
        if (secundomer > delay + phase) isAppearance = false;
    }

    private void Appearance()
    {
        if (isX) transform.position = new Vector3(Character.CharacterX + 5f, -9f, 0);
        isX = false;
        transform.Translate(0, speed * Time.deltaTime, 0); 
        speed += rooting;
    }

}

