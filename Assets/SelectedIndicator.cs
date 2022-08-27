using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedIndicator : MonoBehaviour
{

   
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
    }
}
