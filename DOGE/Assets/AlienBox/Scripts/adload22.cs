//using System;
////using GoogleMobileAds.Api;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.Advertisements;

//public class adload22 : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener, IUnityAdsInitializationListener
//{
//    private bool complete = false;
//    private int a = 0;
//    private void Awake()
//    {
//        InitializeAds();
//    }
//    public void InitializeAds()
//    {
//        Advertisement.Initialize("4662929", false, this);
//    }
//    private void Start()
//    {
//        LoadAd();
//    }
//    public void LoadAd()
//    {
//        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
//        Debug.Log("Loading Ad: " + "4662929");
//        Advertisement.Load("Rewarded_Android", this);
//    }

//    // Show the loaded content in the Ad Unit:
//    public void ShowAd(int a=0)
//    {
//        // Note that if the ad content wasn't previously loaded, this method will fail
//        Debug.Log("Showing Ad: " + "Rewarded_Android");
//        Advertisement.Show("Rewarded_Android", this);
//        this.a = a;
//    }

//    public void OnUnityAdsAdLoaded(string placementId)
//    {
//        Debug.Log("FUCK ME HARD");
//    }

//    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
//    {
//        throw new NotImplementedException();
//    }

//    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
//    {
//        throw new NotImplementedException();
//    }

//    public void OnUnityAdsShowStart(string placementId)
//    {

//    }

//    public void OnUnityAdsShowClick(string placementId)
//    {
//        throw new NotImplementedException();
//    }

//    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
//    {
//        if (placementId == "Rewarded_Android" && showCompletionState == UnityAdsShowCompletionState.COMPLETED)
//        {
//            if (a == 0)
//            {
//                game_manager.AdsWatched += 1;
//                game_manager.Clicked += 1;
//                game_manager.TrapAds += 1;
//                game_manager.TrapAdsTime = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
//                ulong add_gold = (ulong)UnityEngine.Random.Range(2000, 4000);
//                game_manager.golds += add_gold;
//                game_manager.Currency += add_gold;
//            }
//            else
//            {
//                game_manager.AdsWatched += 1;
//                game_manager.CurrencyClick ^= 1;
//                game_manager.CurrencyClickTime = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
//                game_manager.bprogressTime = true;
//            }
//        }
//    }

//    public void OnInitializationComplete()
//    {
//        Debug.Log("I was fucked 3 times");
//    }

//    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
//    {
//        throw new NotImplementedException();
//    }
//}
