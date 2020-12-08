using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class NodeBuilding : MonoBehaviour
{
    [SerializeField]
    private GameObject nodeGhostPrefab;
    [SerializeField]
    private GameObject nodePrefab;
    [SerializeField]
    private CommandManager commandManager;

    private GameObject nodeGhost;

    public bool ghostInstantiated = false;

    public static bool BuildMode = false;

    private Touch touch;
    private int mobileOffsetZ = 5;
    private int mobileOffsetX = 2;

    private List<Collider> colliders = new List<Collider>();


    private void Update()
    {

#if UNITY_EDITOR
        MouseInput();
#endif

#if UNITY_IOS || UNITY_ANDROID
        TouchInput();
#endif
    }
    public void TouchInput()
    {
         if (BuildMode)
        {

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        break;
                    case TouchPhase.Moved:
                        if (Physics.Raycast(ray, out hit))
                        {
                            this.transform.position = new Vector3(hit.point.x + mobileOffsetX, 0, hit.point.z + mobileOffsetZ);
                        }

                        if (!ghostInstantiated)
                        {


                            if (Physics.Raycast(ray, out hit))
                            {
                                if (hit.collider.tag == "Platform" || hit.collider.tag == "Node")
                                {
                                    nodeGhost = Instantiate(nodeGhostPrefab);
                                    nodeGhost.transform.position = new Vector3(hit.point.x + mobileOffsetX, 0, hit.point.z + mobileOffsetZ);
                                    ghostInstantiated = true;
                                }
                            }
                        }
                        else
                        {


                            if (Physics.Raycast(ray, out hit))
                            {
                                if (hit.collider.tag == "Platform" || hit.collider.tag == "Node")
                                {
                                    nodeGhost.transform.position = new Vector3(hit.point.x + mobileOffsetX, 0, hit.point.z + mobileOffsetZ);
                                    ghostInstantiated = true;
                                }
                                else
                                {
                                    Destroy(nodeGhost);
                                    ghostInstantiated = false;
                                }
                            }
                        }
                        break;
                    case TouchPhase.Ended:
                        if (colliders.Count <= 0)
                        {

                            if (Physics.Raycast(ray, out hit))
                            {
                                if (!EventSystem.current.IsPointerOverGameObject())
                                {
                                    commandManager.ExecuteCommand(new InstantiateCommand(nodePrefab, this.transform.position));
                                }
                            }
                        }
                        break;
                }
            }
        }
    }

    public void MouseInput()
    {
         if (BuildMode)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                this.transform.position = new Vector3(hit.point.x + mobileOffsetZ, 0, hit.point.z);
            }

            if (!ghostInstantiated)
            {


                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "Platform" || hit.collider.tag == "Node")
                    {
                        nodeGhost = Instantiate(nodeGhostPrefab);
                        nodeGhost.transform.position = new Vector3(hit.point.x + mobileOffsetZ, 0, hit.point.z);
                        ghostInstantiated = true;
                    }
                }
            }
            else
            {


                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "Platform" || hit.collider.tag == "Node")
                    {
                        nodeGhost.transform.position = new Vector3(hit.point.x + mobileOffsetZ, 0, hit.point.z);
                        ghostInstantiated = true;
                    }
                    else
                    {
                        Destroy(nodeGhost);
                        ghostInstantiated = false;
                    }
                }
            }
            if (Input.GetMouseButtonDown(0) && colliders.Count <= 0)
            {

                if (Physics.Raycast(ray, out hit))
                {
                    if (!EventSystem.current.IsPointerOverGameObject())
                    {
                        commandManager.ExecuteCommand(new InstantiateCommand(nodePrefab, this.transform.position));
                    }
                }
            }
        }
    }

    public void BuildModeOn()
    {
         if (BuildMode == false)
        {
             BuildMode = true;
             colliders.Clear();
            return;
        }
        if (BuildMode == true)
        {
               BuildMode = false;
             if (nodeGhost != null)
            {
                 Destroy(nodeGhost);
                  ghostInstantiated = false;
            }
              return;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Node")
        {
            colliders.Add(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Node")
        {
            colliders.Remove(other);
        }
    }
}