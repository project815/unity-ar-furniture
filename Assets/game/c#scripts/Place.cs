using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Place : MonoBehaviour
{

    public List<GameObject> prefab = new List<GameObject>();
    public ARRaycastManager manager;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();


    public Transform pool;

    Vector2 vCenter;
    GameObject select;


    // Start is called before the first frame update
    void Start()
    {
        
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
                select.AddComponent<RotateModel>();
                select.GetComponent<RotateModel>().enabled = true;
                
                break;
            }
        }
    }
    public void Set() //place
    {
        select.GetComponent<RotateModel>().enabled = false;
        select.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        
        select.transform.Translate(new Vector3(0, 0, 0));
        select.transform.SetParent(pool); //부모 자식 관계 부모를 링크함.
        //pool
        //select는 널이 된다. 
        select = null;
    }
    // Update is called once per frame
    void Update()
    {
        if(select != null)
        {
            vCenter = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);

            if (manager.Raycast(vCenter, hits, TrackableType.PlaneWithinPolygon))
            {   
                ARPlane plane = hits[0].trackable.GetComponent<ARPlane>();
                if (plane != null)
                {
                    select.transform.position = hits[0].pose.position;
                    select.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);                    
                }
                else
                {
                    select.transform.localScale = new Vector3(0, 0, 0);
                }
            }
   
        }
    }
}
