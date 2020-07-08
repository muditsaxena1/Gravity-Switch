using System.Collections;
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

    //[System.Serializable]
    //public class LevelItem
    //{
    //    //public string SceneName;
    //    public bool isUnlocked=false;
    //}
    LoadSaveManager loadSaveManager;
    const int LEVELCOUNT = 50;
    public Text coinText;
    public Sprite brightStar;

    [SerializeField] GameObject ItemTemplate;
    [SerializeField] Transform ShopScrollView;
    [SerializeField] GameObject ShopPanel;

    GameObject eachItem;
    Button levelBtn;
    Text levelNumber;
    Image lockImage;
    Image starImage;


    void Start()
    {
        loadSaveManager = LoadSaveManager.instance;
        int levelsUnlocked = loadSaveManager.LevelsUnlocked;
        Debug.Log("levelsUnlocked = " + levelsUnlocked);
        for (int i = 0; i < LEVELCOUNT; i++)
        {
            eachItem = Instantiate(ItemTemplate, ShopScrollView);
            
            if(i < levelsUnlocked)
            {
                //unlock level

                //button
                levelBtn = eachItem.transform.GetChild(0).GetComponent<Button>();
                levelBtn.interactable = true;
                levelBtn.AddEventListener(i, OnShopItemBtnClicked);

                //Lock Image
                lockImage = eachItem.transform.GetChild(0).GetChild(0).GetComponent<Image>();
                lockImage.enabled = false;

                //Text
                levelNumber = eachItem.transform.GetChild(0).GetChild(1).GetComponent<Text>();
                levelNumber.text = (i+1).ToString();
                levelNumber.enabled = true;

                //Stars
                int starCount = loadSaveManager.GetLevelStars(i);      //[0-3]
                for(int j = 0; j < 3; j++)
                {
                    starImage = eachItem.transform.GetChild(0).GetChild(2).GetChild(j).GetComponent<Image>();
                    if(j + 1 <= starCount)
                    {
                        starImage.sprite = brightStar;
                    }
                    starImage.color = Color.white;
                }
            }
            
        }
    }

    void OnShopItemBtnClicked(int itemIndex)
    {
        SceneManager.LoadScene(itemIndex + 3);
    }

    public void OnBackButtonPress()
    {
        SceneManager.LoadScene(0);
    }

    public void OnShopButtonPress()
    {
        SceneManager.LoadScene(1);
    }
}
