using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PopUp : MonoBehaviour
{
    public GameState State;
    public List<GameObject> PopUps;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        ProcessGameState(State.GetState());
    }

    public virtual void ProcessGameState(int[] state)
    {
        if (state[0] > -1)
        {
            foreach(GameObject popUp in PopUps)
            {
                popUp.SetActive(true);
            }
        }
    }


}
public abstract class GameState : MonoBehaviour
{
    public abstract int[] GetState();
}

