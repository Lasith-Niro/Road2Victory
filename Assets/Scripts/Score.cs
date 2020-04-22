using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private float score = 0.0f;
    public Text scoreTxt;

    private int level = 1;
    private int maxLevel = 10;
    private int scoreThreshold = 10;

    private bool isDead = false;
    // Update is called once per frame
    void Update()
    {
        if (isDead)
            return;
        if(score>= scoreThreshold)
        {
            NextLevel();
        }
        score += Time.deltaTime * level;
        scoreTxt.text = ((int)score).ToString();
    }

    private void NextLevel()
    {
        if(level == maxLevel)
        {
            return;
        }
        scoreThreshold *= 2;
        level++;
        GetComponent<PlayerEngine>().SetSpeed(level);
    }

    public void onDeath()
    {
        isDead = true;
    }
}
