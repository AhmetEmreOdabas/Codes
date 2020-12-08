using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   public GameObject ui;
   public SceneFader SceneFader;

   public void Pause()
   {
       ui.SetActive(true);
       Time.timeScale = 0f;
   }

   public void Continue()
   {
        ui.SetActive(false);
        Time.timeScale = 1f;
   }

   public void Restart()
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        WaveSpawner.EnemiesAlive = 0;
        NodeBuilding.BuildMode = false;
        WaveSpawner.StartingWave = false;
        Time.timeScale = 1f;
   }

   public void Menu()
   {
      Time.timeScale = 1f;
      SceneFader.FadeTO(0);
   }
}
