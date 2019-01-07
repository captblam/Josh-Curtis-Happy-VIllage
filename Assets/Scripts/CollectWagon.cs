using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectWagon : MonoBehaviour {

    private ScoreManager scoreHandler;
    private int RockNum = 0;
    [SerializeField]private List<GameObject> Rocks = new List<GameObject>();

	// Use this for initialization
	void Start () {
        scoreHandler = FindObjectOfType<ScoreManager>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("collectRock"))
        {
            scoreHandler.GiveStone();
            Destroy(other.gameObject);
            RockNum++;
            
        }  
    }
    void Rck()
    {
        if (RockNum >= 3)
        {

        }
        else if (RockNum >= 5)
        {

        }
        else if (RockNum >= 7)
        {

        }
        else if (RockNum >= 10)
        {

        }
        else
        {

        }
    }
}

   
    