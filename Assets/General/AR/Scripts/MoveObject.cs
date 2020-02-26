using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Networking;
public class MoveObject : MonoBehaviour
{
    private Touch touch;
    private Camera cam;
    private float speedModifier;
    private GameObject che; // Selected checker
    private Vector2 LastPos;
    private Transform trans;
    private float distance; //distance from the ray to its impact hit
    private float rot;
    //public Camera UsedCamera;
    public NetworkManager manager;
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
                    //CmdAssignNetworkAuthority(che.GetComponent<NetworkIdentity>(), manager.client.connection);
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
        if (Input.GetMouseButtonDown(0))
        {
            cam = Camera.main;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            RaycastHit rayHit;
            if (Physics.Raycast(ray, out rayHit)) //checks if the ray gets a hit and the first touch of an object
            {
                distance = rayHit.distance;
                if (rayHit.collider.gameObject.tag == "DragControlled") //"world" is a tag for the grid
                {
                    che = rayHit.collider.gameObject;
                    trans = che.GetComponent<Transform>(); //gets the component of the object that is hit
                }
                if (LastPos == null)
                    LastPos = Input.mousePosition;
                Vector2 newPosTrans = LastPos - new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                float ang = transform.root.rotation.y;
                float deltax = (newPosTrans.x * Mathf.Cos(ang) + newPosTrans.y * Mathf.Sin(ang)) * speedModifier;
                float deltay = (newPosTrans.x * Mathf.Sin(ang) + newPosTrans.y * Mathf.Cos(ang)) * speedModifier;

                trans.position = new Vector3(
                    trans.position.x + deltax * distance,
                    trans.position.y,
                    trans.position.z + deltay * distance);
                LastPos = trans.position;
            }
        }
    }
    
    public void CmdAssignNetworkAuthority(NetworkIdentity cubeId, NetworkConnection clientId)
    {
        //If -> cube has a owner && owner isn't the actual owner
        if (cubeId.clientAuthorityOwner != null && cubeId.clientAuthorityOwner != clientId)
        {
            // Remove authority
            cubeId.RemoveClientAuthority(cubeId.clientAuthorityOwner);
        }

        //If -> cube has no owner
        if (cubeId.clientAuthorityOwner == null)
        {
            // Add client as owner
            cubeId.AssignClientAuthority(clientId);
        }
    }
}