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

    [System.Serializable]
    public class ShopItem
    {
        public string SceneName;
    }
    public List<ShopItem> ShopItemsList;
    


    [SerializeField] GameObject ItemTemplate;
    GameObject eachItem;
    [SerializeField] Transform ShopScrollView;
    [SerializeField] GameObject ShopPanel;
    Button buyBtn;
    Text levelNumber;
    
    



    void Start()
    {

        

        int len = ShopItemsList.Count;
        for (int i = 0; i < len; i++)
        {
            eachItem = Instantiate(ItemTemplate, ShopScrollView);
          
            buyBtn = eachItem.transform.GetChild(0).GetComponent<Button>();
            levelNumber = buyBtn.GetComponentInChildren<Text>();
            levelNumber.text = (i+1).ToString();


           

            buyBtn.AddEventListener(i, OnShopItemBtnClicked);
            
        }




    }

    void OnShopItemBtnClicked(int itemIndex)
    {
        SceneManager.LoadScene((itemIndex + 1).ToString());
    }

   

}
