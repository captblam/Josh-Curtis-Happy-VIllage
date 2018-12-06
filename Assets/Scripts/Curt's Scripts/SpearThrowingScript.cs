using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class SpearThrowingScript : MonoBehaviour {
    public GameObject obj, SpawnLoc;
    int maxSpearsOnScreen = 1;
    Vector3 spawn;
    Quaternion rot;
    Ray Target;
    Vector3 speartarget;
    Rigidbody rb;
    // Use this for initialization
    void Start () {
        rot = SpawnLoc.transform.rotation;
        spawn = SpawnLoc.transform.position;
        rb = GetComponent<Rigidbody>();
    }
	
	
    private void FixedUpdate()
    {
        rot = SpawnLoc.transform.rotation;
        spawn = SpawnLoc.transform.position;
    }
    void Update()
    {
        SpawnSpear();
    }
   
    
    void SpawnSpear()
    {
        if (Input.GetButtonDown("Attack") && gameManager.instance.getControlled().name == gameObject.name)
        {
            GameObject spear = PoolManager.Instance.GetObjectForType("Spear 1", false);
            spear.transform.position = spawn;
            spear.transform.rotation = Quaternion.identity;
            spear.transform.LookAt(Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 100)), Vector3.up);
            spear.GetComponent<Rigidbody>().AddForce(spear.transform.forward * 300, ForceMode.Impulse);
            spear.GetComponent<Rigidbody>().velocity = rb.velocity;
        }
    }

   
 
}
