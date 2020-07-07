using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ins_manager : MonoBehaviour
{
    public GameObject insPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openIns()
    {
        insPanel.SetActive(true);
    }
    public void closeIns()
    {
        insPanel.SetActive(false);
    }
}
