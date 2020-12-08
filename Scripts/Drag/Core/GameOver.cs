using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    
     public SceneFader sceneFader; 

     public void Restart()
     {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
         WaveSpawner.StartingWave = false;
         WaveSpawner.EnemiesAlive = 0;
         NodeBuilding.BuildMode = false;
         Time.timeScale = 1f;
     }

     public void MenuGo()
     {
        sceneFader.FadeTO(0);
     }
}
