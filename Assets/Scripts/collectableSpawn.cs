using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectableSpawn : MonoBehaviour {

    public GameObject rock;
    public Vector3 spawn;
    public Transform prefab;

    // Use this for initialization
    void Start()
    {
        spawnRock();
    }

    public void spawnRock()
    {
        GameObject obj = Instantiate(rock, spawn, Quaternion.identity);
    }
}
