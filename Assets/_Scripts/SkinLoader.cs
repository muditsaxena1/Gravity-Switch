using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinLoader : MonoBehaviour
{
    LoadSaveManager loadSaveManager;
    SkinsManager skinsManager;

    public Transform player;
    List<ShopItem> shopItemList;

    private void Start()
    {
        loadSaveManager = LoadSaveManager.instance;
        skinsManager = SkinsManager.instance;
        shopItemList = skinsManager.GetShopItemsList();

        int skinIndex = loadSaveManager.CurrentSkin;
        SpriteRenderer sr = player.GetComponent<SpriteRenderer>();
        Color skinColor = shopItemList[skinIndex].color;

        //Image
        sr.sprite = shopItemList[skinIndex].image;

        //Image color
        sr.color = skinColor;

        //Particle System Color
        var main = player.GetChild(0).GetComponent<ParticleSystem>().main;
        main.startColor = skinColor;

        //Trail renderer color
        skinColor.a = 0.58f;
        player.GetComponent<TrailRenderer>().startColor = skinColor;
    }
}
