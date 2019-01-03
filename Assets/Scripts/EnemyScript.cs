using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour {

    List<GameObject> prefabList = new List<GameObject>();
    //public GameObject Prefab1;
    //public GameObject Prefab2;

    Rigidbody enemyRigid;

    public GameObject[] spawn;

    int randomIndex;

    protected bool defeated;

    public bool dummy;

    Transform player;               // Reference to the player's position.
   // int playerHealth;      // Reference to the player's health.
   // public int enemyHealth;        // Reference to this enemy's health.
    NavMeshAgent nav;
    Player playScript;

    public int enemyHealth;

    public int Score;

    // Use this for initialization
    void Awake () {
        //prefabList.Add(Prefab1);
        //prefabList.Add(Prefab2);
        randomIndex = Random.Range(0, spawn.Length);

        enemyRigid = GetComponent<Rigidbody>();

        player = GameObject.FindGameObjectWithTag("Hero").transform;
      //  GameObject hero = GameObject.FindGameObjectWithTag("Hero");
      //  Player playScript = hero.GetComponent<Player>();
      //  playerHealth = playScript.playerHealth;
        nav = GetComponent <NavMeshAgent> ();
    }
    
	// Update is called once per frame
	void Update () {

        //players = GameObject.FindGameObjectsWithTag("Hero2");

        

        /*if (!playScript.dead)
        {
            nav.SetDestination(player.position);
        }

        else
        {
            nav.enabled = false;
        }*/
        nav.SetDestination(player.position);
        
        /*if (enemyHealth > 0 && playerHealth > 0)
        {
            // ... set the destination of the nav mesh agent to the player.
            nav.SetDestination(player.position);
        }
        else
        {
            // ... disable the nav mesh agent.
            //nav.enabled = false;
        }*/

        if (enemyHealth <= 0)
        {
            ScoreManage.score += Score;
            //int prefabIndex = UnityEngine.Random.Range(0, 2);
            //Instantiate(prefabList[prefabIndex]);
            if (!(spawn.Length == 0))
                Instantiate(spawn[randomIndex], transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DamageSlash"))
        {
            --enemyHealth;
        }
    }*/

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DamageSlash") || other.gameObject.CompareTag("PlayerArrow"))
        {
            --enemyHealth;

            Vector3 dir = other.contacts[0].point - transform.position;

            dir = -dir.normalized;

            GetComponent<Rigidbody>().AddForce(dir * force);
        }
    }*/

    public float force;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BlockAttack"))
        {
            Vector3 dir = collision.contacts[0].point - transform.position;

            dir = new Vector3(0, 0, 1.2f);

            enemyRigid.AddForce(dir * 3, ForceMode.Impulse);
        }

        if (collision.gameObject.CompareTag("DamageSlash") || collision.gameObject.CompareTag("PlayerArrow"))
        {
            --enemyHealth;

            Vector3 dir = /*collision.contacts[0].point - transform.position;*/ transform.position - collision.transform.position;

            //dir = -dir.normalized;

            //GetComponent<Rigidbody>().AddForce(dir * force);

            enemyRigid.AddForce(dir * force, ForceMode.Impulse);
        }
    }
}
