using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private bool canMove = true;

    public float panSpeed = 10f;

    public float scrollSpeed = 5f;
    public float minY = 5f;
    public float maxY = 25f;

    public float minX = 7;
    public float maxX = 30;

    public float minZ = -3;
    public float maxZ = 4;

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canMove = !canMove;
        }

        if (!canMove)
        {
            return;
        }

        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
       
        float scroll = Input.GetAxis("Mouse ScrollWheel");
#endif
        
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);

#if UNITY_EDITOR
        pos.y -= scroll * 500 * scrollSpeed * Time.deltaTime;
#endif
        transform.position = pos;
    }
}
