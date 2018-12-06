using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingSpear : MonoBehaviour {

    public GameObject Spear;
    public Vector3 currentPos;
    public Vector3 endPos;
    public Vector3 goBack;

    public float distance = 30f;

    public float LerpTime = 5;
    public float currLerpTime = 0;
    public float perc;

    public bool keyHit = false;
    public GameObject spearSpawn;
    public GameObject player;

  
    // Update is called once per frame
    void Update () {

        goBack = spearSpawn.transform.position;
        if (keyHit == false)
        {
            transform.position = goBack;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            transform.Rotate(120, 0, 0);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            transform.Rotate(-120, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.F) && gameManager.instance.getControlled() == gameObject)
        {
            keyHit = true;
            player.GetComponent<RPGCharacterController>().canWalk = false;
            currentPos = Spear.transform.position;
            endPos = Spear.transform.position + Vector3.forward * distance;
            goBack = Spear.transform.position + Vector3.forward / distance;
            player.GetComponent<RPGCharacterController>().runSpeed = 0;
            player.GetComponent<RPGCharacterController>().walkSpeed = 0;
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            //transform.position = spearSpawn.transform.position;
            keyHit = false;
            player.GetComponent<RPGCharacterController>().canWalk = true;
            player.GetComponent<RPGCharacterController>().runSpeed = 15;
            player.GetComponent<RPGCharacterController>().walkSpeed = 3;
            LerpTime = 5;
            currLerpTime = 0;

        }

        if (keyHit == true)
        {
            currLerpTime += (15*Time.deltaTime);
            if (currLerpTime >= LerpTime)
            {
                currLerpTime = LerpTime;
            }
            perc = currLerpTime / LerpTime;
            Spear.transform.position = Vector3.Lerp(currentPos, endPos, perc);
        }
        
    }

}
