using UnityEngine;
using UnityEngine.Advertisements;
using System;
using System.Collections;
using UnityEngine.Networking;

public class AdRewarded : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public static AdRewarded S;
    public int a = 0;
    public game_manager gm;
    public GameObject dm;
    string link = "https://alienfarm.ru/api/zalupa_her";

    void Awake()
    {
        S = this;

        // Get the Ad Unit ID for the current platform:
    }

    // Load content to the Ad Unit:
    public void LoadAd()
    {
        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
        Debug.Log("Loading Ad: " + "Rewarded_Android");
        UnityWebRequest Query = UnityWebRequest.Post(link, "Loading Unity");
        Query.SendWebRequest();
        Advertisement.Load("Rewarded_Android", this);
    }

   
    public void ShowAd(int a)
    {
        // Then show the ad:
        this.a = a;
        Advertisement.Show("Rewarded_Android", this);
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        LoadAd();
        if (placementId == "Rewarded_Android" && showCompletionState == UnityAdsShowCompletionState.COMPLETED)
        {
            switch (a)
            {
                case 0:
                    {
                        game_manager.AllWatched += 1;
                        game_manager.Clicked += 1;
                        game_manager.TrapAds += 1;
                        game_manager.TrapAdsTime = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
                        ulong add_gold = (ulong)UnityEngine.Random.Range(2000, 4000);
                        game_manager.golds += add_gold;
                        game_manager.Currency += add_gold;
                        break;
                    }
                case 1:
                    {
                        gm.TimePanel.SetActive(true);
                        game_manager.AllWatched += 1;
                        game_manager.BoostXWatched++;
                        game_manager.CurrencyClick ^= 1;
                        game_manager.CurrencyClickTime = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
                        game_manager.bprogressTime = true;
                        break;
                    }
                case 2:
                    {
                        game_manager.AllWatched += 1;
                        game_manager.auto_lv++;
                        game_manager.BoostAutoClickWatched++;
                        //auto_num_text_set();
                        gm.auto_num_new.text = ((int)((game_manager.auto_lv) / 20) * 5).ToString();
                        if ((game_manager.auto_lv) < 100)
                            gm.auto_num_new.text += ("  	  " + (((int)((game_manager.auto_lv) / 20) * 5) + 5));
                        gm.auto_num.text = 1 + (int.Parse(gm.auto_num.text) + 18) % 20 + "";
                        gm.shopgold_manage();
                        break;
                    }
                case 3:
                    {
                        game_manager.AllWatched += 1;
                        game_manager.Clicked += 1;
                        game_manager.TrapAds += 1;
                        game_manager.TrapAdsTime = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
                        ulong add_gold = (ulong)3000;
                        game_manager.golds += add_gold;
                        game_manager.Currency += add_gold;
                        break;
                    }
                case 4:
                    {
                        game_manager.DimondWatched++;
                        game_manager.AllWatched += 1;
                        game_manager.Clicked += 1;
                        game_manager.TrapAds += 1;
                        game_manager.TrapAdsTime = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
                        ulong add_gold = (ulong)UnityEngine.Random.Range(2000, 4000)*(ulong)(game_manager.CrystallMulti?5:1);
                        game_manager.golds += add_gold;
                        game_manager.Currency += add_gold;
                        break;
                    }
                case 5:
                    {
                        game_manager.InterstitialWatched++;
                        game_manager.AllWatched++;
                        gm.but.SetActive(false);
                        gm.cardbord_manager.SetActive(true);
                        gm.ad_time += UnityEngine.Random.RandomRange(180, 300);
                        game_manager.Interstitial = false;
                        break;
                    }
            }
        }
        dm.SendMessage("data_save");
        UnityWebRequest Query = UnityWebRequest.Post(link, "Showed Unity");
        Query.SendWebRequest();
    }

    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Ad Loaded: " + adUnitId);
    }

    // Implement Load and Show Listener error callbacks:
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        UnityWebRequest Query = UnityWebRequest.Post(link, "Fucked Unity");
        Query.SendWebRequest(); 
        LoadAd();
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }
}