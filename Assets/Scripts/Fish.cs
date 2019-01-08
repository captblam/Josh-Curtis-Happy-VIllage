using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Fish : MonoBehaviour
{
    Vector3 currentPos, RandomPos;
    public GameObject ogj;
    [SerializeField] float SwimRadius, acceptedRange, StopTimer, MoveTimer;
    NavMeshAgent NavMesh;

    public bool isActive = false;
    float timerReset, timer2;

    Rigidbody Body;


    private void Start()
    {
        
        timer2 = MoveTimer;
        NavMesh = GetComponent<NavMeshAgent>();
        currentPos = gameObject.transform.position;
        RandomPos = GetNewLocation();
        Body = GetComponent<Rigidbody>();
        timerReset = StopTimer;
       
    }

    private void FixedUpdate()
    {
        currentPos = gameObject.transform.position;
        GetNewLocation();
        Swim();
    }

    Vector3 GetNewLocation()
        {
            Vector3 position = new Vector3(currentPos.x + Random.Range(-SwimRadius, SwimRadius), 1f, currentPos.z + Random.Range(-SwimRadius, SwimRadius));

        return position;
        }

    void Swim()
    {
        if (Vector3.Distance(currentPos, RandomPos) >= acceptedRange)
        {
            isActive = true;
            NavMesh.SetDestination(RandomPos);
            MoveTimer -= Time.deltaTime;
        }
        else isActive = false;
        {
            StopSwimming();
        }
    }

    void StopSwimming()
    {
        if (!isActive)
        {
            if(StopTimer <= 0)
            {
                StopTimer = timerReset;
                RandomPos = GetNewLocation();
            }
            else
            {
                StopTimer -= Time.deltaTime;
            }
        }
    }

    void Stuck()
    {
       
        if (MoveTimer <= 0)
        {
            GetNewLocation();
            NavMesh.SetDestination(RandomPos);
        }
        MoveTimer = timer2;
    }

    private void Update()
    {
        Stuck();
    }
}