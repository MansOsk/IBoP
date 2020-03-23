using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
using GoogleARCore;
using GoogleARCoreInternal;

public class LoadScene : MonoBehaviour
{
    public GameObject TicTacToe;
    //private Vector3 Cube1 = new Vector3(0,1.8f,-10);
  
    private GameObject Object;

    public void loadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    
}
