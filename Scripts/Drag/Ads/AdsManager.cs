using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour , IUnityAdsListener
{

    public string gameId = "3907789";

    public string placement = "rewardedVideo";

    bool testMode = true;

    public GameObject adsObject;

    void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, true);
     
    }

         public void ShowAd(string placementId)
    {
            if (placementId == placement)
        {
            Advertisement.Show(placement);
            Debug.Log("showed");
        }
    }


    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        
        if (showResult == ShowResult.Finished)
        {
            PlayerStats.Lives += 10;
            adsObject.SetActive(false);
            Debug.Log("lives added");
            Advertisement.RemoveListener(this);
        }
        else if (showResult == ShowResult.Skipped)
        {
            Advertisement.RemoveListener(this);
        }
        else if (showResult == ShowResult.Failed)
        {
            Advertisement.RemoveListener(this);
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        
    }

    public void OnUnityAdsDidError(string message)
    {
        
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        
    }
}
