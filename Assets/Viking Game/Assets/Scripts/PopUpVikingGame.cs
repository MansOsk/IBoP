using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpVikingGame : NetworkPopup
{
    public override void ProcessGameState(int[] state)
    {
        if (state[0] == 1 && (!TriggerOnce || !Created))
        {
            foreach (GameObject popUp in PopUps)
            {
                if (popUp.gameObject.CompareTag("Player1Won")) {
                    CreateObject(popUp);
                }
            }
        } else if (state[0] == 2 && (!TriggerOnce || !Created))
        {
            foreach (GameObject popUp in PopUps)
            {
                if (popUp.gameObject.CompareTag("Player2Won"))
                {
                    CreateObject(popUp);
                }
            }
        }
    }
}
