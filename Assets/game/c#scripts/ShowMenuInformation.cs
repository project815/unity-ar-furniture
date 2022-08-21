using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ShowMenuInformation : MonoBehaviour
{

    private enum FurinitueModelName
    {
        BASKET, BESIDETABLE, COFFETABLE, TVSTAND, TV, SOFA, SOFASMALL, //livingroom
        BED, BEDROOMSOFA, CHEST, CLOSET, CURTAIN, CURTAINSMALL, MIRROR, //bedroom
        DININGCHAIR, DININGTABLE, FRIDGE, KITCHENBENCH, STOVE, //kitchen
        DEFAULT, // back
    };
    [SerializeReference] private FurinitueModelName MODELNAME;


    public TextMeshProUGUI meunTittle;
    public GameObject[] furnitureModel;
    public Button[] ShowAR;

    string Key;


    public void ShowInformation(ShowMenuInformation currentState)
    {
        MenuTittle(currentState);
        ShowModel();
        ShowARButton();
    }
    public void ReSetRotation() 
    {
        for (int i = 0; i < furnitureModel.Length; i++)
        {
            furnitureModel[i].SetActive(false);
            furnitureModel[i].gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        for (int i = 0; i < ShowAR.Length; i++)
        {
            ShowAR[i].gameObject.SetActive(false);
        }
    }

    private void MenuTittle(ShowMenuInformation currentState)
    {
        switch (currentState.MODELNAME)
        {
            case FurinitueModelName.BASKET:
                meunTittle.text = "- 휴지통 -";
                Key = "PFB_Basket";
                break;
            case FurinitueModelName.BESIDETABLE:
                meunTittle.text = "- 탁자1 -";
                Key = "PFB_BedsideTable";
                break;
            case FurinitueModelName.COFFETABLE:
                meunTittle.text = "- 탁자2 -";
                Key = "PFB_CoffeeTable";
                break;
            case FurinitueModelName.TVSTAND:
                meunTittle.text = "- TV거치대 -";
                Key = "PFB_TVStand";
                break;
            case FurinitueModelName.TV:
                meunTittle.text = "- TV -";
                Key = "PFB_TV";
                break;
            case FurinitueModelName.SOFA:
                meunTittle.text = "- 소파 -";
                Key = "PFB_Sofa";
                break;
            case FurinitueModelName.SOFASMALL:
                meunTittle.text = "- 작은 소파 -";
                Key = "PFB_SofaSmall";
                break;
            case FurinitueModelName.BED:
                meunTittle.text = "- 침대 -";
                Key = "PFB_Bed";
                break;
            case FurinitueModelName.BEDROOMSOFA:
                meunTittle.text = "- 침실소파 -";
                Key = "PFB_BedroomSofa";
                break;
            case FurinitueModelName.CHEST:
                meunTittle.text = "- 서랍장 -";
                Key = "PFB_ChestOfDraws";
                break;
            case FurinitueModelName.CLOSET:
                meunTittle.text = "- 옷장 -";
                Key = "PFB_Closet";
                break;
            case FurinitueModelName.CURTAIN:
                meunTittle.text = "- 커튼 -";
                Key = "PFB_Curtain";
                break;
            case FurinitueModelName.CURTAINSMALL:
                meunTittle.text = "- 작은 커튼 -";
                Key = "PFB_CurtainSmall";
                break;
            case FurinitueModelName.MIRROR:
                meunTittle.text = "- 거울 -";
                Key = "PFB_FreestandMirror";
                break;
            case FurinitueModelName.DININGCHAIR:
                meunTittle.text = "- 의자 -";
                Key = "PFB_DiningChair";
                break;
            case FurinitueModelName.DININGTABLE:
                meunTittle.text = "- 식탁 -";
                Key = "PFB_DiningTable";
                break;
            case FurinitueModelName.FRIDGE:
                meunTittle.text = "- 냉장고 -";
                Key = "PFB_Fridge";
                break;
            case FurinitueModelName.KITCHENBENCH:
                meunTittle.text = "- 싱크대 -";
                Key = "PFB_KitchenBench";
                break;
            case FurinitueModelName.STOVE:
                meunTittle.text = "- 가스레인지 -";
                Key = "PFB_Stove";
                break;
        }

    }
    private void ShowModel()
    {
        for (int i = 0; i < furnitureModel.Length; i++)
        {
            if (Key == furnitureModel[i].name)
            {
                furnitureModel[i].SetActive(true);
            }
            else
            {
                furnitureModel[i].SetActive(false);
            }
        }
    }
    private void ShowARButton()
    {
        for (int i = 0; i < ShowAR.Length; i++)
        {
            if ("Button_" + Key == ShowAR[i].name)
            {
                ShowAR[i].gameObject.SetActive(true);
            }
            else
            {
                ShowAR[i].gameObject.SetActive(false);
            }
        }
    }
}
