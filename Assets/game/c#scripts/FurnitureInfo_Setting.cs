using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureInfo_Setting : MonoBehaviour
{
    [SerializeField]
    private Furniture_data [] furniture;
    // Start is called before the first frame update

    
    public void Showif(string frunitureName)
    {
        for(int i = 0; i < furniture.Length; i++)
        {
            if(frunitureName == furniture[i].furnitureModel.name)
            {
                FindObjectOfType<ShowMenuInfo>().SetUp(furniture[i], frunitureName);            
                break;
            }
        }
    }
    public void DontShow()
    {
        for(int i = 0; i < furniture.Length; i++)
        {
            Debug.Log(i);
            FindObjectOfType<ShowMenuInfo>().ReSet(furniture[i]);
        }
    }
}
