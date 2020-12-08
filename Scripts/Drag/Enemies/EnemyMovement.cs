using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshPath path;
    Vector3 destination;
    private NavMeshAgent agent;

    private void Awake() 
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        destination = new Vector3 (38,0,7);
        agent.destination = destination;

        path = new NavMeshPath();

        NavMesh.CalculatePath(transform.position, destination, NavMesh.AllAreas, path);

        if (path.status == NavMeshPathStatus.PathPartial)
        {
            Debug.Log("No Path");
            Destroy(gameObject);
            WaveSpawner.EnemiesAlive --;
            PlayerStats.Lives --;
        }
    }
       
}

