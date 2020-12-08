using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarRotation : MonoBehaviour
{
    private void Update() 
    {
        transform.eulerAngles = new Vector3(Camera.main.transform.eulerAngles.x , Camera.main.transform.eulerAngles.y , transform.eulerAngles.z);
    }
}
