using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMove : MonoBehaviour {

    public GameObject player;

    public Camera FirstCam, GhostCam;

    private Vector3 offset;

    public bool camSwitch = false;

    void Start()
    {
        offset = transform.position - player.transform.position;

        FirstCam.enabled = true;
        GhostCam.enabled = false;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;

        if (Input.GetKeyDown(KeyCode.T))
        {
            FirstCam.enabled = !FirstCam.enabled;
            GhostCam.enabled = !GhostCam.enabled;
            camSwitch = !camSwitch;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            //Application.LoadLevel(Application.loadedLevel);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
