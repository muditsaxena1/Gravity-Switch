using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ins_manager : MonoBehaviour
{
    public GameObject insPanel;
    public GameObject credPanel;
    // Start is called before the first frame update

    
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
        insPanel.SetActive(false);
    }
    public void openCred()
    {
        credPanel.SetActive(true);
    }
    public void closeCred()
    {
        credPanel.SetActive(false);
    }
}
