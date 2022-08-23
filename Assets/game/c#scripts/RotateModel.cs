using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateModel : MonoBehaviour
{
    private void Awake() {
        transform.LeanMoveLocal(new Vector2(0, 0.6f), 1).setEaseInOutSine().setLoopPingPong();

    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 10f * Time.deltaTime, 0f, Space.Self); 
    }

    public void Rotate(float num)
    {
        transform.eulerAngles = new Vector3(0, num, 0);
    }
}
