using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataFormat
{
    public int illuminatiCount;
    public int diamondCount;
    public int[] levelStars;        //-1 means not cleared 0,1,2,3 tells number of stars
    public bool[] skinsUnlocked;
    public int currentSkin;
    public int levelsUnlocked;

    public DataFormat(LoadSaveManager loadSaveManager)
    {
        illuminatiCount = loadSaveManager.IlluminatiCount;
        diamondCount = loadSaveManager.DiamondCount;
        levelStars = loadSaveManager.LevelStars;
        skinsUnlocked = loadSaveManager.SkinsUnlocked;
        currentSkin = loadSaveManager.CurrentSkin;
        levelsUnlocked = loadSaveManager.LevelsUnlocked;
    }

}
