using System.Collections.Generic;
using System.Runtime.InteropServices;
using GoogleARCore;
using UnityEngine;
using UnityEngine.UI;
using GoogleARCore.Examples.AugmentedImage;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using Testscenes.AugmentedImage;

public class ARNetworkJoinController : ARController
{
    public string scene;

    public override void ShowObject(AugmentedImage image, out ARVisualizer visualizer)
    {
        visualizer = null;
        SceneManager.LoadScene(scene);
    }
}
