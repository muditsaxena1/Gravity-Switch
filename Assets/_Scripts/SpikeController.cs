using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    public GameObject explodeCube;
    public GameObject gameOverPanel;
    public GameObject PlayerCube;
     //AudioSource GameLoseAudioSource;
   /** public GameObject backgroundAudio;
    AudioSource backgroundAudioSource;
    public double loseAudioLength;**/


     void Start()
    {
        //GameLoseAudioSource = GetComponent<AudioSource>();
        //backgroundAudioSource = backgroundAudio.GetComponent<AudioSource>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            Instantiate(explodeCube, collision.transform.position, Quaternion.identity);
            //backgroundAudio.SetActive(false);
            //backgroundAudioSource.volume = 0f;
            PlayerCube.SetActive(false);
            StartCoroutine(ExecuteAfterTime(1.5f));
            
        }
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        gameOverPanel.SetActive(true);
        Time.timeScale = 0.5f;
       // gameOverPanel.SetActive(true);
        
        //GameLoseAudioSource.Play();
        
        //StartCoroutine(BackgroundAudioReplay((float)loseAudioLength));

    }

    IEnumerator BackgroundAudioReplay(float time)
    {
        yield return new WaitForSeconds(time);
        //backgroundAudioSource.volume = 0.5f;
    }
}
