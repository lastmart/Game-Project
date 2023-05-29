using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComicsController : MonoBehaviour
{
    [SerializeField] private Transform page1;
    [SerializeField] private Transform page2;

    private void Start()
    {
        page1.gameObject.SetActive(true);
        page2.gameObject.SetActive(false);
    }

    public void NextPage()
    {
        page1.gameObject.SetActive(false);
        page2.gameObject.SetActive(true);
    }

    public void Play(int index) => SceneManager.LoadScene(index);
}
