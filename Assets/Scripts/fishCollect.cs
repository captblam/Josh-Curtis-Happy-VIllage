using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishCollect : MonoBehaviour {


    public GameObject deadFish;

    public float DelayTime;
    private float MaxTime = 3f;
    public int pointsToGive;

    private bool isActive = false;

    private ScoreManager scoreHandler;

    private void Start()
    {
        scoreHandler = FindObjectOfType<ScoreManager>();
    }
    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.CompareTag("water"))
        {
            Debug.Log("Fish");
            deadFish.SetActive(true);
            isActive = true;
        }
         
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (deadFish.activeSelf) //isActive == true)
        {
            if (other.gameObject.CompareTag("Barrel"))
            {
                deadFish.SetActive(false);
                scoreHandler.GiveFish();
            }
        }
    }

}
