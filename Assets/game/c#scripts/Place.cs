using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Place : MonoBehaviour
{

    public GameObject instantiateModeObject;
    public List<GameObject> prefab = new List<GameObject>();
    public ARRaycastManager manager;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();
    public Transform indicator;


    public Transform pool;

    Vector2 touchPosition;
    GameObject select;


    [SerializeField]
    private Camera arCamera;
    [SerializeField]
    private LayerMask placeObjectLayMask;
    private Ray ray_touchPosition;
    private RaycastHit hit;
    
    bool isSelectionMode = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        manager.Raycast(new Vector2(Screen.width * 0.5f, Screen.height * 0.5f), hits, TrackableType.Planes);
        //instatiate mode
        if(!isSelectionMode)
        {
            Debug.Log("instance");
            if (hits.Count > 0)
            {
                select.transform.position = hits[0].pose.position;
                
                select.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);                    
            }
            else
            {
                if(select != null)
                select.transform.localScale = new Vector3(0, 0, 0);
            }
        }
        //selection mode
        else
        {
            Debug.Log("selection");

            if(!Utility.TryGetInputPosition(out touchPosition)) return;

            ray_touchPosition = arCamera.ScreenPointToRay(touchPosition);
            if(Physics.Raycast(ray_touchPosition, out hit, Mathf.Infinity, placeObjectLayMask))
            {
                PlacedObject.SelectedObject = hit.transform.GetComponentInChildren<PlacedObject>();
                return;
            } 
            else PlacedObject.SelectedObject = null;           
        }

        //indicator 
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
                select.transform.Translate(new Vector3(0, 0.1f, 0));                
                break;
            }
        }
    }
    public void Set() //place
    {
        select.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        
        select.transform.Translate(new Vector3(0, 0, 0));
        select.transform.SetParent(pool); //부모 자식 관계 부모를 링크함.
        //pool
        //select는 널이 된다. 
        select = null;
    }
    public void SelectionModeChange()
    {
        if(isSelectionMode)
        {
            instantiateModeObject.SetActive(true);
            isSelectionMode = false;
        } 
        else 
        {
            instantiateModeObject.SetActive(false);
            isSelectionMode = true;
        }

    }
}
