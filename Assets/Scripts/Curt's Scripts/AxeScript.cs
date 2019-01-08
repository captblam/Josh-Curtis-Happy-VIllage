using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeScript : AttackBehaviour {

    public override void Run()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            transform.Rotate(80, 0, 0);
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            transform.Rotate(-80, 0, 0);
        }
    }
}