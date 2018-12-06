using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {


    public Text FoodText;

    public float scoreCount;

    public bool scoreIncrease;



    // Update is called once per frame
    void Update()
    {
        FoodText.text = "Food: " + Mathf.Round(scoreCount);
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

    public void AddPoints(int pointsToAdd)
    {
        scoreCount += pointsToAdd;
    }
}
