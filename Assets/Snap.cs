using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    float size = 0.667f;
    public float snapSpeed = 1f;
    const int s = 1;
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount <= 0)
        {
            float x = (transform.localPosition.x) / size;
            float z = (transform.localPosition.z) / size;
            x = (int)x;
            z = (int)z;
            Vector3 vec = new Vector3(x * size, transform.localPosition.y, z * size);
            //vec /= snapSpeed;
            gameObject.transform.localPosition = vec;
        }
    }
}
