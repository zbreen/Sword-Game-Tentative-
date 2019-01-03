using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : EnemyScript {

    public GameObject[] spawn;

    int randomIndex;

	// Use this for initialization
	void Start () {
        randomIndex = Random.Range(0, spawn.Length);
        Debug.Log(randomIndex);
    }
	
	// Update is called once per frame
	void Update () {
		if (defeated)
        {
            Instantiate(spawn[randomIndex]);
        }
	}
}
