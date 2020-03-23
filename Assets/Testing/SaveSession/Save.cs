using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.IO.File;
using System.IO;

public class Save : MonoBehaviour
{
    public string SavePath;
    protected Dictionary<int, SaveData> SaveDataDict = new Dictionary<int, SaveData>();
    private int idCount = 0;
    public KeyCode SaveKey;

    public int PushToSaveState(int saveItemId, Transform transform)
    {
        SaveDataDict[++idCount] = new SaveData(saveItemId, transform.position, transform.rotation);
        return idCount;
    }
    public void ChangeSaveState(int id, int saveItemId, Transform transform)
    {
        SaveDataDict[id] = new SaveData(saveItemId, transform.position, transform.rotation);
    }

    public void SaveGame()
    {
        string saveData = "";
        foreach (SaveData sd in SaveDataDict.Values)
        {
            saveData += sd.Id + "," + sd.Position.x + "," + sd.Position.y + "," + sd.Position.z
                + "," + sd.Rotation.x + "," + sd.Rotation.y + "," + sd.Rotation.z + "," + sd.Rotation.w + "\n";
        }
        WriteAllText(SavePath, saveData);
    }

    private void Update()
    {
        if(Input.GetKeyDown(SaveKey)) SaveGame();
    }
}

public struct SaveData
{
    public int Id;
    public Vector3 Position;
    public Quaternion Rotation;
    public SaveData(int id, Vector3 pos, Quaternion rot)
    {
        Id = id;
        Position = pos;
        Rotation = rot;
    }
}
