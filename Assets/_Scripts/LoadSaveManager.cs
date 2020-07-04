using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSaveManager : MonoBehaviour
{
    public static LoadSaveManager instance;

    private int illuminatiCount;
    private int diamondCount;
    private int[] levelStars;
    private bool[] skinsUnlocked;
    private int currentSkin;
    private int levelsUnlocked;

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

    //get 1 val
    public int GetLevelStars(int index)
    {
        return levelStars[index];
    }
    //set 1 val
    public void SetLevelStars(int index, int stars)
    {
        levelStars[index] = stars;
        SaveSystem.SaveData(this);
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
    
    //get 1 val
    public bool GetSkinsUnlocked(int index)
    {
        return skinsUnlocked[index];
    }

    //set 1 val
    public void SetSkinsUnlocked(int index, bool val)
    {
        skinsUnlocked[index] = val;
        SaveSystem.SaveData(this);
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

    public int LevelsUnlocked
    {
        get
        {
            return levelsUnlocked;
        }
        set
        {
            levelsUnlocked = value;
            SaveSystem.SaveData(this);
        }
    }

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        DataFormat currData = SaveSystem.LoadData();
        if(currData == null)
        {
            illuminatiCount = 0;
            diamondCount = 0;
            levelStars = new int[50];
            for(int i = 0; i < 50; i++)
            {
                levelStars[i] = -1;     // not cleared
            }
            skinsUnlocked = new bool[50];
            currentSkin = 0;
            LevelsUnlocked = 1;
            SaveSystem.SaveData(this);
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
