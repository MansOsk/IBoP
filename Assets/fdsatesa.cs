using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fdsatesa : MonoBehaviour
{
    public Mesh Mesh;
    public Material Material;
    public List<Transform> Objects;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        Matrix4x4[] instances = new Matrix4x4[Objects.Count];
        for (int k = 0; k < instances.Length; k++)
            instances[k] = Matrix4x4.Translate(Objects[k].position);
        Graphics.DrawMeshInstanced(Mesh, 0, Material, instances);
    }
}
   