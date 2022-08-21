using System;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuInfoScaleUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector2.zero;
     
    }
    public void Open()
    {
        transform.LeanScale(Vector2.one, 0.4f);
    }
    public void Close()
    {
        transform.LeanScale(Vector2.zero, 0.4f).setEaseInBack();
    }

}
