using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.TestTools;
using GameObject = UnityEngine.GameObject;
using Object = UnityEngine.Object;

public class CharacterTests
{
    private Character character;
    
    [SetUp]
    public void SetUp()
    {
        var characterObj = MonoBehaviour.Instantiate(Resources.Load("Character")) as GameObject;
        character = characterObj?.GetComponent<Character>();
        
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(character.gameObject);
    }
    
    [UnityTest]
    public IEnumerator DoNothingWhenInstantiate()
    {
        var position = character.transform.position;
        var initialPos = new Vector3(position.x, position.y, position.z);
        yield return new WaitForSeconds(0.3f);
        Assert.True(initialPos.Equals(position));
    }

    [UnityTest]
    public IEnumerator CharacterInvulnerability()
    {
        character.inInvulnerability = true;
        yield return new WaitForSeconds(0.6f);
        Assert.False(character.inInvulnerability);
    }

    [UnityTest]
    public void CharacterReceiveDamage()
    {
        var lives = character.lives;
        const int damage = 1;
        character.ReceiveDamage(damage);
        Assert.Equals(lives, character.lives - damage);
        Assert.True(character.inInvulnerability);
    }
    
    
}
