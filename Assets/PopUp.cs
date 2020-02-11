using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PopUp : MonoBehaviour
{
    public GameObject Showbject;

    // Start is called before the first frame update
    void Start()
    {
        Showbject.transform.localPosition = new Vector3();
        Showbject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(ShowObject())
            Showbject.SetActive(true);
    }

    public virtual bool ShowObject()
    {
        return Input.GetKey(KeyCode.A);
    }
}

