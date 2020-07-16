using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopButtonController : MonoBehaviour
{
    //public GameObject adsPanel;
    public void OnBackButtonClick()
    {
        SceneManager.LoadScene(0);
    }
}
