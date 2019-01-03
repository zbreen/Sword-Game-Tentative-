using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeScript : MonoBehaviour {

    public Transform point;

    public float speed = 0.2f;

    public int health = 2;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, point.position, speed * Time.deltaTime);

        //this.transform.position.Set(this.transform.position.x, 148, this.transform.position.y);
    }
}
