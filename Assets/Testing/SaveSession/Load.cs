using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.IO.File;

public class Load : MonoBehaviour
{
    public GameObject[] LoadPrefabs;
    public string LoadPath;
    public bool LoadOnStart;
    public KeyCode LoadKey;

    // Start is called before the first frame update
    void Start()
    {
        if (LoadOnStart)
            LoadGameState();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(LoadKey))
            LoadGameState();
    }

    public void LoadGameState()
    {
        string[] lines = ReadAllLines(LoadPath);
        for (int k = 0; k < lines.Length; k++)
        {
            string[] data = lines[k].Split(',');
            int type;
            Vector3 pos;
            Quaternion rot;
            if (!(int.TryParse(data[0], out type) && float.TryParse(data[1], out pos.x) && float.TryParse(data[2], out pos.y) &&
                float.TryParse(data[3], out pos.z) && float.TryParse(data[4], out rot.x) && float.TryParse(data[5], out rot.y) &&
                float.TryParse(data[6], out rot.z) && float.TryParse(data[7], out rot.w)))
            {
                Debug.Log("Failed to load object at line " + k + ".\n");
            }
            else
            {
                GameObject go = Instantiate(LoadPrefabs[type], pos, rot);
                go.SetActive(true);
            }
        }
    }
}
