using System.Collections.Generic;
using System.Runtime.InteropServices;
using GoogleARCore;
using UnityEngine;
using UnityEngine.UI;
using GoogleARCore.Examples.AugmentedImage;
using UnityEngine.Networking;

/// <summary>
/// Controller for AugmentedImage example.
/// </summary>
/// <remarks>
/// In this sample, we assume all images are static or moving slowly with
/// a large occupation of the screen. If the target is actively moving,
/// we recommend to check <see cref="AugmentedImage.TrackingMethod"/> and
/// render only when the tracking method equals to
/// <see cref="AugmentedImageTrackingMethod"/>.<c>FullTracking</c>.
/// See details in <a href="https://developers.google.com/ar/develop/c/augmented-images/">
/// Recognize and Augment Images</a>
/// </remarks>
public class ARNetworkController : ARController
{
    /// <summary>
    /// The Unity Awake() method.
    /// </summary>
    public void Awake()
    {
        // Enable ARCore to target 60fps camera capture frame rate on supported devices.
        // Note, Application.targetFrameRate is ignored when QualitySettings.vSyncCount != 0.
        Application.targetFrameRate = 60;
    }

    /// <summary>
    /// The Unity Update method.
    /// </summary>
    public override void Update()
    {
        base.Update();
    }

    public override bool ShowObject(AugmentedImage image, ARVisualizer visualizer)
    {
        if (NetworkServer.active)
        {
            if (base.ShowObject(image, visualizer))
            {
                NetworkServer.SpawnWithClientAuthority(visualizer.gameObject, NetworkManager.singleton.client.connection);
                return true;
            }
        }
        return false;
    }


}
