using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdScript : MonoBehaviour {

    public Button m_YourFirstButton;
    public Image img;
    public Text text;
    Button btn1;
    void Start()
    {
        btn1 = m_YourFirstButton.GetComponent<Button>();

        //Calls the TaskOnClick/TaskWithParameters method when you click the Button
        btn1.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        /*
        GameController.gameController.adCounter++; //skip next restart ad
        btn1.interactable = false;
        text.enabled = false;
        img.enabled = false;
        Advertisement.Show();
        */
    }
}
