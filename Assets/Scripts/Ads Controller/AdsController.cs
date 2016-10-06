using System;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

public class AdsController : MonoBehaviour {

    public static AdsController instance;

    private BannerView bannerView;
    private InterstitialAd interstitial;

    // Use this for initialization
    void Start () {
        RequestBanner();
        RequestInterstitial();
	}

    // Update is called once per frame
    void Awake()
    {
        MakeSingleton();
    }

    void MakeSingleton()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void OnLevelWasLoaded()
    {

        if (SceneManager.GetActiveScene().name == "Gameplay" || SceneManager.GetActiveScene().name == "OptionsMenu" || SceneManager.GetActiveScene().name == "HighscoreMenu")
        {
            ShowBanner();
            ShowInterstitial();
        }
    }
    // Returns an ad request with custom ad targeting.
    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder()
            .AddTestDevice(AdRequest.TestDeviceSimulator)
            .AddTestDevice("0123456789ABCDEF0123456789ABCDEF")
            .AddKeyword("game")
            .SetGender(Gender.Male)
            .SetBirthday(new DateTime(1985, 1, 1))
            .TagForChildDirectedTreatment(false)
            .AddExtra("color_bg", "9B30FF")
            .Build();
    }

    private void RequestBanner()
    {
        // These ad units are configured to always serve test ads.
        #if UNITY_EDITOR
                string adUnitId = "unused";
        #elif UNITY_ANDROID
                string adUnitId = "ca-app-pub-7412210849661646/2852882611";
        #elif UNITY_IPHONE
                string adUnitId = "ca-app-pub-7412210849661646/2852882611";
        #else
                string adUnitId = "unexpected_platform";
        #endif

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Top);

        // Register for ad events.

        RegisterDelegateForBanner();

        // Load a banner ad.
        this.bannerView.LoadAd(this.CreateAdRequest());
    }

    private void RequestInterstitial()
    {
        // These ad units are configured to always serve test ads.
        #if UNITY_EDITOR
                string adUnitId = "unused";
        #elif UNITY_ANDROID
                string adUnitId = "ca-app-pub-7412210849661646/4329615811";
        #elif UNITY_IPHONE
                string adUnitId = "ca-app-pub-7412210849661646/4329615811";
        #else
                string adUnitId = "unexpected_platform";
        #endif

        // Create an interstitial.
        this.interstitial = new InterstitialAd(adUnitId);

        // Register for ad events.
        RegisterDelegateForInterstitial();

        // Load an interstitial ad.
        this.interstitial.LoadAd(this.CreateAdRequest());
    }

    void RegisterDelegateForBanner()
    {
        this.bannerView.OnAdLoaded += this.HandleAdLoaded;
        this.bannerView.OnAdFailedToLoad += this.HandleAdFailedToLoad;
        this.bannerView.OnAdLoaded += this.HandleAdOpened;
        this.bannerView.OnAdClosed += this.HandleAdClosed;
        this.bannerView.OnAdLeavingApplication += this.HandleAdLeftApplication;
    }

    public void UnRegisterDelegateForBanner()
    {
        Debug.Log("unregister");
        this.bannerView.OnAdLoaded -= this.HandleAdLoaded;
        this.bannerView.OnAdFailedToLoad -= this.HandleAdFailedToLoad;
        this.bannerView.OnAdLoaded -= this.HandleAdOpened;
        this.bannerView.OnAdClosed -= this.HandleAdClosed;
        this.bannerView.OnAdLeavingApplication -= this.HandleAdLeftApplication;
        
    }


    void RegisterDelegateForInterstitial()
    {
        this.interstitial.OnAdLoaded += this.HandleInterstitialLoaded;
        this.interstitial.OnAdFailedToLoad += this.HandleInterstitialFailedToLoad;
        this.interstitial.OnAdOpening += this.HandleInterstitialOpened;
        this.interstitial.OnAdClosed += this.HandleInterstitialClosed;
        this.interstitial.OnAdLeavingApplication += this.HandleInterstitialLeftApplication;
    }

    void UnRegisterDelegateForInterstitial()
    {
        this.interstitial.OnAdLoaded -= this.HandleInterstitialLoaded;
        this.interstitial.OnAdFailedToLoad -= this.HandleInterstitialFailedToLoad;
        this.interstitial.OnAdOpening -= this.HandleInterstitialOpened;
        this.interstitial.OnAdClosed -= this.HandleInterstitialClosed;
        this.interstitial.OnAdLeavingApplication -= this.HandleInterstitialLeftApplication;
    }


    public void ShowBanner()
    {
        bannerView.Show();
    }

    public void ShowInterstitial()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
        else
        {
            RequestInterstitial();
        }
    }

    #region Banner callback handlers

    public void HandleAdLoaded(object sender, EventArgs args)
    {
        ShowBanner();
    }

    public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
         
        RequestBanner();
    }

    public void HandleAdOpened(object sender, EventArgs args)
    {
         
    }

    public void HandleAdClosed(object sender, EventArgs args)
    {
       
        UnRegisterDelegateForBanner();
        RequestBanner();
    }

    public void HandleAdLeftApplication(object sender, EventArgs args)
    {
        
    }

    #endregion

    #region Interstitial callback handlers

    public void HandleInterstitialLoaded(object sender, EventArgs args)
    {
         
    }

    public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
       
        UnRegisterDelegateForInterstitial();
        RequestInterstitial();
    }

    public void HandleInterstitialOpened(object sender, EventArgs args)
    {
        
    }

    public void HandleInterstitialClosed(object sender, EventArgs args)
    {
         
        UnRegisterDelegateForInterstitial();
        RequestInterstitial();
    }

    public void HandleInterstitialLeftApplication(object sender, EventArgs args)
    {
        
    }

    #endregion

}
public class GoogleMobileAdsDemoHandler : IDefaultInAppPurchaseProcessor
{
    private readonly string[] validSkus = { "android.test.purchased" };

    public static string key = "pub-7412210849661646";

    // Will only be sent on a success.
    public void ProcessCompletedInAppPurchase(IInAppPurchaseResult result)
    {
        result.FinishPurchase();
        GoogleMobileAdsDemoScript.OutputMessage = "Purchase Succeeded! Credit user here.";
    }

    // Check SKU against valid SKUs.
    public bool IsValidPurchase(string sku)
    {
        foreach (string validSku in this.validSkus)
        {
            if (sku == validSku)
            {
                return true;
            }
        }

        return false;
    }

    // Return the app's public key.
    public string AndroidPublicKey
    {
        // In a real app, return public key instead of null.
        get { return key; }
    }
}