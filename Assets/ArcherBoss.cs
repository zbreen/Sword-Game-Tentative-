using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ArcherBoss : MonoBehaviour {
    public Transform[] waypoint;
    //public bool motion;
    public GameObject arrow;
    //int cur = 0;

    public int enemyHealth;

    public int Score;

    public GameObject hero;

    public float speed;

    public Transform launch;

    int randomIndex;

    bool fire;
    // Use this for initialization
    void Start () {
        fire = true;

        randomIndex = Random.Range(0, waypoint.Length);
    }
	
	// Update is called once per frame
	void Update () {
        randomIndex = Random.Range(0, waypoint.Length);
        
            transform.Translate(Vector3.up * Time.deltaTime, Space.World);

        /*if (transform.position.y >= 168f)
        {
            transform.LookAt(hero.transform.position);
        }*/

        if (enemyHealth <= 0)
        {
            ScoreManage.score += Score;

            Destroy(gameObject);
        }

        if (transform.position.x == 514.92f)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, -90, transform.eulerAngles.z);
        }

        if (transform.position.z == -531.23f)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
        }

        if(transform.position.z == -540.77f)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
        }

        if(transform.position.x == 504.84f)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 90, transform.eulerAngles.z);
        }

        if (transform.position.y >= 168.5f)
        {
            transform.LookAt(hero.transform.position);
            //StartCoroutine(Warp());

            //transform.position = waypoint[randomIndex].position;
            //randomIndex = Random.Range(0, waypoint.Length);
        }

        if (transform.position.y >= 169.5f)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            transform.position = waypoint[randomIndex].position;
        }

        Debug.DrawRay(transform.position, Vector3.forward, Color.green);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), Mathf.Infinity) && fire && transform.position.y >= 168f)
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            GameObject Arrow = Instantiate(arrow, launch.position, transform.rotation) as GameObject;



            Arrow.GetComponent<Rigidbody>().AddForce(transform.forward * 10);

            fire = false;
            StartCoroutine(Reload());
        }
    }

    IEnumerator Warp()
    {
        yield return new WaitForSeconds(5);
        //transform.position = waypoint[randomIndex].position;
        //randomIndex = Random.Range(0, waypoint.Length);
        transform.Translate(Vector3.up * Time.deltaTime, Space.World);
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(2);
        fire = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DamageSlash") || collision.gameObject.CompareTag("PlayerArrow"))
        {
            --enemyHealth;
        }
    }
}
