using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public int colummLength, rowLength;
    public float x_Space, z_Space;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i < colummLength * rowLength; i++)
        {
            //prefab.GetComponent<Renderer>().material.color = Color.black;
            //Color c = new Color32(190, 119, 0, 255);
            GameObject colored =Instantiate(prefab, new Vector3(x_Space * (i % colummLength), 0, z_Space*(i / colummLength)),Quaternion.identity);
            //colored.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
