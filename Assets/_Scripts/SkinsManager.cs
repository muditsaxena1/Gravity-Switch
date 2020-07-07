using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinsManager : MonoBehaviour
{
    [System.Serializable]
    public class ShopItem
    {
        public Sprite image;
        public Color color = Color.white;
        public bool costsIlluminati = false;
        public int price;
        public bool isPurchased = false;
    }
    public List<ShopItem> ShopItemsList;

    public List<ShopItem> GetShopItemsList()
    {
        return ShopItemsList;
    }

    
    public static SkinsManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
}
