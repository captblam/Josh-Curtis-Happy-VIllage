using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowth : MonoBehaviour {
    [SerializeField]float growthTimer, timer, maxHeight, height, expandTimer;
    
	// Use this for initialization
	void Start () {
        growthTimer = timer;
        expandTimer = timer * 2;
        
	}
	
	// Update is called once per frame
	void Update () {
        growthTimer -= Time.deltaTime;
        expandTimer -= Time.deltaTime;
        Grow();
	}
    void Grow()
    {
        if(growthTimer <= 0 && height != maxHeight)
        {
            transform.localScale += new Vector3(0, .1f, 0);
            height++;
            growthTimer = timer;
        }
        if(expandTimer <= 0 && height != maxHeight)
        {
           // transform.localScale += new Vector3(.3f, 0, .3f);
           // expandTimer = timer * 2;
           
        }
    }
    public void ResetSize()
    {
        for(int i = 0; i < height; height--)
        {
            transform.localScale += new Vector3(0, -.1f, 0);
        }
       
    }
}
