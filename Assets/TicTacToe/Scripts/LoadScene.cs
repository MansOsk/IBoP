using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
using GoogleARCore;
using GoogleARCoreInternal;
using Testscenes.AugmentedImage;

public class LoadScene : MonoBehaviour
{
    public GameObject TicTacToe;
    //private Vector3 Cube1 = new Vector3(0,1.8f,-10);
  

    private GameObject Object;

    public void loadGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void loadMenu() 
    {
        SceneManager.LoadScene("Menu");

    }
    public void reload()
    {
        //SceneManager.LoadScene("SampleScene");
        ARController arc = GameObject.Find("ARController").GetComponent<ARController>();
        arc.FitToScanOverlay.SetActive(false);
        arc.AugmentedImageVisualizerPrefab.Object.SetActive(true);
        //Destroy(GameObject.Find("ARController").GetComponent<ARController>().AugmentedImageVisualizerPrefab.Object);
        //TicTacToe.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f); //starting size of the grid
        //TicTacToe.transform.localRotation = Quaternion.Euler(0, 0, 0);
        //Instantiate(TicTacToe, new Vector3(0, 0, 0), Quaternion.identity);

        //Object = GameObject.Find("ARController").GetComponent<ARController>().AugmentedImageVisualizerPrefab.Object;


        ////Object.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f); //starting size of the grid
        ////Object.transform.localRotation = Quaternion.Euler(0, 0, 0);
        //Instantiate(Object, new Vector3(0, 0, 0), Quaternion.identity);

    }
}
