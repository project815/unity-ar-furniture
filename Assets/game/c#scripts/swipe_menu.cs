using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class swipe_menu : MonoBehaviour
{
    public GameObject scorllbar;
    float scorll_pos = 0;
    float []pos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = new float [transform.childCount];
        float distance = 1f/(pos.Length - 1f);
        for(int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }
        if(Input.GetMouseButton(0))
        {
            scorll_pos = scorllbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for(int i = 0; i < pos.Length; i++)
            {
                if(scorll_pos < pos[i] + (distance / 2) && scorll_pos > pos[i] - (distance / 2))
                {
                    scorllbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scorllbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }

        for (int i = 0; i < pos.Length; i++)
        {
            if (scorll_pos < pos[i] + (distance / 2) && scorll_pos > pos[i] - (distance / 2))
            {
                transform.GetChild (i).localScale = Vector3.Lerp(transform.GetChild(i).localScale, new Vector2(1f, 1f), 0.1f);
                for(int a = 0;a < pos.Length; a++)
                {
                    if(a != i)
                    {
                        transform.GetChild(a).localScale = Vector3.Lerp(transform.GetChild(a).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                    }
                }
            }
        }
    }

}
