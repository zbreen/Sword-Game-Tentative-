using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightScript : MonoBehaviour {

    public Transform starter;

    private Rigidbody rb;

    bool slam;
	// Use this for initialization
	void Start () {
        slam = false;
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
		if (!slam)
        {
            transform.position = Vector3.MoveTowards(transform.position, starter.position, 2 * Time.deltaTime);
            StartCoroutine(Slam());
        }
        else
        {
            rb.useGravity = true;
        }

	}

    IEnumerator Slam()
    {
        yield return new WaitForSeconds(3);
        slam = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Hero"))
        {
            rb.useGravity = false;
            slam = false;
            //rb.useGravity = false;
        }
    }
}
