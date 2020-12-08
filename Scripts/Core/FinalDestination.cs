using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDestination : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            PlayerStats.Lives--;
            WaveSpawner.EnemiesAlive --;
        }
    } 
}
