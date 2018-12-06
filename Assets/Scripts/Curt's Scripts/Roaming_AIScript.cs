using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(Rigidbody))]

public class Roaming_AIScript : MonoBehaviour {

    Vector3 currentPos, randomPos;
    public GameObject obj;
    Rigidbody rb;
    [SerializeField] float  grazeTimer, acceptRange, wanderRadius;
    float timerReset;
    bool isActive = false;
    NavMeshAgent smith;
    [SerializeField] GameObject[] spawnLocations;
    AnimalSpawn animalSpawn;
    int HP = 10;
    int currentHP;
   
    private ScoreManager sMan;
    
    // Use this for initialization
    void Start () {

        currentHP = HP;
        sMan = FindObjectOfType<ScoreManager>();
        smith = GetComponent<NavMeshAgent>();
        timerReset = grazeTimer;
        currentPos = gameObject.transform.position;
        randomPos = GetNewLocal();
        rb = GetComponent<Rigidbody>();
        spawnLocations = GameObject.FindGameObjectsWithTag("SpawnLoc");
    }
    private void Update()
    {
        ded();
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

   
    //spelled correctly and all
    void ded()
    {
        if(currentHP <= 0)
        {
            sMan.GiveDeer();
            PoolManager.Instance.PoolObject(gameObject);
            currentHP = HP;
        }
       
    }

    private void OnDisable()
    {
        spawnLocations = GameObject.FindGameObjectsWithTag("SpawnLoc");
        int newSpot = Random.Range(0, spawnLocations.Length - 1);
        animalSpawn = spawnLocations[newSpot].GetComponent<AnimalSpawn>();
        animalSpawn.SpawnAtMe();
    }

    public void LoseHealth(int DamageAmount)
    {
        currentHP -= DamageAmount;
        Debug.Log("DAMAGE!");
    }
    public void Killed()
    {
        sMan.GiveDeer();
        PoolManager.Instance.PoolObject(gameObject);
        currentHP = HP;
        Debug.Log("DED!");
    }
    public void Slow()
    {
        rb.velocity = Vector3.zero;
        Debug.Log("MA ASS!");
    }
}
