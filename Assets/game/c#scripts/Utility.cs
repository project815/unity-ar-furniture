using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Utility : MonoBehaviour
{
    private static ARRaycastManager raycastmanager;
    private static List<ARRaycastHit> hits = new List <ARRaycastHit>();

    static Utility()
    {
        raycastmanager = GameObject.FindObjectOfType<ARRaycastManager>();
    }
    public static bool Raycast(Vector2 screenPosition, out Pose pose) {
        
        if(raycastmanager.Raycast(screenPosition, hits, TrackableType.AllTypes))
        {
            pose = hits[0].pose;
            return true;
        }
        else{
            pose = Pose.identity;
            return false;
        }
    }
    public static bool TryGetInputPosition(out Vector2 Position)
    {
        Position = Vector2.zero;
        if(Input.touchCount == 0)
        {
            return false;
        }
        Position = Input.GetTouch(0).position;

        if(Input.GetTouch(0).phase != TouchPhase.Began)
        {
            return false;
        }
        else return true;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
