﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FailMenu : MonoBehaviour
{
    public Image backgroundImage;
    public Text scoreTxt;
    //public TextMesh scoreTxt;

    private bool isShowned = false;
    private float transition = 0f;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isShowned)
            return;

        transition += Time.deltaTime;
        backgroundImage.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, transition); 
    }

    public void ToggleMenu(float score)
    {
        gameObject.SetActive(true);
        scoreTxt.text = ((int)score).ToString();
        isShowned = true;
    }

    public void Restart()
    {
        FindObjectOfType<AudioManager>().Play("background");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Back()
    {
        FindObjectOfType<AudioManager>().Stop("background");
        SceneManager.LoadScene("Menu2");
    }
}
