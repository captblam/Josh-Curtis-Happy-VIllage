using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoeScript : MonoBehaviour {
    public GameObject Hoe;
    bool keyHit = false;
    float currLerpTime = 0, LerpTime = 5, perc;
   public Vector3 currentPos, endPos, position;
    private void Start()
    {
        position = transform.position;
        currentPos = transform.position;
    }
    // Update is called once per frame
    void Update () {
        currentPos = transform.position;
        if (Input.GetKeyDown("Attack"))
        {
            keyHit = true;
        }
        if (Input.GetKeyUp("Attack"))
        {
            keyHit = false;
        }
        if (keyHit == true)
        {
            currLerpTime += (15 * Time.deltaTime);
            if (currLerpTime >= LerpTime)
            {
                currLerpTime = LerpTime;
            }
            perc = currLerpTime / LerpTime;
            Hoe.transform.position = Vector3.Lerp(currentPos, endPos, perc);
        }
    }
}
