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
        public bool isActive = false;
    }
    public List<ShopItem> ShopItemsList;
    [SerializeField] Animator NoCoinsAnim;


    [SerializeField] GameObject ItemTemplate;
    GameObject eachItem;
    [SerializeField] Transform ShopScrollView;
    [SerializeField] GameObject ShopPanel;
    Button buyBtn;
    
    Button activeButton;
    //Image activeButtonImage;
    
    //ColorBlock activeButtonColor;
    
    
    //public Color inActiveColor;
    //public Color activeColor;

    /**public Sprite inactive;
    public Sprite active;**/

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
            activeButton = eachItem.transform.GetChild(4).GetComponent<Button>();
            //activeButtonImage = eachItem.transform.GetChild(4).GetComponent<Image>();
            
            
            //activeButtonColor = eachItem.transform.GetChild(4).GetComponent<Button>().colors;
            if (ShopItemsList[i].isPurchased)
            {
                DisableBuyButton();
                //EnableActiveButton();
            }
            
            buyBtn.AddEventListener(i, OnShopItemBtnClicked);
            activeButton.AddEventListener(i, makeActive);
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
            //EnableActiveButton();
            
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
        activeButton.interactable = true;

    }

    void makeActive(int itemIndex)
    {
        if (ShopItemsList[itemIndex].isPurchased )
        {
            if (ShopItemsList[itemIndex].isActive==false)
            {
                ShopItemsList[itemIndex].isActive = true;
                //activeButtonColor.normalColor= activeColor;
                //EnableActiveButton();
                activeButton.transform.GetChild(0).GetComponent<Text>().text = "Activated";
                Debug.Log("Item Activated");
                for (int i = 0; i < ShopItemsList.Count; i++)
                {
                    if (i != itemIndex)
                    {
                        ShopItemsList[i].isActive = false;
                        activeButton.transform.GetChild(0).GetComponent<Text>().text = "Activate";
                        //activeButtonColor.normalColor = inActiveColor;
                        Debug.Log("Item Unactivated");
                        //DisableActiveButton();
                    }
                }
                //Debug.Log("Item Active");
            }
            else
            {
                Debug.Log("Item Already Active");
            }
        }
        else
        {
            Debug.Log("Item not purchased yet.");
        }
    }

   /** void DisableActiveButton()
    {
        activeButton.interactable = false;
        //activeButtonImage.raycastTarget = false;

    }
    void EnableActiveButton()
    {
        activeButton.interactable = true;
        //activeButtonImage.raycastTarget = true;
    }**/



    public void OpenShop()
    {
        ShopPanel.SetActive(true);
    }

    public void CloseShop()
    {
        ShopPanel.SetActive(false);
    }
    
}
