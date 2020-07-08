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
    public SkinsManager skinsManager;
    List<ShopItem> ShopItemsList;
    [SerializeField] Text NoCoinsText;

    public Sprite starSprite;
    public Sprite shopItemSelectedSprite, shopItemSprite;
    [SerializeField] GameObject ItemTemplate;
    [SerializeField] Transform ShopScrollView;
    [SerializeField] GameObject ShopPanel;

    LoadSaveManager loadSaveManager;
    Game game;

    GameObject eachItem;
    Button buyBtn;
    Button activeButton;
    Image skinImage;
    //Image activeButtonImage;
    
    //ColorBlock activeButtonColor;
    
    
    //public Color inActiveColor;
    //public Color activeColor;

    /**public Sprite inactive;
    public Sprite active;**/

    // Start is called before the first frame update
  
    
    
    void Start()
    {
        loadSaveManager = LoadSaveManager.instance;
        game = Game.instance;

        int activeSkinIndex = loadSaveManager.CurrentSkin;
        bool[] purchasedSkins = loadSaveManager.SkinsUnlocked;

        ShopItemsList = skinsManager.GetShopItemsList();

        int len = ShopItemsList.Count;
        for (int i = 0; i < len; i++)
        {
            eachItem = Instantiate(ItemTemplate,ShopScrollView);

            //Buttons
            buyBtn = eachItem.transform.GetChild(2).GetComponent<Button>();
            activeButton = eachItem.transform.GetChild(4).GetComponent<Button>();

            //Image
            skinImage = eachItem.transform.GetChild(0).GetComponent<Image>();
            skinImage.sprite = ShopItemsList[i].image;

            //color
            skinImage.color = ShopItemsList[i].color;

            //costsIlluminati
            if (!ShopItemsList[i].costsIlluminati)
            {
                eachItem.transform.GetChild(3).GetComponent<Image>().sprite = starSprite;
            }

            //price
            eachItem.transform.GetChild(1).GetComponent<Text>().text = ShopItemsList[i].price.ToString();

            //isPurchased
            ShopItemsList[i].isPurchased = purchasedSkins[i];
            if (ShopItemsList[i].isPurchased)
            {
                DisableBuyButton();
            }
            
            buyBtn.AddEventListener(i, OnShopItemBtnClicked);
            activeButton.AddEventListener(i, makeActive);

            if(i == activeSkinIndex)
            {
                ShopScrollView.GetChild(i).GetChild(4).GetComponent<Button>().interactable = false;
                ShopScrollView.GetChild(i).GetChild(4).GetChild(0).GetComponent<Text>().text = "SELECTED";
                ShopScrollView.GetChild(i).GetComponent<Image>().sprite = shopItemSelectedSprite;
            }
        }

        
        

    }

    void OnShopItemBtnClicked(int itemIndex)
    {
        if (game.HasEnoughCoins(ShopItemsList[itemIndex].price, ShopItemsList[itemIndex].costsIlluminati)) {

            game.UseCoins(ShopItemsList[itemIndex].price, ShopItemsList[itemIndex].costsIlluminati);
            ShopItemsList[itemIndex].isPurchased = true;

            

            //Disbabling Button
            buyBtn = ShopScrollView.GetChild(itemIndex).GetChild(2).GetComponent<Button>();
            loadSaveManager.SetSkinsUnlocked(itemIndex, true);
            DisableBuyButton();
            //EnableActiveButton();
            
            Game.instance.UpdateAllCoinsUIText();
            
        }

        else
        {
            NoCoinsText.text = "Not enough coins!!!";
            NoCoinsText.GetComponent<Animator>().SetTrigger("NoCoins");
            Debug.Log("Not enough coins.");
        }        
    }

    void DisableBuyButton()
    {
        buyBtn.interactable = false;
        buyBtn.transform.GetChild(0).GetComponent<Text>().text = "BOUGHT";
        activeButton.interactable = true;

    }

    void makeActive(int itemIndex)
    {
        if (ShopItemsList[itemIndex].isPurchased)
        {
            int currentActiveSkin = loadSaveManager.CurrentSkin;
            ShopScrollView.GetChild(currentActiveSkin).GetChild(4).GetComponent<Button>().interactable = true;
            ShopScrollView.GetChild(currentActiveSkin).GetChild(4).GetChild(0).GetComponent<Text>().text = "SELECT";
            ShopScrollView.GetChild(currentActiveSkin).GetComponent<Image>().sprite = shopItemSprite;

            ShopScrollView.GetChild(itemIndex).GetChild(4).GetComponent<Button>().interactable = false;
            ShopScrollView.GetChild(itemIndex).GetChild(4).GetChild(0).GetComponent<Text>().text = "SELECTED";
            ShopScrollView.GetChild(itemIndex).GetComponent<Image>().sprite = shopItemSelectedSprite;

            loadSaveManager.CurrentSkin = itemIndex;
            
        }
        else
        {
            NoCoinsText.text = "Purchase first!!!";
            NoCoinsText.GetComponent<Animator>().SetTrigger("NoCoins");
            Debug.Log("Item not purchased yet.");
        }
    }
    
}
