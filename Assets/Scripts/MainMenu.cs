using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text highScoreTxt;

    private void Start()
    {
        highScoreTxt.text = "Highscore : " + ((int)PlayerPrefs.GetFloat("HighScore")).ToString();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void showDetails()
    {

    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
