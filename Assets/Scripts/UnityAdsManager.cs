using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdsManager : MonoBehaviour
{
    public static UnityAdsManager Instance { get; private set; }

    public string AndroidID = "1234567";
    public string IOSID = "1234567";
    public string placementId = "Banner";

    public string placementIdInter = "video";
    public string placementIdReward = "rewardedVideo";



    public bool testMode = true;
    // Start is called before the first frame update
    void Start()
    {

        //PlayerPrefs.DeleteAll();
#if UNITY_ANDROID
        Advertisement.Initialize(AndroidID, testMode);
#else
        Advertisement.Initialize(IOSID, testMode);

#endif
    }
    private void Awake()
    {
        if (Instance)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void showBanner()
    {
        //if (PlayerPrefs.GetInt("TOTHEFUTUREAds", 0) == 0)
        //{
        //    Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);

        //    Advertisement.Banner.Show(placementId);
        //}
       

    }
    public void hideBanner()
    {
        //Advertisement.Banner.Hide();
    }

    public void ShowInterstitialAd()
    {
        
            // Check if UnityAds ready before calling Show method:
            if (Advertisement.IsReady(placementIdInter))
            {
                Advertisement.Show(placementIdInter);
            }
            else
            {
                Debug.Log("Interstitial ad not ready at the moment! Please try again later!");
            }
        
    }

    public void ShowRewardedVideo()
    {
        if (Advertisement.IsReady(placementIdReward))
        {
            ShowOptions option = new ShowOptions();
            option.resultCallback = RewardedCallback;

            Advertisement.Show(placementIdReward, option);

        }
       
    }

    // Implement IUnityAdsListener interface methods:
    private void RewardedCallback(UnityEngine.Advertisements.ShowResult result)
    {

        if (result == UnityEngine.Advertisements.ShowResult.Finished)
        {
            //unity reward
            GameManager.instance.rewardSkipLevel();
        }

    }



}