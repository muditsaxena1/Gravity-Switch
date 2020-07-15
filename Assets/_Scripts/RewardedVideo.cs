using UnityEngine.Events;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine.UI;
using System;
using System.Collections.Generic;


public class RewardedVideo : MonoBehaviour
{
    public GameObject adPanel;
    public AudioSource bgMusic;
    public GameObject illuminatiSpawn;
    LoadSaveManager loadSaveManager;
    Game game;
    

    // ########### THIS IS TEST AD ID ############## "ca-app-pub-3940256099942544/5224354917"
    string adUnitId = "ca-app-pub-3940256099942544/5224354917";
    private RewardedAd rewardedAd;

    public void Start()
    {
        MobileAds.Initialize(initStatus => { });
        loadSaveManager = LoadSaveManager.instance;
        CreateAndLoadRewardedAd();
    }

    public void CreateAndLoadRewardedAd()
    {
        this.rewardedAd = new RewardedAd(adUnitId);

        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        AdRequest request = new AdRequest.Builder().Build();
        this.rewardedAd.LoadAd(request);
    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
        bgMusic.Pause();
        adPanel.SetActive(false);
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
        bgMusic.Play();
        illuminatiSpawn.SetActive(false);
        illuminatiSpawn.SetActive(true);
        CreateAndLoadRewardedAd();
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);
        Debug.Log("Add 1 illuminati to the LoadSaveManager");
        loadSaveManager.IlluminatiCount += 1;
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            //Shop
            if(game == null)
            {
                game = Game.instance;
                game.UpdateAllCoinsUIText();
            }
        }
    }

    public void OnClickFreeButton()
    {
        adPanel.SetActive(true);
    }
    public void OnClickCrossButton()
    {
        adPanel.SetActive(false);
    }


    public void OnClickWatchAds()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
    }
}
