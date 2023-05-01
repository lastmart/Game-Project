using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsiMonster : Unit
{
    private float speed = 0.5f;
    private float rooting = 0.002f;
    [SerializeField] private float secundomer;
    private float delta = 0.01f;
    private bool isX = true;

    private int delay = 10;
    private int phase = 17;
    private int pause = 5;
   
    private void Update()
    {
        secundomer += delta;
        if(secundomer > delay && secundomer < delay + phase)  UpMotion(); 
        if(secundomer > delay + phase + pause && secundomer < delay + phase * 2 + pause)  DownMotion(); 
        
    }

    private void UpMotion()
    {
        if (isX) transform.position = new Vector3(Character.CharacterX + 5f, -9f, 0);
        isX = false;
        transform.Translate(0, speed * Time.deltaTime, 0); 
        speed += rooting;
    }

    private void DownMotion()
    {
        transform.Translate(0, -speed * Time.deltaTime, 0); 
        speed -= rooting;
    }

}

