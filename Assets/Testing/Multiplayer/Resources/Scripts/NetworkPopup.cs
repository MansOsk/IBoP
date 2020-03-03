using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkPopup : PopUp
{
    // Start is called before the first frame update
    void Start()
    {
        Created = false; 
    }

    void Update()
    {
        if(State != null)
            ProcessGameState(State.GetState());
    }

    public override void ProcessGameState(int[] state)
    {
        if (state[0] > -1 && (!TriggerOnce || !Created))
        {
            foreach (GameObject popUp in PopUps)
            {
                CreateObject(popUp);
            }
        }
    }

    public override GameObject CreateObject(GameObject popUp)
    {
        var p = NetworkManager.Instantiate(popUp);
        NetworkServer.Spawn(p);

        Created = true;

        return p;
    }
}
