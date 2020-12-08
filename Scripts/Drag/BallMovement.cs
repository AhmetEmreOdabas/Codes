using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    private Vector2 truePlace;

    private Vector2 startingPS;
    private GameObject selectedBall;
    private bool canDrag;
    [SerializeField] LayerMask box;
    [SerializeField] Transform boxCheck;
    [SerializeField] private const float boxCheckRadius = 0.3f;
    private Rigidbody2D rb;

    private float deltaX, deltaY;

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        canDrag = true;
                        selectedBall = this.gameObject;
                        
                    }
                    break;

                case TouchPhase.Moved:

                    selectedBall.transform.position = new Vector2(touchPos.x, touchPos.y);
                    rb.isKinematic = true;

                    Collider2D[] colliders = Physics2D.OverlapCircleAll(boxCheck.position, boxCheckRadius, box);
                    for (int i = 0; i < colliders.Length; i++)
                    {
                        if (colliders[i].gameObject != gameObject)
                        {
                            Debug.Log("collider name" + i);
                            canDrag = false;
                            selectedBall = null;
                            rb.isKinematic = false;
                        }
                    }

                    break;

                case TouchPhase.Ended:
                    if (!canDrag)
                        return;
                    selectedBall = null;
                    rb.isKinematic = false;
                    break;
            }
        }
    }
#if UNITY_EDITOR
    private void OnMouseDown()
    {
        canDrag =true;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

        if (hit)
        {
           if(GetComponent<Collider2D>() == Physics2D.OverlapPoint(hit.point))
           {

              
                selectedBall = this.gameObject;
           }
         
        }
    }

    private void OnMouseDrag()
    {
       if(!canDrag)
       return;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        
        rb.isKinematic = true;
        selectedBall.transform.position = new Vector2(hit.point.x ,hit.point.y);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(boxCheck.position, boxCheckRadius, box);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                Debug.Log("collider name" + i);
               canDrag = false;
               selectedBall=null;
               rb.isKinematic = false;
            }
        }
    }

    private void OnMouseUp()
    {
        if(!canDrag)
        return;
        selectedBall = null;
        rb.isKinematic = false;
    }
    
       
#endif
}
