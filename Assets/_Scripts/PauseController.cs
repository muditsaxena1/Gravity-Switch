using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public GameObject pauseMenu;

    public void OnPause()
    {
        Debug.Log("Pausing Game");
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void OnResume()
    {
        Debug.Log("Resuming Game");
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void MainMenuClick()
    {
        Debug.Log("Loading main menu");
    }

    public void RestartClick()
    {
        Debug.Log("Restarting the lvl");
    }
}
