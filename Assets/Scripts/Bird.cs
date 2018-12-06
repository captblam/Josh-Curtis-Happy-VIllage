using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    public float Hspeed;
    public float Vspeed;
    public float Zspeed;
    public float aplitiude;
    public float travelDistance;

    private Vector3 movePosition;
    private Vector3 newPosition;
    Transform temp;

    private Rigidbody body;

    public float minY = 0.0f, maxY = 10.0f;
    public float minZ = 0.0f, maxZ = 20.0f;

    // Use this for initialization
    void Start()
    {
        //set default to moveposition
        movePosition = transform.position;
        newPosition = transform.position;
        temp = new GameObject().transform;
        body = GetComponent<Rigidbody>();
    }

    ////controls/ set to moveposition
    //movePosition.x += Hspeed;
    //       

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, new Vector3 (250, 150, 250)) >= travelDistance)
        {
            temp.position = new Vector3(250 + Random.Range(-10, 10),0, 250 + Random.Range(-10, 10));
            transform.LookAt(temp);
        }

       
        movePosition = transform.position;
        movePosition.y = Mathf.Sin(Time.realtimeSinceStartup + Vspeed) * aplitiude + maxY - minY;
        //transform.position = movePosition;
        body.MovePosition(transform.position + transform.forward * Hspeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        body.velocity = Vector3.zero;
    }
}