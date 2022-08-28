using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputField : MonoBehaviour
{
    public Button btnClick;


    public TMP_InputField input_furniturename;
    // Start is called before the first frame update
    void Start()
    {
        btnClick.onClick.AddListener(GetInputClickHanadler);
    }


    public GameObject UImanager;
    public GameObject Categary;
    public GameObject GameDialog;
    public GameObject Fail_Search;

    string input;


    public void GetInputClickHanadler()
    {
        switch(input_furniturename.text)
        {
            case "휴지통":
                input = "PFB_Basket";
            break;
            case "탁자1":
                input = "PFB_BedsideTable";
            break;  
            case "탁자2":
                input = "PFB_CoffeeTable";
            break;
            case "TV거치대":
                input = "PFB_TVStand";
            break;
            case "TV":
                input = "PFB_TV";
            break;
            case "소파":
                input = "PFB_Sofa";
            break;
            case "작은 소파":
                input = "PFB_SofaSmall";
            break;
            case "침대":
                input = "PFB_Bed";
            break;
            case "침실소파":
                input = "PFB_BedroomSofa";
            break;
            case "서랍장":
                input = "PFB_ChestOfDraws";
            break;
            case "옷장":
                input = "PFB_Closet";
            break;
            case "커튼":
                input = "PFB_Curtain";
            break;
            case "작은 커튼":
                input = "PFB_CurtainSmall";
            break;
            case "거울":
                input = "PFB_FreestandMirror";
            break;
            case "의자":
                input = "PFB_DiningChair";
            break;
            case "식탁":
                input = "PFB_DiningTable";
            break;
            case "냉장고":
                input = "PFB_Fridge";
            break;
            case "싱크대":
                input = "PFB_KitchenBench";
            break;
            case "가스레인지":
                input = "PFB_Stove";
            break;
            default:
            input = "Not";
            break;
        }
        if(input != "Not")
        {    
            UImanager.GetComponent<FurnitureInfo_Setting>().Showif(input);
            GameDialog.gameObject.SetActive(true);
            Categary.GetComponent<MenuSliding>().DontShowButton();    
        }
        else
        {
            Fail_Search.SetActive(true);
        }
    }
}
