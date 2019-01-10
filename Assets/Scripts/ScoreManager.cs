using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {


    public Text FoodText;
    public Text StoneText;

    public float scoreCount;
    public float stoneCount;
    public float cropCount;

    public bool scoreIncrease;
    private PlayerStatusScript psc;

    [SerializeField] float HpTimer, timer = 6;
    [SerializeField] private List<GameObject> villagers = new List<GameObject>();

    private void Start()
    {
        HpTimer = timer;
    }
    // Update is called once per frame
    void Update()
    {
        //HpTimer -= Time.deltaTime;
        FoodText.text = "Food: " + Mathf.Round(scoreCount);
        StoneText.text = "Stone: " + Mathf.Round(stoneCount);
        psc = FindObjectOfType<PlayerStatusScript>();
        //Eat();
    }

    public void GiveFish()
    {
        AddPoints(1);
        
    }
    public void GiveDeer()
    {
        AddPoints(3);
    }
    public void GiveSquirrel()
    {
        AddPoints(1);
    }

    public void GiveStone()
    {
        AddStonePoints(1);
    }
    public void GiveCrop()
    {
        //AddCropPoints(1);
        AddPoints(1);
    }

    public void AddPoints(int pointsToAdd)
    {
        scoreCount += pointsToAdd;
    }

    public void AddStonePoints(int stoneToAdd)
    {
        stoneCount += stoneToAdd;
    }

    public void AddCropPoints(int cropToAdd)
    {
        cropCount += cropToAdd;
    }
    public void Eat()
    {
        if(scoreCount > 0)
        {
            scoreCount -= 1;           
        }
        if (scoreCount == 0)
        {
            psc.PlayerHp();
            Debug.Log("took damage");
        }
        

    }

}
