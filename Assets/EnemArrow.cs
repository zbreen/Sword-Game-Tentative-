using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemArrow : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //StartCoroutine(endIt());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
            Destroy(gameObject);
        }

        StartCoroutine(endIt());
    }

    IEnumerator endIt()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
