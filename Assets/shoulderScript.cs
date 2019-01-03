using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoulderScript : MonoBehaviour {

    public Transform camPivot;
    public Transform cam;

    private Vector3 vCurr = Vector3.zero;

    float heading;

    Vector2 input;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update () {
        //heading += Input.GetAxis("Mouse X")*Time.deltaTime*180;
        //camPivot.rotation = Quaternion.Euler(0, heading, 0);
        

        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal"));
        

        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector3 CamF = cam.forward;
        //Vector3 CamR = cam.right;

        CamF.y = 0;
        //CamR.y = 0;

        CamF = CamF.normalized;
        //CamR = CamR.normalized;

        transform.position += (CamF * input.y /*+ CamR * input.x*/)*Time.deltaTime*5;
        

        /*Vector3 vNext = vCurr;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //transform.rotation = Quaternion.LookRotation(new Vector3 (0, 0, 0));
            vNext.y = 0;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //transform.Rotate(new Vector3(0, -90, 0));
            vNext.y = -90;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //transform.Rotate(new Vector3(0, 90, 0));
            vNext.y = 90;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //transform.Rotate(new Vector3(0, 180, 0));
            vNext.y = 180;
        }

        if (vNext != vCurr)
        {
            transform.eulerAngles = vNext;
            vCurr = vNext;
        }*/
    }
}
