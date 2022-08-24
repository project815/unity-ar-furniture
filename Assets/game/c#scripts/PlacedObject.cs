using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedObject : MonoBehaviour
{
    [SerializeField]
    private GameObject cubeSelected;

    public bool InSelected
    {
        get => SelectedObject == this;
    }
    private static PlacedObject selectedObject;
    public static PlacedObject SelectedObject
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
}
