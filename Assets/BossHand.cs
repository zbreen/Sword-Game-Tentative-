using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossHand : MonoBehaviour {
    NavMeshAgent nav;
    Player playScript;

    public Vector3 origin;

    /*public int enemyHealth;

    public int Score;*/

    Rigidbody enemyRigid;

    Transform player;

    public bool animStart;
    public bool go;
    // Use this for initialization
    void Start () {
        enemyRigid = GetComponent<Rigidbody>();

        player = GameObject.FindGameObjectWithTag("Hero").transform;

        nav = GetComponent<NavMeshAgent>();

        InvokeRepeating("Swap", 3f, 3f);
    }
	
	// Update is called once per frame
	void Update () {
		if (!go)
        {
            transform.position = new Vector3(origin.x, origin.y, origin.z);
        }

        else
        {
            nav.SetDestination(player.position);
        }

        //InvokeRepeating("Swap", 3f, 3f);
        //Invoke("Swap", 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hero"))
        {
            StartCoroutine(slamStart());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
            StartCoroutine(slamStart());
        }
    }

    IEnumerator slamStart()
    {
        GetComponent<Collider>().enabled = false;
        animStart = true;
        yield return new WaitForSeconds(1);
        animStart = false;
        GetComponent<Collider>().enabled = true;
    }

    void Swap()
    {
        go = !go;
    }
}
