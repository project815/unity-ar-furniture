using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSliding : MonoBehaviour
{
    public void ShowButton()
    {
        transform.LeanMoveLocal(new Vector2(-1200, 0), 0.5f);
    }
    public void DontShowButton()
    {
        transform.LeanMoveLocal(new Vector2(-2200, 0), 0.5f);
    }
    
}
