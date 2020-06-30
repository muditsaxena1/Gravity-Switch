﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelPage : MonoBehaviour
{
    #region Singleton:LevelPage
    public static LevelPage instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion

    [System.Serializable]
    public class ShopItem
    {
        //public string SceneName;
        public bool isUnlocked=false;
    }
    public List<ShopItem> ShopItemsList;
    


    [SerializeField] GameObject ItemTemplate;
    GameObject eachItem;
    [SerializeField] Transform ShopScrollView;
    [SerializeField] GameObject ShopPanel;
    Button buyBtn;
    Text levelNumber;

    public Color levelColor1;
    public Color levelColor2;
     Image lockImage;


    void Start()
    { 
        int len = ShopItemsList.Count;
        for (int i = 0; i < len; i++)
        {
            eachItem = Instantiate(ItemTemplate, ShopScrollView);
          
            buyBtn = eachItem.transform.GetChild(0).GetComponent<Button>();
            lockImage = eachItem.transform.GetChild(0).GetChild(1).GetComponent<Image>();
            levelNumber = buyBtn.GetComponentInChildren<Text>();
            levelNumber.text = (i + 1).ToString();
            /**if (ShopItemsList[i].isUnlocked)
            {
                lockImage.enabled = false;
                
                levelNumber.enabled = true;
               // levelNumber.text = (i + 1).ToString();

            }
            else
            {
                lockImage.enabled = true;

                levelNumber.enabled = false;

            }**/
            /**levelNumber = buyBtn.GetComponentInChildren<Text>();
            levelNumber.text = (i+1).ToString();**/
            
            levelColors(i);


           

            buyBtn.AddEventListener(i, OnShopItemBtnClicked);
            
        }




    }

    void OnShopItemBtnClicked(int itemIndex)
    {
        SceneManager.LoadScene((itemIndex + 1).ToString());
    }

   void levelColors(int i)
    {
        if (i > 9 && i < 20)
        {
            buyBtn.GetComponent<Image>().color = levelColor1;
        }
        else if (i > 19)
        {
            buyBtn.GetComponent<Image>().color = levelColor2;
        }
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < ShopItemsList.Count; i++)
        {
            if (ShopItemsList[i].isUnlocked)
            {
                lockImage.enabled = false;
                levelNumber.enabled = true;
            }
            else
            {
                lockImage.enabled = true;
                levelNumber.enabled = false;

            }
        }
    }

}
