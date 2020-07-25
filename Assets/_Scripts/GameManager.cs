using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Animator arrowAnimator;
    public InterstitialAdManager interstitial;
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
    /**public GameObject loseAudio;
    AudioSource audioSourceLose;**/

    PlayerScript playerSriptVariable;
    //public GameObject backgroundAudio;
    
    public double loseAudioLength;

    public GameObject playerVariable;
    int zero = 0;
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
        movesLeftText.text = (movesLeft).ToString(); 
        areaEffector = GetComponent<AreaEffector2D>();
        areaEffector.forceAngle = startingAngle;
        switch (startingAngle)
        {
            case 0f:
                arrowAnimator.SetTrigger("Left");
                break;
            case 90f:
                arrowAnimator.SetTrigger("Up");
                break;
            case 180f:
                arrowAnimator.SetTrigger("Right");
                break;
            case 270f:
                arrowAnimator.SetTrigger("Down");
                break;
            default:
                Debug.Log("This should not have printed ever!!");
                break;

        }
        inputManager = InputManager.instance;
        //audioSourceLose = loseAudio.GetComponent<AudioSource>();
        playerSriptVariable = PlayerScript.instance;
        
    }

    private void FixedUpdate()
    {
        /**if (inputManager.IsButtonDown())
        {
            if(movesLeft > 0)
            {
                areaEffector.forceAngle = (areaEffector.forceAngle + 270) % 360;
                movesLeft--;
                movesLeftText.text = movesLeft.ToString();

            }
        }**/
        /**if (movesLeft==0 && playerSriptVariable.isCollectableCollected==false)
        {


            //backgroundAudio.SetActive(false);
            gameOverPanel.SetActive(true);
            //audioSourceLose.Play();
            //StartCoroutine(BackgroundAudioReplay((float)loseAudioLength));


        }**/
    }

    public void playbtnClicked()
    {
        if (movesLeft > 0)
        {
            areaEffector.forceAngle = (areaEffector.forceAngle + 270) % 360;
            switch (areaEffector.forceAngle)
            {
                case 0f:
                    arrowAnimator.SetTrigger("Left");
                    break;
                case 90f:
                    arrowAnimator.SetTrigger("Up");
                    break;
                case 180f:
                    arrowAnimator.SetTrigger("Right");
                    break;
                case 270f:
                    arrowAnimator.SetTrigger("Down");
                    break;
                default:
                    Debug.Log("This should not have printed ever!!");
                    break;

            }
            movesLeft--;
            movesLeftText.text = movesLeft.ToString();

        }
        if (movesLeft == 0 && playerSriptVariable.isCollectableCollected == false)
        {
            StartCoroutine(gameOver(5f));
        }



    }

    IEnumerator gameOver(float time)
    {
        yield return new WaitForSeconds(time);
        if(playerSriptVariable.isCollectableCollected == false)
        {
            if (LoadSaveManager.instance.GamesPlayedCount >= 7)
            {
                interstitial.ShowInterstitialAd();
            }
            gameOverPanel.SetActive(true);
            playerVariable.SetActive(false);
        }
    }
}
