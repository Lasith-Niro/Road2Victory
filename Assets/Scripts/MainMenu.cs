using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Score Variables")]
    public Text highScoreTxt;

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("background");
        highScoreTxt.text = "Highscore : " + ((int)PlayerPrefs.GetFloat("HighScore")).ToString();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void showDetails()
    {
        SceneManager.LoadScene("About");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
