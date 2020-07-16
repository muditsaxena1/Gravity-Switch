using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public InterstitialAdManager interstitialAdManager;
    AreaEffector2D areaEffector;
    public float startingAngle;
    [HideInInspector]
    public bool gameOn = false;
    public static GameManager instance;
    InputManager inputManager;
    //public text movesLeftText;
    public TextMeshProUGUI movesLeftText;
    public int movesLeft;

    
    public GameObject gameOverPanel;
    public GameObject loseAudio;
    AudioSource audioSourceLose;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        movesLeftText.text = movesLeft.ToString(); 
        //movesLeftText.text = movesLeft.ToString();
        areaEffector = GetComponent<AreaEffector2D>();
        areaEffector.forceAngle = startingAngle;
        inputManager = InputManager.instance;
        audioSourceLose = loseAudio.GetComponent<AudioSource>();

    }

    private void FixedUpdate()
    {
        if (inputManager.IsButtonDown())
        {
            if(movesLeft > 0)
            {
                areaEffector.forceAngle = (areaEffector.forceAngle + 270) % 360;
                movesLeft--;
                movesLeftText.text = movesLeft.ToString();

            }
        }
        if (movesLeft==0)
        {
            gameOverPanel.SetActive(true);
            audioSourceLose.Play();
            StartCoroutine(ShowGameOverPanel());
        }
    }

    IEnumerator ShowGameOverPanel()
    {
        yield return new WaitForSeconds(5f);
        if (PlayerScript.isPlaying)
        {
            PlayerScript.isPlaying = false;
            //SHOW INTERSTITIAL
            if(LoadSaveManager.instance.GamesPlayedCount >= 7)
            {
                interstitialAdManager.ShowInterstitialAd();
            }
            gameOverPanel.SetActive(true);
            audioSourceLose.Play();
        }
    }

    public void playbtnClicked()
    {
        if (movesLeft > 0)
        {
            Debug.Log("How is calling me?");
            areaEffector.forceAngle = (areaEffector.forceAngle + 270) % 360;
            movesLeft--;
            movesLeftText.text = movesLeft.ToString();

        }
    }

}
