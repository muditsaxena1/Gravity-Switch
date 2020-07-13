using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
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
        //audioSourceLose = loseAudio.GetComponent<AudioSource>();
        playerSriptVariable = PlayerScript.instance;
        
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
        if (movesLeft==0 && playerSriptVariable.isCollectableCollected==false)
        {


            //backgroundAudio.SetActive(false);
            gameOverPanel.SetActive(true);
            //audioSourceLose.Play();
            //StartCoroutine(BackgroundAudioReplay((float)loseAudioLength));


        }
    }

    public void playbtnClicked()
    {
        if (movesLeft > 0)
        {
            areaEffector.forceAngle = (areaEffector.forceAngle + 270) % 360;
            movesLeft--;
            movesLeftText.text = movesLeft.ToString();

        }
    }

    /**IEnumerator BackgroundAudioReplay(float time)
    {
        yield return new WaitForSeconds(time);
        backgroundAudio.SetActive(true);
    }**/
}
