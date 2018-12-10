using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeScript : MonoBehaviour {

    
   
	
	// Update is called once per frame
	void Update () {
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
