using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlacedObject : MonoBehaviour
{
    [SerializeField]
    private GameObject cubeSelected;

    public bool InSelected // when object select , active - property
    {
        get => SelectedObject == this;
    }
    private static PlacedObject selectedObject;

    public static PlacedObject SelectedObject //property
    {
        get =>selectedObject;
        set
        {
            if(selectedObject == value)
            {
                return;
            }
            if(selectedObject != null)
            {
                selectedObject.cubeSelected.SetActive(false);
            }

            selectedObject = value;
            if(value != null)
            {
                value.cubeSelected.SetActive(true);
            }
        }
    }
    
    private void Awake() {
        cubeSelected.SetActive(false);
    }


    void Update()
    {
        if(InSelected)
        {
            if (Input.touchCount == 2)
            {
                ScaleControler();

            }
            else if(Input.touchCount == 1)
            {
                RotateControler();
            }
        }

    }
    float initialDistance;
    Vector3 initialScale;

    private void ScaleControler()
    {
        var touchZero = Input.GetTouch(0); 
        var touchOne = Input.GetTouch(1);

        // if one of the touches Ended or Canceled do nothing
        if(touchZero.phase == TouchPhase.Ended || touchZero.phase == TouchPhase.Canceled  
        || touchOne.phase == TouchPhase.Ended || touchOne.phase == TouchPhase.Canceled) 
        {
            return;
        }

        // It is enough to check whether one of them began since we
        // already excluded the Ended and Canceled phase in the line before
        if(touchZero.phase == TouchPhase.Began || touchOne.phase == TouchPhase.Began)
        {
            // track the initial values
            initialDistance = Vector2.Distance(touchZero.position, touchOne.position);
            initialScale = selectedObject.transform.localScale;
        }
        // else now is any other case where touchZero and/or touchOne are in one of the states
        // of Stationary or Moved
        else
        {
            // otherwise get the current distance
            var currentDistance = Vector2.Distance(touchZero.position, touchOne.position);

            // A little emergency brake ;)
            if(Mathf.Approximately(initialDistance, 0)) return;

            // get the scale factor of the current distance relative to the inital one
            var factor = currentDistance / initialDistance;

            // apply the scale
            // instead of a continuous addition rather always base the 
            // calculation on the initial and current value only
            selectedObject.transform.localScale = initialScale * factor;
        }
    }


    [SerializeField] private float rotationRate = 3.0f;
    private bool m_rotating = false;
    private float m_previousX;
    private float m_previousY;

    private void RotateControler()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_rotating = true;
            m_previousX = Input.mousePosition.x;
            m_previousY = Input.mousePosition.y;
        }   
        if(Input.GetMouseButton(0)) 
        {
            var touch = Input.mousePosition;

            var deltaY = -(Input.mousePosition.x - m_previousX) * rotationRate;

            selectedObject.transform.Rotate (0, deltaY, 0, Space.Self);
            
            m_previousX = Input.mousePosition.x;
            m_previousY = Input.mousePosition.y;
        }
        if (Input.GetMouseButtonUp(0))
            m_rotating = false;

    }



}
