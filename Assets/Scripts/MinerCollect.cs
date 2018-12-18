using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerCollect : MonoBehaviour {

    private ScoreManager scoreHandler;
    private collectableSpawn collect;

    private void Start()
    {
       
        collect = FindObjectOfType<collectableSpawn>();
    }

    private void OnTriggerEnter(Collider other)
    { 
        if (other.gameObject.CompareTag("Rock"))
        {  
           collect.spawnRock();
        }  
    }
}
