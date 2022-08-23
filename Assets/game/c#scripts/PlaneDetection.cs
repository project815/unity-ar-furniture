using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
public class PlaneDetection : MonoBehaviour
{
    public ARPlaneManager arPlane;

    public void ShowPlane(bool isShow)
    {
        foreach(var plane in arPlane.trackables)
        {
            plane.gameObject.SetActive(isShow);
        }
    }
}
