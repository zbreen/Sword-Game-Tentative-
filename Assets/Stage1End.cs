using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1End : MonoBehaviour {

    public GameObject target;
    public GameObject target2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if((target == null) && (target2 == null))
        {
            SceneManager.LoadScene("Battle Scene 2");
        }
	}
}
