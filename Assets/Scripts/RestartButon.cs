using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartButon : MonoBehaviour {

    public SceneController sceneController;
    //Make sure to attach these Buttons in the Inspector
    public Button m_YourFirstButton;


    void Start()
    {
        Button btn1 = m_YourFirstButton.GetComponent<Button>();

        //Calls the TaskOnClick/TaskWithParameters method when you click the Button
        btn1.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        sceneController.RestartScene();
        //Output this to console when the Button is clicked
       // GameController.gameController.RestartLvl();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
