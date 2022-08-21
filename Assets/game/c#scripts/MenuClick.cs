using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MenuClick : MonoBehaviour
{

    public Transform[] transforms;
    
    public void SetPosition()
    {
        for(int i = 0; i < transforms.Length; i++)
        {
            transforms[i].gameObject.SetActive(true);
        }
    }
    public void ResetPosition()
    {
        for(int i = 0; i < transforms.Length; i++)
        {
            transforms[i].gameObject.SetActive(false);
        }
    }
    
}
