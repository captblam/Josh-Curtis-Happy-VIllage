using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerCollect : MonoBehaviour {

    private ScoreManager scoreHandler;

    private void Start()
    {
        scoreHandler = FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter(Collider other)
    { 
        if (other.gameObject.CompareTag("Rock"))
        {  
           scoreHandler.GiveStone();
        }  
    }
}
