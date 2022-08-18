using UnityEngine;
using UnityEngine.Advertisements;

public class AdInitializer : MonoBehaviour
{
    AdInitializer S;
    

    void Awake()
    {
        InitializeAds();
    }

    public void InitializeAds()
    {

         Advertisement.Initialize("4662929", false);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        InitializeAds();
    }
}