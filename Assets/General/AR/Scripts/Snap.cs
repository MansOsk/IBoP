using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ska sitta på pjäser som ska snapppaapappapap
public class Snap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }
    // Saker som behövs för snap
    public SnapObjectList SnapObjectList;
    public bool SnapTo = true;
    public float size = 0.6666666666666667f;
    public float snapSpeed = 16f, offset = 0;
    const int s = 1;
    // Update is called once per frame
    public int X, Y, Z;
    void Update()
    {
        // Snap
        if (Input.touchCount <= 0)
        {
            int x = (int)Mathf.Round((transform.localPosition.x - offset) / size);
            int y = (int)Mathf.Round((transform.localPosition.y - offset) / size);
            int z = (int)Mathf.Round((transform.localPosition.z - offset) / size); // Hittar vart vi ska snapa
            bool setNewSnap = x < SnapObjectList.XMax && x > SnapObjectList.XMin && y < SnapObjectList.YMax && y > SnapObjectList.YMin && z < SnapObjectList.ZMax && z > SnapObjectList.ZMin;
            foreach (Snap snap in SnapObjectList.Snaps)
            {
                if (snap.X == x && snap.Z == z && snap.gameObject != gameObject)
                    setNewSnap = false;
            }
            if (setNewSnap)
            {
                X = x;
                Y = y;
                Z = z;
            }
            Vector3 vec = new Vector3(X * size + offset, Y * size + offset, Z * size + offset);
            vec -= transform.localPosition;
            vec /= snapSpeed; // Snap fart

            Vector3 trans = new Vector3( // skalar från local till world
                vec.x * transform.localScale.x,
                vec.y * transform.localScale.y,
                vec.z * transform.localScale.z);
            gameObject.transform.Translate(trans); // Flyttar till mitten av rutan
        }
        // Snap end
    }
}
