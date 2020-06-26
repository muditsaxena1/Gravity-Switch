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
    public int coins;
    void Start()
    {
        UpdateAllCoinsUIText();
    }
    public void UseCoins(int amount)
    {
        coins -=amount;
    }

    public bool HasEnoughCoins(int amount)
    {
        return(coins>=amount);
    }

    public void UpdateAllCoinsUIText()
    {
        for (int i=0;i<allCoinsUIText.Length;i++)
        {
            allCoinsUIText[i].text = coins.ToString();
        }
    }

}
