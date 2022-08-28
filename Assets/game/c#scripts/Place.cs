using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;

public class Place : MonoBehaviour
{

    public TextMeshProUGUI text_ModeName;
    public TextMeshProUGUI text_GuideMessage;
    public List<GameObject> prefab = new List<GameObject>();
    public ARRaycastManager manager;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();
    public Transform indicator;

    Vector2 vCenter;
    public Transform pool;

    Vector2 touchPosition;
    GameObject select;


    [SerializeField]
    private Camera arCamera;
    [SerializeField]
    private LayerMask placeObjectLayMask;
    private Ray ray_touchPosition;
    private RaycastHit hit;
    
    public bool isSelectionMode = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        manager.Raycast(new Vector2(Screen.width * 0.5f, Screen.height * 0.5f), hits, TrackableType.AllTypes);


        if(select != null)
        {
            text_GuideMessage.text = "선택된 가구가 존재합니다.";

            if (hits.Count > 0)
            {

                select.transform.position = hits[0].pose.position;
            }
            else
            {
                text_GuideMessage.text = "감지되지 않은 영역입니다. 다시 인식시켜주세요.";
                return;
            }
        }
        else if(select == null && cnt == 0)
        {
            text_GuideMessage.text = "선택된 가구가 없습니다.\n가구배치를 원한다면 왼쪽 메뉴바를 이용해주세요.";
        }
        else if(select == null && 0 < cnt)
        {
            text_GuideMessage.text = "배치완료";
        }
        
        if(!Utility.TryGetInputPosition(out touchPosition)) return;

            ray_touchPosition = arCamera.ScreenPointToRay(touchPosition);

        if(Physics.Raycast(ray_touchPosition, out hit, Mathf.Infinity, placeObjectLayMask))
        {
            PlacedObject.SelectedObject = hit.transform.GetComponentInChildren<PlacedObject>();
            select = PlacedObject.SelectedObject.gameObject;
            return;
        } 
        else 
        {
            PlacedObject.SelectedObject = null;        
        }
        



        if(hits.Count > 0)
        {
            indicator.position = hits[0].pose.position;
            indicator.rotation = hits[0].pose.rotation;
        }

    }

    public void Select(string name)
    {
        if(select != null)
        {
            Destroy(select);

            select = null;
        } // 뭔가 있으면 지우고 시작.
        for(int i =0; i < prefab.Count; i++)
        {
            if(name == prefab[i].name)
            {
                select = Instantiate(prefab[i]);
                break;
            }
        }
    }

    public GameObject notselectedMessage;
    int cnt;
    public void Set() //place
    {
        if(select == null)
        {
            notselectedMessage.SetActive(true);
        }
        else
        {
            select.transform.SetParent(pool); //부모 자식 관계 부모를 링크함.
            select.transform.position = hits[0].pose.position;
            cnt++;
            //pool
            //select는 널이 된다. 
            select = null;
        }
        // if(isSelectionMode && PlacedObject.SelectedObject != null)
        // {
        //     PlacedObject.SelectedObject.transform.position = hits[0].pose.position;
        // }
    }

}
