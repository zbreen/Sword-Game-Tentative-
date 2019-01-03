using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

    public GameObject enemy;

   public GameObject wall;
    public float delay;
    public int total;

    protected bool death;

    bool spawned;

    Transform Player;

    Player playScript;

    // Use this for initialization
    void Start () {
        //Player = GameObject.FindGameObjectWithTag("Player").transform;
        //playScript = Player.GetComponent<Player>();
        wall.SetActive(true);
        spawned = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (total > 0 && !spawned/*&& !playScript.dead*/)
        {
            //InvokeRepeating("Spawn", delay, delay);
            Instantiate(enemy, transform.position, transform.rotation);
            spawned = true;
            --total;
            StartCoroutine(spawnTime());
        }

        /*if (total <= 0 && wall != null)
        {
            Destroy(wall);
        }*/
    }

    IEnumerator spawnTime()
    {
        yield return new WaitForSeconds(delay);
        spawned = false;
    }

    void Spawn()
    {
        Instantiate(enemy, transform.position, transform.rotation);
        --total;
    }
}
