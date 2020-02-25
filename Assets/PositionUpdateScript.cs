using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositionUpdateScript : Text
{
    public GameObject Position;

    // Update is called once per frame
    void Update()
    {
        Position = Camera.main.gameObject;
        text = "X: " + Position.transform.position.x + " ,Y: " + Position.transform.position.y + " ,Z: " + Position.transform.position.z;
    }
}
