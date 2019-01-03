using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float maxSize;
    public float growFactor;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(Scale());
    }

    // Update is called once per frame
    void Update()
    {
        if (maxSize <= transform.localScale.x)
        {
            Destroy(gameObject);
        }
    }
    IEnumerator Scale()
    {
        while (maxSize > transform.localScale.x)
        {
            //timer += Time.deltaTime;
            transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * growFactor;
            yield return null;
        }
    }
}
