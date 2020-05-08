/*
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
 
public class AdManager : MonoBehaviour
{
    private string APP_ID = "ca-app-pub-2580706232902777~5473800643";

    private BannerView bannerAD;
    private InterstitialAd interstitialAd;
    private RewardBasedVideoAd rewardVideoAd;
    private bool subscribe;


    public void Start()
    {
        //MobileAds.Initialize(APP_ID);

        RequestBanner();
        RequestInterstitial();
        RequestVideoAD();
    }


    void RequestBanner()
    {
        string banner_ID = "ca-app-pub-3940256099942544/6300978111";
        //string banner_ID = "ca-app-pub-2580706232902777/7221803069";
        bannerAD = new BannerView(banner_ID, AdSize.SmartBanner, AdPosition.Bottom);

        if (subscribe)
        {
            // Called when an ad request has successfully loaded.
            this.bannerAD.OnAdLoaded += this.HandleOnAdLoaded;
            // Called when an ad request failed to load.
            this.bannerAD.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
            // Called when an ad is clicked.
            this.bannerAD.OnAdOpening += this.HandleOnAdOpened;
            // Called when the user returned from the app after an ad click.
            this.bannerAD.OnAdClosed += this.HandleOnAdClosed;
            // Called when the ad click caused the user to leave the application.
            this.bannerAD.OnAdLeavingApplication += this.HandleOnAdLeavingApplication;
        }
        else
        {
            // Called when an ad request has successfully loaded.
            this.bannerAD.OnAdLoaded -= this.HandleOnAdLoaded;
            // Called when an ad request failed to load.
            this.bannerAD.OnAdFailedToLoad -= this.HandleOnAdFailedToLoad;
            // Called when an ad is clicked.
            this.bannerAD.OnAdOpening -= this.HandleOnAdOpened;
            // Called when the user returned from the app after an ad click.
            this.bannerAD.OnAdClosed -= this.HandleOnAdClosed;
            // Called when the ad click caused the user to leave the application.
            this.bannerAD.OnAdLeavingApplication -= this.HandleOnAdLeavingApplication;
        }

        //FOR REAL APP
        //AdRequest adRequest = new AdRequest.Builder().Build();

        //FOR TESTING
        AdRequest adRequest = new AdRequest.Builder()
            .AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

        bannerAD.LoadAd(adRequest);
    }
     
    void RequestInterstitial()
    {
        string intertitial_ID = "ca-app-pub-3940256099942544/1033173712";
        //string intertitial_ID = "ca-app-pub-2580706232902777/9656394719";
        interstitialAd = new InterstitialAd(intertitial_ID);

        //FOR REAL APP
        //AdRequest adRequest = new AdRequest.Builder().Build();

        //FOR TESTING
        AdRequest adRequest = new AdRequest.Builder()
            .AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

        interstitialAd.LoadAd(adRequest);
    }

    void RequestVideoAD()
    {
        string video_ID = "ca-app-pub-3940256099942544/5224354917";
        //string video_ID = "ca-app-pub-2580706232902777/2899414673";
        rewardVideoAd = RewardBasedVideoAd.Instance;

        //FOR REAL APP
        //AdRequest adRequest = new AdRequest.Builder().Build();

        //FOR TESTING
        AdRequest adRequest = new AdRequest.Builder()
            .AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

        rewardVideoAd.LoadAd(adRequest, video_ID);
    } 

*/

    //////////////////////////// Video Reward /////////////////////////////////////

/*
     
    private void showAdd(RewardBasedVideoAd rewardBasedVideo)
    {
        if (rewardBasedVideo.IsLoaded())
        {
            //Subscribe to Ad event
            rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
            rewardBasedVideo.Show();
        }
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        //Reawrd User here
        print("User rewarded with: " + amount.ToString() + " " + type);
    }
    
*/

    //////////////////////////////////////////////////////////////////////////////

/*
     
    public void Display_Banner()
    {
        bannerAD.Show();
    }

    public void Display_InterstitialAD()
    {
        if (interstitialAd.IsLoaded()) 
        {
            interstitialAd.Show();
        }
    }

    public void Display_Reward_Video()
    {
        if (rewardVideoAd.IsLoaded())
        {
            rewardVideoAd.Show();
        }
    }

    //HANDLE EVENTS

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        // ad is loaded show it
        Display_Banner();
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        // ad failed to load, load ir again
        RequestBanner();
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }

    void OnEnable()
    {
        subscribe = true;
    }
    void OnDisable()
    {
        subscribe = false;
    }
}
*/



 /*
  void HandleBannerAdEvents(int subs) {
        if(subs == 1)
        {
            // Called when an ad request has successfully loaded.
            this.bannerAD.OnAdLoaded += this.HandleOnAdLoaded;
            // Called when an ad request failed to load.
            this.bannerAD.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
            // Called when an ad is clicked.
            this.bannerAD.OnAdOpening += this.HandleOnAdOpened;
            // Called when the user returned from the app after an ad click.
            this.bannerAD.OnAdClosed += this.HandleOnAdClosed;
            // Called when the ad click caused the user to leave the application.
            this.bannerAD.OnAdLeavingApplication += this.HandleOnAdLeavingApplication;
        }
        else 
        {
            // Called when an ad request has successfully loaded.
            this.bannerAD.OnAdLoaded -= this.HandleOnAdLoaded;
            // Called when an ad request failed to load.
            this.bannerAD.OnAdFailedToLoad -= this.HandleOnAdFailedToLoad;
            // Called when an ad is clicked.
            this.bannerAD.OnAdOpening -= this.HandleOnAdOpened;
            // Called when the user returned from the app after an ad click.
            this.bannerAD.OnAdClosed -= this.HandleOnAdClosed;
            // Called when the ad click caused the user to leave the application.
            this.bannerAD.OnAdLeavingApplication -= this.HandleOnAdLeavingApplication;
        }
    }
*/

 