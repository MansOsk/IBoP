using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class moveObject : MonoBehaviour
{
    private Touch touch;
    private Camera cam;
    private float speedModifier;
    private GameObject che; // Selected checker
    private Transform trans;
    private float distance; //distance from the ray to its impact hit
    private float rot;
    public Camera UsedCamera;

    void Start()
    {
        speedModifier = 0.0008f;
        rot = gameObject.transform.rotation.y;
    }



    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            cam = Camera.current;
            Ray ray = cam.ScreenPointToRay(touch.position);

            RaycastHit rayHit;
            if (Physics.Raycast(ray, out rayHit) && touch.phase == TouchPhase.Began) //checks if the ray gets a hit and the first touch of an object
            {
                distance = rayHit.distance;
                if (rayHit.collider.gameObject.tag == "DragControlled") //"world" is a tag for the grid
                {
                    che = rayHit.collider.gameObject;
                    trans = che.GetComponent<Transform>(); //gets the component of the object that is hit
                }
            }
            else if (touch.phase == TouchPhase.Moved && che != null) //checks when the object is moved and if there is a object moved
            {
                float ang = transform.root.rotation.y;
                float deltax = (touch.deltaPosition.x * Mathf.Cos(ang) + touch.deltaPosition.y * Mathf.Sin(ang)) * speedModifier;
                float deltay = (touch.deltaPosition.x * Mathf.Sin(ang) + touch.deltaPosition.y * Mathf.Cos(ang)) * speedModifier;

                trans.position = new Vector3(
                    trans.position.x + deltax * distance,
                    trans.position.y,
                    trans.position.z + deltay * distance);



            }
            else if (touch.phase == TouchPhase.Ended && che != null) //releasing the object
            {
                che = null;
            }

        }

    }
}