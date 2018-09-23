using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{

    public Button m_YourFirstButton;

    void Start()
    {
        Button btn1 = m_YourFirstButton.GetComponent<Button>();

        //Calls the TaskOnClick/TaskWithParameters method when you click the Button
        btn1.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        //Output this to console when the Button is clicked
        //Application.Quit();
       // GameController.gameController.adCounter = 1; //advertisement
        SoundManager.soundManager.StopPlaying(); // stop music
        SceneManager.LoadScene(0);
    }
}


