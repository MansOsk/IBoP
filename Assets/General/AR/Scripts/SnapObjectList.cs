using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapObjectList : MonoBehaviour
{
    public List<Snap> Snaps;
    public int XMax = int.MaxValue, XMin = int.MinValue, YMax = int.MaxValue, YMin = int.MinValue, ZMax = int.MaxValue, ZMin = int.MinValue;
    // Start is called before the first frame update
    void Start()
    {
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            Snap current = child.gameObject.GetComponent<Snap>();
            if (current != null)
                Snaps.Add(current);
        }
        for(int k = 0; k < Snaps.Count; k++)
        {
            Snaps[k].SnapObjectList = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
