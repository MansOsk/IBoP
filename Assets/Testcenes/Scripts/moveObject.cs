using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class moveObject : MonoBehaviour
{
    private Touch touch;
    private Camera cam;
    private float speedModifier;
   


    void Start()
    {
        speedModifier = 0.0002f;
       
    }


    
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            cam = Camera.current;
            Ray ray = cam.ScreenPointToRay(touch.position);
            RaycastHit rayHit;
            if(Physics.Raycast(ray, out rayHit) && touch.phase == TouchPhase.Moved)
            {
                float ang = 0;
                float deltax = (touch.deltaPosition.x * Mathf.Cos(ang) + touch.deltaPosition.y * Mathf.Sin(ang)) * speedModifier;
                float deltay = (touch.deltaPosition.x * Mathf.Sin(ang) + touch.deltaPosition.y * Mathf.Cos(ang)) * speedModifier;
                if (gameObject.name.Equals(rayHit.collider.gameObject.name))
                {
                    transform.position = new Vector3(
                        transform.position.x + deltax,
                        transform.position.y,
                        transform.position.z + deltay);
                   
                }
                
                //else if (gameObject.name.Equals("Cube2"))
                //{
                //    transform.position = new Vector3(
                //        transform.position.x + deltax,
                //        transform.position.y,
                //        transform.position.z + deltay);
                //}
                //else if (gameObject.name.Equals("Cube3"))
                //{
                //    transform.position = new Vector3(
                //        transform.position.x + deltax,
                //        transform.position.y,
                //        transform.position.z + deltay);
                //}
            }
           
        }

    }
}