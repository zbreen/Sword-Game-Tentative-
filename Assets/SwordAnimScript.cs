using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAnimScript : MonoBehaviour {
    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);

        if (Input.GetKeyDown(KeyCode.B))
        {
            anim.SetBool("Swing", true);
            StartCoroutine(Attack(0.25f));
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            anim.SetBool("Guard", true);
            StartCoroutine(Defend(0.5f));
        }
    }

    IEnumerator Attack(float delay)
    {
        yield return new WaitForSeconds(delay);
        anim.SetBool("Swing", false);
    }

    IEnumerator Defend(float delay)
    {
        yield return new WaitForSeconds(delay);
        anim.SetBool("Guard", false);
    }
}
