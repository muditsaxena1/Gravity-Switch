using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    int currentSceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

   void restartButton()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }
    
    void mainMenuButton()
    {
        SceneManager.LoadScene(0);
    }

   
}
