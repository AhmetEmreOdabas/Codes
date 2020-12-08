using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class StartWaveButton : MonoBehaviour
{
    public GameObject startButton;
    public GameObject nodeButton;
    public GameObject undoButton;
    public NavMeshSurface gameMesh;
    public GameObject canvasA;
    public GameObject canvasB;

    public void StartTheGame()
    {
        canvasA.SetActive(false);
        canvasB.SetActive(false);
        WaveSpawner.StartingWave = true;
        new WaitForSeconds(0.3f);
        nodeButton.SetActive(false);
        undoButton.SetActive(false);
        NodeBuilding.BuildMode = false;
        startButton.SetActive(false);
        gameMesh.BuildNavMesh();
    }
}
