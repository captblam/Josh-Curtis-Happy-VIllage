using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoeScript : MonoBehaviour {
    public GameObject Hoe;
    bool KeyHit = false;
    private ScoreManager scMan;
    private void Start()
    {
        scMan = GetComponent<ScoreManager>();
        
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("Attack"))
        {
            KeyHit = true;
        }
        if (Input.GetKeyUp("Attack"))
        {
            KeyHit = false;
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Plant") && KeyHit == true)
        {
            scMan.GiveCrop();
        }
    }
}
