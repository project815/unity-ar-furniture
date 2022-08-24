using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MenulistClick : MonoBehaviour
{

    public Transform[] transforms;
    bool isOpen = false;

    public void SettingPostion()
    {
        if(!isOpen)
        {
            SetPosition();
            isOpen = true;
        }
        else
        {
            ResetPosition();
            isOpen = false;
        }
    }
    private void SetPosition()
    {
        for(int i = 0; i < transforms.Length; i++)
        {
            transforms[i].gameObject.SetActive(true);
        }
    }
    private void ResetPosition()
    {
        for(int i = 0; i < transforms.Length; i++)
        {
            transforms[i].gameObject.SetActive(false);
        }
    }
    
}
