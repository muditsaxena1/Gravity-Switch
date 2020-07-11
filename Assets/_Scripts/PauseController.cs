using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject levelClearedMenu;
    public Image[] stars;
    public static PauseController instance;
    Color[] starColors;
    LoadSaveManager loadSaveManager;
    int currentSceneIndex;
    public AudioSource audioSource;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        loadSaveManager = LoadSaveManager.instance;

        starColors = new Color[3];
        starColors[0] = new Color(1f, 1f, 1f, 1f); //white
        starColors[1] = new Color(0.73f, 0.73f, 0.73f, 1f); //grey
        starColors[2] = new Color(0.168f, 0.168f, 0.168f, 1f);  //black
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("currIndex:"+ currentSceneIndex);
    }

    public void OnPause()
    {
        Debug.Log("Pausing Game");
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void OnResume()
    {
        Debug.Log("Resuming Game");
        audioSource.Play();
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    IEnumerator OpenLevelClearMenu()
    {
        yield return new WaitForSeconds(0.7f);

        Time.timeScale = 0.5f;
        levelClearedMenu.SetActive(true);
    }

    public void OnLevelClear(int currStars)
    {
        StartCoroutine(OpenLevelClearMenu());
        //int sceneIndex = int.Parse(SceneManager.GetActiveScene().name);
        int sceneIndex = int.Parse("35");
        int prevStars = loadSaveManager.GetLevelStars(sceneIndex + 1);
        for(int i = 0; i < 3; i++)
        {
            if(prevStars > i)
            {
                // grey
                stars[i].color = starColors[1];
            }
            else if(currStars > i)
            {
                // white
                stars[i].color = starColors[0];
            }
            else
            {
                //black
                stars[i].color = starColors[2];
            }
        }
        if(prevStars == -1)
        {
            loadSaveManager.LevelsUnlocked++;
        }
        loadSaveManager.SetLevelStars(sceneIndex + 1, Mathf.Max(prevStars, currStars));
    }

    public void MainMenuClick()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        //Time.timeScale = 1f;
        Debug.Log("Loading main menu");
    }

    public void RestartClick()
    {
        //Application.LoadLevel(currentSceneIndex.ToString());
        Time.timeScale = 1f;
        SceneManager.LoadScene(currentSceneIndex);
        //Time.timeScale = 1f;
        Debug.Log("Restarting the lvl");
    }

    public void NextLevelClick()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(currentSceneIndex + 1);
        //Time.timeScale = 1f;
        Debug.Log("Starting next lvl");
    }
}
