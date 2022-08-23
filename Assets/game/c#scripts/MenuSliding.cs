using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSliding : MonoBehaviour
{

    bool isShow = false;
    
    
    public void ShowingButton()
    {
        if(isShow)
        {
            DontShowButton();
            isShow = false;
        }
        else
        {
            ShowButton();
            isShow = true;
        }
    }
    private void ShowButton()
    {
        transform.LeanMoveLocal(new Vector2(-1200, 0), 0.5f);
    }
    private void DontShowButton()
    {
        transform.LeanMoveLocal(new Vector2(-2200, 0), 0.5f);
    }
    
}
