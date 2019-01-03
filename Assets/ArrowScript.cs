using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : Player {

    public GameObject projectile;
    Transform player;
    Player m_player;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Hero").transform;
        m_player = player.GetComponent<Player>();
        //arrowUp = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.M) && !dead)
        {
            LaunchArrow();
        }
    }

    void LaunchArrow()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1f);
        GameObject Arrow = Instantiate(projectile, transform.position, transform.rotation) as GameObject;



        Arrow.GetComponent<Rigidbody>().AddForce(transform.forward * 30);

        if (m_player.arrowUp)
        {
            Vector3 pos2 = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z + 1f);
            Vector3 pos3 = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z + 1f); 

            GameObject Arrow2 = Instantiate(projectile, pos2, transform.rotation) as GameObject;
            GameObject Arrow3 = Instantiate(projectile, pos3, transform.rotation) as GameObject;

            Arrow2.GetComponent<Rigidbody>().AddForce(transform.forward * 30);
            Arrow3.GetComponent<Rigidbody>().AddForce(transform.forward * 30);

            Destroy(Arrow2, 1.0f);
            Destroy(Arrow3, 1.0f);
        }

        Destroy(Arrow, 1.0f);
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ArrowUp"))
        {
            arrowUp = true;
            StartCoroutine(ArrowUp());
            Destroy(other.gameObject);
        }
    }

    IEnumerator ArrowUp()
    {
        yield return new WaitForSeconds(3);
        arrowUp = false;
    }*/
}
