using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShopItem
{
    public Sprite image;
    public Color color = Color.white;
    public bool costsIlluminati = false;
    public int price;
    public bool isPurchased = false;
}
