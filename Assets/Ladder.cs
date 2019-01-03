using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {

    public GameObject hero;
    bool climbable;
    float speed = 1;

	// Use this for initialization
	void Start () {
        //hero = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (climbable)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                hero.transform.Translate (new Vector3(0, 1, 0) * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                hero.transform.Translate (new Vector3(0, -1, 0) * Time.deltaTime * speed);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == hero)
        {
            climbable = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == hero)
        {
            climbable = false;
        }
    }
}
