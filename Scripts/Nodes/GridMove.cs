using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMove : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private GameObject body;
    private Vector3 truePos;
    [SerializeField]
    private float gridSize;

    private void LateUpdate() 
    {
        truePos.x = Mathf.Floor(target.transform.position.x / gridSize) * gridSize;
        truePos.z = Mathf.Floor(target.transform.position.z / gridSize) * gridSize;
        truePos.y = 0;

        body.transform.position = truePos;
    }
}
