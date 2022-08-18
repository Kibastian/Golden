using UnityEngine;
using UnityEngine.Advertisements;

public class AdInterstitial : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public static AdInterstitial S;
    public game_manager gm;
    public GameObject dm;

    void Awake()
    {
        S = this;

        // Get the Ad Unit ID for the current platform:
    }

    // Load content to the Ad Unit:
    public void LoadAd()
    {
        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
        Advertisement.Load("Interstitial_Android", this);
    }

    // Show the loaded content in the Ad Unit: 
    public void ShowAd()
    {
        // Note that if the ad content wasn't previously loaded, this method will fail
        Debug.Log("Showing Ad: " + "Interstitial_Android");
        Advertisement.Show("Interstitial_Android", this);
    }

    // Implement Load Listener and Show Listener interface methods:  
    public void OnUnityAdsAdLoaded(string placementId)
    {
        // Optionally execute code if the Ad Unit successfully loads content.
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit: {"Interstitial_Android"} - {error.ToString()} - {message}");
        // Optionally execute code if the Ad Unit fails to load, such as attempting to try again.
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {"Interstitial_Android"}: {error.ToString()} - {message}");
        // Optionally execute code if the Ad Unit fails to show, such as loading another ad.
    }

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        gm.but.SetActive(false);
        gm.cardbord_manager.SetActive(true);
        LoadAd();
        dm.SendMessage("datasave");
    }
}