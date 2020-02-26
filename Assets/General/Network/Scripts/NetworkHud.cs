using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.Networking.Match;
using UnityEngine.Networking.PlayerConnection;
using UnityEngine.Networking.Types;

public class NetworkHud : MonoBehaviour
{
    NetworkManager m;
    // Start is called before the first frame update
    void Start()
    {
        m = gameObject.GetComponent<NetworkManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Host()
    {
        m.StartHost();
    }
    public void Join()
    {
        m.StartClient();
    }
    public void ChangeIp(string ip)
    {
        m.networkAddress = ip;
    }
}
