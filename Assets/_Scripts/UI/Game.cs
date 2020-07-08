using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    #region Singleton:Game
    
    public static Game instance;
     void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    [SerializeField] Text[] allCoinsUIText;
    int[] coinCount;
    LoadSaveManager loadSaveManager;

    void Start()
    {
        coinCount = new int[2];
        loadSaveManager = LoadSaveManager.instance;
        coinCount[0] = loadSaveManager.IlluminatiCount;
        coinCount[1] = loadSaveManager.StarCount;
        UpdateAllCoinsUIText();
    }
    public void UseCoins(int amount, bool costsIlluminati)
    {
        coinCount[costsIlluminati?0:1] -= amount;
        if (costsIlluminati)
        {
            loadSaveManager.IlluminatiCount = coinCount[0];
        }
        else
        {
            loadSaveManager.StarCount = coinCount[1];
        }
    }

    public bool HasEnoughCoins(int amount, bool costsIlluminati)
    {
        return(coinCount[costsIlluminati ? 0 : 1] >= amount);
    }

    public void UpdateAllCoinsUIText()
    {
        for (int i=0;i<allCoinsUIText.Length;i++)
        {
            allCoinsUIText[i].text = coinCount[i].ToString();
        }
    }

}
