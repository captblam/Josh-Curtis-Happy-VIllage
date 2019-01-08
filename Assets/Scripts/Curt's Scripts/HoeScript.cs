using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoeScript : MonoBehaviour {
    
    bool KeyHit;
    private ScoreManager scMan;
    private PlantGrowth grow;
    private void Start()
    {
        scMan = FindObjectOfType<ScoreManager>();
  
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("Attack"))
        {
            KeyHit = true;
            //Debug.Log("pressed");
        }
        if (Input.GetButtonUp("Attack"))
        {
            KeyHit = false;
            Debug.Log("Attacked");
        }
    }
    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Plant") && KeyHit == true)
        {
            grow = col.gameObject.GetComponent<PlantGrowth>();
            scMan.GiveCrop();
            grow.ResetSize();
        }
    }

    //private void OnTriggerEnter(Collider col)
    //{
       
    //}
}
