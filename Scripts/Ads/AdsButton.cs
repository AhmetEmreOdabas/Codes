using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

[RequireComponent(typeof(Button))]
public class AdsButton : MonoBehaviour , IUnityAdsListener
{
#if UNITY_IOS
    private string gameId = "3907788";
#elif UNITY_ANDROID
    private string gameId = "3907789";
#endif

    Button myButton;
    public string myPlacementId = "rewardedVideo";

    void Start()
    {
        myButton = GetComponent<Button>();

        myButton.interactable = Advertisement.IsReady(myPlacementId);

        if (myButton) myButton.onClick.AddListener(ShowRewardedVideo);

        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, true);
    }

    // Implement a function for showing a rewarded video ad:
    void ShowRewardedVideo()
    {
        Advertisement.Show(myPlacementId);
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsReady(string placementId)
    {
        // If the ready Placement is rewarded, activate the button: 
        if (placementId == myPlacementId)
        {
            myButton.interactable = true;
        }
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            PlayerStats.Lives += 10;
            myButton.interactable = false;
        }
        else if (showResult == ShowResult.Skipped)
        {
            myButton.interactable = false;
        }
        else if (showResult == ShowResult.Failed)
        {
            myButton.interactable = false;
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Optional actions to take when the end-users 
    }
}
