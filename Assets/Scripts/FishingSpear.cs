using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingSpear : AttackBehaviour {

    public GameObject Spear;
    public Vector3 currentPos;
    public Vector3 endPos;
    public Vector3 goBack;

    public float distance = 30f;

    public float LerpTime = 5;
    public float currLerpTime = 0;
    public float perc;

    public bool keyHit = false;
    public GameObject spearSpawn;
    public GameObject player;

    public override void Run()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            transform.Rotate(120, 0, 0);
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            transform.Rotate(-120, 0, 0);
        }
    }
}
