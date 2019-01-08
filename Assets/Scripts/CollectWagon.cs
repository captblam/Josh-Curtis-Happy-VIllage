﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectWagon : MonoBehaviour {

    [SerializeField]private ScoreManager scoreHandler;
    [SerializeField]private int RockNum = 0;
    [SerializeField]private List<GameObject> Rocks = new List<GameObject>();

	// Use this for initialization
	void Start () {
        scoreHandler = GameObject.FindObjectOfType<ScoreManager>();
        Rck();
    }
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("collectRock"))
        {

            if(RockNum < Rocks.Count)
            {
                RockNum++;
                scoreHandler.GiveStone();
            }
            
            Rck();
            Destroy(other.gameObject);
        }  
    }
    void Rck()
    {
        switch (RockNum)
        {
            case 1:
                Rocks[0].SetActive(true);
                break;
            case 2:
                Rocks[1].SetActive(true);
                break;
            case 3:
                Rocks[2].SetActive(true);
                break;
            case 4:
                Rocks[3].SetActive(true);
                break;
            default:
                foreach  (GameObject pile in Rocks)
                {
                    pile.SetActive(false);
                }
                break;
        }
    }
}

   
    