using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHandHealth : MonoBehaviour {

    public int enemyHealth;

    public GameObject animCheck;

    Animator Anim;

    public int Score;
    BossHand animCheckOut;
    // Use this for initialization
    void Start () {
        Anim = GetComponent<Animator>();

        animCheckOut = animCheck.GetComponent<BossHand>();
    }
	
	// Update is called once per frame
	void Update () {
        if (enemyHealth <= 0)
        {
            ScoreManage.score += Score;
            //int prefabIndex = UnityEngine.Random.Range(0, 2);
            //Instantiate(prefabList[prefabIndex]);
            
            Destroy(gameObject);
        }

        if (animCheckOut.animStart == true)
        {
            Anim.SetBool("Slam", true);
        }
        else
        {
            Anim.SetBool("Slam", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DamageSlash") || collision.gameObject.CompareTag("PlayerArrow"))
        {
            --enemyHealth;

            //Vector3 dir = /*collision.contacts[0].point - transform.position;*/ transform.position - collision.transform.position;

            //dir = -dir.normalized;

            //GetComponent<Rigidbody>().AddForce(dir * force);

            //enemyRigid.AddForce(dir * force, ForceMode.Impulse);
        }
    }
}
