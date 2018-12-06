using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]

public class SquirrelScript : MonoBehaviour
{

    Vector3 currentPos, randomPos, jumpPos;
    public GameObject obj;
    Rigidbody rb;
    [SerializeField] float grazeTimer, acceptRange, wanderRadius;
    float timerReset;
    bool isActive = false;
    NavMeshAgent smith;

    private ScoreManager sMan;
   

    // Use this for initialization
    void Start()
    {
        sMan = FindObjectOfType<ScoreManager>();
        smith = GetComponent<NavMeshAgent>();
        timerReset = grazeTimer;
        currentPos = gameObject.transform.position;
        randomPos = GetNewLocal();
       //jumpPos = null;
        rb = GetComponent<Rigidbody>();

    }
   


    private void FixedUpdate()
    {
        
        currentPos = gameObject.transform.position;
        GetNewLocal();
        Roam();

    }

    Vector3 GetNewLocal()
    {
        //Vector3 position = new Vector3(Random.Range(0, 500), 0.5f, Random.Range(0, 500));
        Vector3 position = new Vector3(currentPos.x + Random.Range(-wanderRadius, wanderRadius), 1f, currentPos.z + Random.Range(-wanderRadius, wanderRadius));

        return position;
    }

    void Roam()
    {
        if (Vector3.Distance(currentPos, randomPos) >= acceptRange)
        {
            isActive = true;
            smith.SetDestination(randomPos);

        }
        else isActive = false;
        Grazing();
    }



    void Grazing()
    {
        if (!isActive)
        {
            if (grazeTimer <= 0)
            {
                grazeTimer = timerReset;
                randomPos = GetNewLocal();
            }
            else
            {
                grazeTimer -= Time.deltaTime;
            }

        }
    }
  
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("weapon"))
        {
            ded();
            sMan.GiveSquirrel();
        }
    }
    void ded()
    {
        PoolManager.Instance.PoolObject(gameObject);
    }
   
}
