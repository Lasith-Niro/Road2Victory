﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimateCredits : MonoBehaviour
{
    public GameObject credits;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RunCredits());
    }
    IEnumerator RunCredits()
    {

        yield return new WaitForSeconds(0.5f);
        credits.SetActive(true);
        yield return new WaitForSeconds(15);
        SceneManager.LoadScene("Menu2");
        FindObjectOfType<AudioManager>().Play("background");
        FindObjectOfType<AudioManager>().Stop("about");
    }
}
