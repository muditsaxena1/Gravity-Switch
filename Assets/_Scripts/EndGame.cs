using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public void MainMenuClick()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        //Time.timeScale = 1f;
        Debug.Log("Loading main menu");
    }

    public void RateUs()
    {
        Debug.Log("Rating");
    }
}
