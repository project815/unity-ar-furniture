using System;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuInfoScaleUp : MonoBehaviour
{

    private 
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
        FindObjectOfType<FurnitureInfo_Setting>().DontShow();
    }
    #region tlf
    [SerializeField]
    private TextMeshProUGUI text_tittle;
    private string str_furniuture_tittle;
    
    public void SetUp(Furniture_data furniture)
    {
        str_furniuture_tittle = furniture.tittle;
        text_tittle.text = str_furniuture_tittle;

        furniture.furnitureModel.gameObject.SetActive(true);
        furniture.button_AR.gameObject.SetActive(true);
    }
    public void ReSet(Furniture_data furniture)
    {
        text_tittle.text = " ";

        furniture.furnitureModel.gameObject.SetActive(false);
        furniture.button_AR.gameObject.SetActive(false);
    }
  
    #endregion
}   
