using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusScript : MonoBehaviour {

    [SerializeField]int Health = 20, Hunger = 0, Thirst = 0, Comfort = 0, HpLost = 1, Community = 2;
    [SerializeField] float HpTimer, HungerTimer, ThirstTimer, ComfortTimer, timer = 6;
    
	// Use this for initialization
	void Start () {
        HpTimer = timer;
        HungerTimer = timer * 4;
        ThirstTimer = timer * 2;
        ComfortTimer = timer * 8;
        
	}
	
	// Update is called once per frame
	void Update () {
        HpTimer -= Time.deltaTime;
        HungerTimer -= Time.deltaTime;
        ThirstTimer -= Time.deltaTime;
        ComfortTimer -= Time.deltaTime;
        //PlayerHp();
        PlayerHunger();
        //PlayerThirst();
        //PlayerComfort();
        Ded();
    }
    public void PlayerHp()
    {
        Health -= HpLost;
    }
    void PlayerHunger()
    {
        if (HungerTimer <= 0)
        {
            Hunger++;
        }
    }
    //void PlayerThirst()
    //{
    //    if (ThirstTimer <= 0)
    //    {
    //        Thirst++;
    //    }
    //}
    //void PlayerComfort()
    //{
    //    if (ComfortTimer <= 0)
    //    {
    //        Comfort++;
    //    }
    //}
    void Ded()
    {
        if(Health <= 0)
        {
            Debug.Log("DED!");
            Community--;
            Destroy(gameObject);
        }
    }
   
}
