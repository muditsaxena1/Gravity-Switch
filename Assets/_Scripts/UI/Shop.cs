using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    #region Singleton:Shop
    public static Shop instance;

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

    [System.Serializable] public class ShopItem
    {
        public Sprite image;
        public int price;
        public bool isPurchased=false;
    }
    public List<ShopItem> ShopItemsList;
    [SerializeField] Animator NoCoinsAnim;


    [SerializeField] GameObject ItemTemplate;
    GameObject eachItem;
    [SerializeField] Transform ShopScrollView;
    [SerializeField] GameObject ShopPanel;
    Button buyBtn;
    // Start is called before the first frame update
    void Start()
    {
       


        int len = ShopItemsList.Count;
        for (int i=0;i<len;i++)
        {
            eachItem = Instantiate(ItemTemplate,ShopScrollView);
            eachItem.transform.GetChild(0).GetComponent<Image>().sprite = ShopItemsList[i].image;
            eachItem.transform.GetChild(1).GetComponent<Text>().text = ShopItemsList[i].price.ToString();
            buyBtn = eachItem.transform.GetChild(2).GetComponent<Button>();
            if (ShopItemsList[i].isPurchased)
            {
                DisableBuyButton();
            }
            
            buyBtn.AddEventListener(i, OnShopItemBtnClicked);
        }

        
        

    }

    void OnShopItemBtnClicked(int itemIndex)
    {
        if (Game.instance.HasEnoughCoins(ShopItemsList[itemIndex].price)) {

            Game.instance.UseCoins(ShopItemsList[itemIndex].price);
            ShopItemsList[itemIndex].isPurchased = true;

            //Disbabling Button
            buyBtn = ShopScrollView.GetChild(itemIndex).GetChild(2).GetComponent<Button>();
            DisableBuyButton();
            Game.instance.UpdateAllCoinsUIText();
        }

        else
        {
            NoCoinsAnim.SetTrigger("NoCoins");
            Debug.Log("Not enough coins.");
        }        
    }

    void DisableBuyButton()
    {
        buyBtn.interactable = false;
        buyBtn.transform.GetChild(0).GetComponent<Text>().text = "Purchased";

    }

   

    public void OpenShop()
    {
        ShopPanel.SetActive(true);
    }

    public void CloseShop()
    {
        ShopPanel.SetActive(false);
    }
    
}
