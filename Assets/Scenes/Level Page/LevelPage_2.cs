using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelPage_2 : MonoBehaviour
{
    /**[System.Serializable]
    public class LevelItem
    {
        public int nextSceneName;
        public bool isUnlocked = false;
        
        public Button levelButton;
        public PlayerScript PlayerScriptlevel;
        
    }
    public LevelItem[] levelList;**/

    public Button[] lvlButtons;

    void Start()
    {
        /**int levelAt = PlayerPrefs.GetInt("leveAt",1);
        for (int i = 0; i < levelList.Length; i++)
        {
            if (i==0)
            {
                levelList[i].isUnlocked = true;
            }
            else if (i+1>levelAt)
            {
                levelList[i].levelButton.interactable = false;
            }
        }**/

        


    }

   
}
