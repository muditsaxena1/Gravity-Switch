using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSaveManager : MonoBehaviour
{
    private int illuminatiCount;
    private int diamondCount;
    private int[] levelStars;
    private bool[] skinsUnlocked;
    private int currentSkin;

    public int IlluminatiCount
    {
        get
        {
            return illuminatiCount;
        }
        set
        {
            illuminatiCount = value;
            SaveSystem.SaveData(this);
        }
    }

    public int DiamondCount
    {
        get
        {
            return diamondCount;
        }
        set
        {
            diamondCount = value;
            SaveSystem.SaveData(this);
        }
    }
    public int[] LevelStars
    {
        get
        {
            return levelStars;
        }
        set
        {
            levelStars = value;
            SaveSystem.SaveData(this);
        }
    }

    public bool[] SkinsUnlocked
    {
        get
        {
            return skinsUnlocked;
        }
        set
        {
            skinsUnlocked = value;
            SaveSystem.SaveData(this);
        }
    }

    public int CurrentSkin
    {
        get
        {
            return currentSkin;
        }
        set
        {
            currentSkin = value;
            SaveSystem.SaveData(this);
        }
    }
    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        DataFormat currData = SaveSystem.LoadData();
        if(currData == null)
        {
            illuminatiCount = 0;
            diamondCount = 0;
            levelStars = new int[50];
            skinsUnlocked = new bool[50];
            currentSkin = 0;
        }
        else
        {
            illuminatiCount = currData.illuminatiCount;
            diamondCount = currData.diamondCount;
            levelStars = currData.levelStars;
            skinsUnlocked = currData.skinsUnlocked;
            currentSkin = currData.currentSkin;
        }
    }
}
