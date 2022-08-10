using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class banner : MonoBehaviour
{
    [SerializeField] BannerPosition _bannerPosition;


    private void Start()
    {
        // Set the banner position:
        Advertisement.Banner.SetPosition(_bannerPosition);
        StartCoroutine(LoadAdBanner());
    }

    private IEnumerator LoadAdBanner()
    {
        while (Advertisement.Banner.isLoaded == false)
        {
            yield return new WaitForSeconds(1f);
            LoadBanner();
        }
    }

    // Implement a method to call when the Load Banner button is clicked:
    public void LoadBanner()
    {
        // Set up options to notify the SDK of load events:
        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = OnBannerLoaded,
            errorCallback = OnBannerError
        };

        // Load the Ad Unit with banner content:
        Advertisement.Banner.Load("Banner_Android", options);
    }

    // Implement code to execute when the loadCallback event triggers:
    private void OnBannerLoaded()
    {
        Debug.Log("Banner loaded");
        ShowBannerAd();
    }

    // Implement code to execute when the load errorCallback event triggers:
    private void OnBannerError(string message)
    {
        LoadAdBanner();
        // Optionally execute additional code, such as attempting to load another ad.
    }

    // Implement a method to call when the Show Banner button is clicked:
    public void ShowBannerAd()
    {
        // Set up options to notify the SDK of show events:

        // Show the loaded Banner Ad Unit:
        Advertisement.Banner.Show("Banner_Android");
    }

    // Implement a method to call when the Hide Banner button is clicked:
    public void HideBannerAd()
    {
        // Hide the banner:
        Advertisement.Banner.Hide();
    }

    private void OnBannerClicked() { }
    private void OnBannerShown() { }
    private void OnBannerHidden() { }
}