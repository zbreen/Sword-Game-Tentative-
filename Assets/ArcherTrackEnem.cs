using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ArcherTrackEnem : MonoBehaviour {

    List<GameObject> prefabList = new List<GameObject>();
    //public GameObject Prefab1;
    //public GameObject Prefab2;

    Rigidbody enemyRigid;

    public GameObject[] spawn;

    int randomIndex;

    protected bool defeated;

    public bool dummy;

    Transform player;

    NavMeshAgent nav;
    Player playScript;

    public int enemyHealth;

    public int Score;

    public GameObject arrow;

    bool fire;

    // Use this for initialization
    void Start () {
        randomIndex = Random.Range(0, spawn.Length);

        enemyRigid = GetComponent<Rigidbody>();

        player = GameObject.FindGameObjectWithTag("Hero").transform;

        nav = GetComponent<NavMeshAgent>();

        fire = true;
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(player.position);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), Mathf.Infinity) && fire)
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            GameObject Arrow = Instantiate(arrow, transform.position, transform.rotation) as GameObject;



            Arrow.GetComponent<Rigidbody>().AddForce(transform.forward * 30);

            fire = false;
            StartCoroutine(Reload());

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

    }
        

        public float force = 20;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BlockAttack"))
        {
            Vector3 dir = collision.contacts[0].point - transform.position;

            dir = -dir.normalized;

            GetComponent<Rigidbody>().AddForce(dir * force);
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
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(2);
        fire = true;
    }
}


