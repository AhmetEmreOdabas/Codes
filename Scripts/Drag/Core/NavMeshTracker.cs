using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshTracker : MonoBehaviour
{
    [SerializeField]
    private NavMeshSurface navMesh;

    private void Awake() 
    {
       navMesh.BuildNavMesh();
    }
}
