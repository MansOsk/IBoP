using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkManagerScript : NetworkManager
{
    public void Host()
    {
        StartHost();
    }

    public void SetIP(string ip)
    {
        networkAddress = ip;
    }

    public void Join()
    {
        StartClient();
    }
}
