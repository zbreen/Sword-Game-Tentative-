using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Script : MonoBehaviour {

    public float speed;

    //public GameObject projectile;

    public GameObject blade;

    public GameObject attackBox;
    public GameObject defendBox;

    public Text Health;

    public int playerHealth;

    Vector3 movement;

    bool attacking;

    bool defending;

    bool attackable;

    bool RangeUp;

    public bool arrowUp;

    public bool aerial;

    public bool dead;

    private Vector3 vCurr = Vector3.zero;

    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        transform.eulerAngles = vCurr;

        attacking = false;
        defending = false;

        aerial = false;

        Health.text = "X X X";

        attackable = true;

        RangeUp = false;

        aerial = false;

        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*Rigidbody rb = GetComponent<Rigidbody>();
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(Vector3.left);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(Vector3.right);
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(Vector3.up);
        if (Input.GetKey(KeyCode.S))
            rb.AddForce(Vector3.down);*/
        Vector3 vNext = vCurr;

        float moveHorizontal = Input.GetAxis("P2_Horizontal");
        float moveVertical = Input.GetAxis("P2_Vertical");

        if (playerHealth == 3)
        {
            Health.text = "X X X";
        }

        if (playerHealth == 2)
        {
            Health.text = "X X";
        }

        if (playerHealth == 1)
        {
            Health.text = "X";
        }

        if (playerHealth <= 0)
        {
            Health.text = "Dead";
            dead = true;
            //transform.Rotate(new Vector3(0, 0, 90));
            this.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.W) && !dead)
        {
            //transform.rotation = Quaternion.LookRotation(new Vector3 (0, 0, 0));
            vNext.y = 0;
        }

        if (Input.GetKeyDown(KeyCode.A) && !dead)
        {
            //transform.Rotate(new Vector3(0, -90, 0));
            vNext.y = -90;
        }

        if (Input.GetKeyDown(KeyCode.D) && !dead)
        {
            //transform.Rotate(new Vector3(0, 90, 0));
            vNext.y = 90;
        }

        if (Input.GetKeyDown(KeyCode.S) && !dead)
        {
            //transform.Rotate(new Vector3(0, 180, 0));
            vNext.y = 180;
        }

        if (Input.GetKeyDown(KeyCode.F) && !dead && aerial)
        {
            transform.Translate(Vector3.up * 60 * Time.deltaTime, Space.World);
            aerial = false;
        }

        if (!attacking && !defending && !dead)
        {
            Move(moveHorizontal, moveVertical);
        }

        if (vNext != vCurr)
        {
            transform.eulerAngles = vNext;
            vCurr = vNext;
        }

        if (Input.GetKeyDown(KeyCode.Q) && !dead)
        {
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.E) && !dead)
        {
            Defend();
        }

        /*if (Input.GetKeyDown(KeyCode.C) && !dead)
        {
            LaunchArrow();
        }*/
    }

    void Move(float h, float v)
    {
        /*Vector3 targetDirection = new Vector3(h, 0f, v);
        targetDirection = Camera.main.transform.TransformDirection(targetDirection);
        targetDirection.y = 0.0f;*/

        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;

        rb.MovePosition(transform.position + movement);
    }

    void Attack()
    {
        StartCoroutine(AttackBoxShow(attackBox, 0.5f));
    }

    IEnumerator AttackBoxShow(GameObject strike, float delay)
    {
        strike.SetActive(true);
        strike.transform.localPosition = new Vector3(-6.1035e-05f, 0.156f, 0.21f);
        if (RangeUp)
        {
            strike.transform.localScale = new Vector3(0.1674978f, 1f, 0.1f);
            strike.transform.localPosition = new Vector3(0, 0.364f, 0.021f);
            blade.transform.localScale = new Vector3(0.009999996f, 0.6262712f, 0.05178265f);
        }
        else
        {
            strike.transform.localScale = new Vector3(0.1674978f, 0.5043182f, 0.1f);
            strike.transform.localPosition = new Vector3(0, 0.19516f, 0.02136f);
            blade.transform.localScale = new Vector3(0.009999996f, 0.269869f, 0.05178265f);
        }
        attacking = true;
        yield return new WaitForSeconds(delay);
        strike.SetActive(false);
        attacking = false;
    }

    void Defend()
    {
        StartCoroutine(DefendBoxShow(defendBox, 0.5f));
    }

    IEnumerator DefendBoxShow(GameObject strike, float delay)
    {
        strike.SetActive(true);
        strike.transform.localPosition = new Vector3(-6.1035e-05f, 0.156f, 0.21f);
        defending = false;
        yield return new WaitForSeconds(delay);
        strike.SetActive(false);
        defending = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //float force = 10;

        if (collision.gameObject.CompareTag("Enemy") && attackable)
        {
            /*Vector3 dir = collision.contacts[0].point - transform.position;
            dir = -dir.normalized;
            rb.AddForce(dir * force);*/
            --playerHealth;
            attackable = false;
            StartCoroutine(immuneTime());
        }

        if (collision.gameObject.CompareTag("Floor"))
        {
            aerial = true;
        }
    }

    IEnumerator immuneTime()
    {
        yield return new WaitForSeconds(1);
        attackable = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RangeUp"))
        {
            RangeUp = true;
            StartCoroutine(RangePowerUp());
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Restore"))
        {
            if (playerHealth < 3)
            {
                playerHealth += 1;
            }
            else
            {
                playerHealth = 3;
            }

            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("ArrowUp"))
        {
            arrowUp = true;
            StartCoroutine(ArrowUp());
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Explosion"))
        {
            --playerHealth;
            attackable = false;
            StartCoroutine(immuneTime());
        }
    }

    IEnumerator RangePowerUp()
    {
        yield return new WaitForSeconds(3);
        RangeUp = false;
    }

    IEnumerator ArrowUp()
    {
        yield return new WaitForSeconds(3);
        arrowUp = false;
    }

    /*void LaunchArrow()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1f);
        GameObject Arrow = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;

        Arrow.GetComponent<Rigidbody>().AddForce(transform.forward * 30);
    }*/
}
