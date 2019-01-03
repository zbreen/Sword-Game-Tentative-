using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    public Button startButton;

    // Use this for initialization
    void Start() {
        Button btn1 = startButton.GetComponent<Button>();

        btn1.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }

        

    }

    private void OnMouseUp()
    {
        SceneManager.LoadScene("Battle Scene 1");
    }

    public void TaskOnClick()
    {
        StartGame();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Battle Scene 1");
    }
}
