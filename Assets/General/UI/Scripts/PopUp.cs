using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PopUp : MonoBehaviour
{
    public GameState State;
    public List<GameObject> PopUps;
    public bool TriggerOnce;
    private bool Created; 

    // Start is called before the first frame update
    void Start()
    {
        Created = false; 
    }
    // Update is called once per frame
    void Update()
    {
        ProcessGameState(State.GetState());
    }

    public virtual void ProcessGameState(int[] state)
    {
        if (state[0] > -1 && (!TriggerOnce || !Created))
        {
            foreach(GameObject popUp in PopUps)
            {
                Instantiate(popUp);
                Created = true;
            }
        }
    }


}
public abstract class GameState : MonoBehaviour
{
    public abstract int[] GetState();
}

