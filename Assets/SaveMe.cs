using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveMe : MonoBehaviour
{
    protected Save SaveState;
    public int SaveType;
    // Start is called before the first frame update
    void Start()
    {
        SaveState = GetComponentInParent<Save>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            SaveState.PushToSaveState(SaveType, transform);
    }
}
