using System;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowMenuInfo : MonoBehaviour
{
    public GameObject place;
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

    public void EX(GameObject asd)
    {
        asd.SetActive(true);
    }


    #region tlf
    [SerializeField]
    private TextMeshProUGUI text_tittle;
    private string str_furniuture_tittle;
    [SerializeField]
    private Button Button_ARlocate;
    public void SetUp(Furniture_data furniture, string ModelName)
    {
        str_furniuture_tittle = furniture.tittle;
        text_tittle.text = str_furniuture_tittle;

        furniture.furnitureModel.gameObject.SetActive(true);

        Button_ARlocate.onClick.AddListener(FindObjectOfType<ShowMenuInfo>().Close);
        Button_ARlocate.onClick.AddListener(() => FindObjectOfType<PlaneDetection>().ShowPlane(true));
        Button_ARlocate.onClick.AddListener(() => place.GetComponent<Place>().Select(ModelName));
    }
    public void ReSet(Furniture_data furniture)
    {
        text_tittle.text = " ";

        furniture.furnitureModel.gameObject.SetActive(false);
        
        Button_ARlocate.onClick.RemoveAllListeners();
    }
  
    #endregion
}   
