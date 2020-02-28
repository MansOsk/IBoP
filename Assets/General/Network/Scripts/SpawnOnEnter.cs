using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SpawnOnEnter : NetworkBehaviour
{
    public GameObject AddObject;
    public NetworkManager manager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            //NetworkIdentity go = Instantiate(GameObject, transform.position, transform.rotation);
            //GameObject.transform.Translate(1, 0, 0);
            if(NetworkServer.active)
                NetworkServer.SpawnWithClientAuthority(NetworkManager.Instantiate(AddObject), GameObject.FindGameObjectsWithTag("Player")[1]);
        }
    }


}
