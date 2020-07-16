using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSaveManager : MonoBehaviour
{
    public static LoadSaveManager instance;

    private int illuminatiCount;
    private int starCount;
    private int[] levelStars;
    private bool[] skinsUnlocked;
    private int currentSkin;
    private int levelsUnlocked;
    private int gamesPlayedCount;

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

    public int StarCount
    {
        get
        {
            return starCount;
        }
        set
        {
            starCount = value;
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

    public int GamesPlayedCount
    {
        get
        {
            return gamesPlayedCount;
        }
        set
        {
            gamesPlayedCount = value;
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
            Debug.Log("Creating new data file");
            illuminatiCount = 0;
            starCount = 0;
            levelStars = new int[50];
            for(int i = 0; i < 50; i++)
            {
                levelStars[i] = -1;     // not cleared
            }
            skinsUnlocked = new bool[50];
            skinsUnlocked[0] = true;
            currentSkin = 0;
            levelsUnlocked = 1;
            gamesPlayedCount = 0;

            //FOR TESTING PURPOSE ONLY
            //DELETE LATER
            levelsUnlocked = 5;
            levelStars[0] = 3;
            levelStars[1] = 1;
            levelStars[2] = 0;
            levelStars[3] = 2;

            illuminatiCount = 4;
            starCount = 10;

            //TILL HERE
            SaveSystem.SaveData(this);
        }
        else
        {
            illuminatiCount = currData.illuminatiCount;
            starCount = currData.starCount;
            levelStars = currData.levelStars;
            skinsUnlocked = currData.skinsUnlocked;
            currentSkin = currData.currentSkin;
            levelsUnlocked = currData.levelsUnlocked;
            gamesPlayedCount = currData.gamesPlayedCount;
        }
    }
}
