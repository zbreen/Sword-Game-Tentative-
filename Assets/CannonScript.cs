using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour {
    public Transform[] waypoint;
    public bool motion;
    public GameObject bomb;
    int cur = 0;

    public float speed = 0.3f;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (motion == true)
        {
            if (transform.position != waypoint[cur].position)
            {
                transform.position = Vector3.MoveTowards(transform.position, waypoint[cur].position, speed * Time.deltaTime);
            }
            else
            {
                Instantiate(bomb, transform.position, transform.rotation);
                cur = (cur + 1) % waypoint.Length;
            }
        }
    }
}
