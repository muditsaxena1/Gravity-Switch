using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopButtonController : MonoBehaviour
{
    public void OnBackButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    public void OnAdsButtonClick()
    {
        Debug.Log("Show ads");
    }

}
