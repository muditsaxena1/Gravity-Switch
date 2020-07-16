using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    public InterstitialAdManager interstitial;
    public GameObject explodeCube;
    public GameObject gameOverPanel;
    public GameObject PlayerCube;
    //AudioSource GameLoseAudioSource;
    public GameObject backgroundAudio;
    AudioSource backgroundAudioSource;
    public double loseAudioLength;
    public AudioClip explodeAudioClip;
    public AudioSource interactableAudioSource;
    public float spikeExplodeVolume;

     void Start()
    {
        //GameLoseAudioSource = GetComponent<AudioSource>();
        backgroundAudioSource = backgroundAudio.GetComponent<AudioSource>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            Instantiate(explodeCube, collision.transform.position, Quaternion.identity);
            interactableAudioSource.clip = explodeAudioClip;
            interactableAudioSource.volume = spikeExplodeVolume;
            interactableAudioSource.Play();
            //backgroundAudio.SetActive(false);
            //backgroundAudioSource.volume = 0f;
            PlayerCube.SetActive(false);
            StartCoroutine(ExecuteAfterTime(1f));
        }
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Time.timeScale = 0.5f;
        if (LoadSaveManager.instance.GamesPlayedCount >= 7)
        {
            interstitial.ShowInterstitialAd();
        }
        backgroundAudioSource.volume = 0f;
        gameOverPanel.SetActive(true);
        
        
        
        StartCoroutine(BackgroundAudioReplay((float)loseAudioLength));

    }

    IEnumerator BackgroundAudioReplay(float time)
    {
        yield return new WaitForSeconds(time);
        backgroundAudioSource.volume = 0.5f;
    }
}
