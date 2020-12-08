using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int levelToLoad = 1;
    public SceneFader sceneFader;
    public GameObject canvas1;
    public GameObject canvas2;

    public void Play()
    {
        sceneFader.FadeTO(levelToLoad);
        WaveSpawner.StartingWave = false;
    }
    public void HowToPLay()
    {
        canvas1.SetActive(false);
        canvas2.SetActive(true);
    }

    public void BackToMenu()
    {
        canvas1.SetActive(true);
        canvas2.SetActive(false);
    }

    public void Quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
