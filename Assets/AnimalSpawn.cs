using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawn : MonoBehaviour {

    [SerializeField] GameObject animalToSpawn;

    public void SpawnAtMe()
    {
        GameObject newDeer = PoolManager.Instance.GetObjectForType(animalToSpawn.name, false);
        newDeer.transform.position = transform.position;
        newDeer.transform.rotation = Quaternion.identity;
    }
}
