using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour {
    public Button startButton;
    // Use this for initialization
    void Start () {
        Button btn1 = startButton.GetComponent<Button>();

        btn1.onClick.AddListener(TaskOnClick);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseUp()
    {
        SceneManager.LoadScene("OverShoulderTest");
    }

    public void TaskOnClick()
    {
        StartGame();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("OverShoulderTest");
    }
}
