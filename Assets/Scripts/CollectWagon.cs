using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectWagon : MonoBehaviour {

    private ScoreManager scoreHandler;

	// Use this for initialization
	void Start () {
        scoreHandler = FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("collectRock"))
        {
            scoreHandler.GiveStone();
        }  
    }
}

   
    