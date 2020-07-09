using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ins_manager : MonoBehaviour
{
    public GameObject insPanel;
    public GameObject credPanel;
    AudioSource audioSource;

    // Start is called before the first frame update
     void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnPlayButtonPress()
    {
       
        SceneManager.LoadScene(2);
    }

    public void OnShopButtonPress()
    {
        SceneManager.LoadScene(1);
    }

    public void openIns()
    {
        insPanel.SetActive(true);
    }
    public void closeIns()
    {
        audioSource.Play();
        insPanel.SetActive(false);
    }
    public void openCred()
    {
        credPanel.SetActive(true);
    }
    public void closeCred()
    {
        audioSource.Play();
        credPanel.SetActive(false);
    }
}
