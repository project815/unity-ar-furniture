using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInOut : MonoBehaviour
{
    Camera subCamera;
    public float zoomView;
    private void Start()
    {
        subCamera = GetComponent<Camera>();
    }
    void Update()
    {
        subCamera.fieldOfView = zoomView;
    }
    public void CameraZoomInOut(float zoom)
    {
        zoomView = zoom;
    }
    // Update is called once per frame

}
