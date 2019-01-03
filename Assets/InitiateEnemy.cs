using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitiateEnemy : MonoBehaviour {

    public GameObject spawner;
    public Transform spawn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hero"))
        {
            spawner.SetActive(true);
            Destroy(gameObject);
        }
    }
}
