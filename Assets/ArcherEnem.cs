using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherEnem : MonoBehaviour {
    public LayerMask ign;
    public Transform[] waypoint;
    public bool motion;
    public GameObject arrow;
    int cur = 0;

    public float speed;

    public Transform launch;

    bool fire;

    // Use this for initialization
    void Start () {
        fire = true;
	}
	
	// Update is called once per frame
	void Update () {

        int layermask = 10 << 11;

        if (transform.position != waypoint[cur].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoint[cur].position, speed * Time.deltaTime);
        }
        else
        {
            cur = (cur + 1) % waypoint.Length;
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),  Mathf.Infinity, ign)&& fire)
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            GameObject Arrow = Instantiate(arrow, launch.position, transform.rotation) as GameObject;



            Arrow.GetComponent<Rigidbody>().AddForce(transform.forward * 10);

            fire = false;
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(2);
        fire = true;
    }
}
