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

        btn1.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        SoundManager.soundManager.StopPlaying(); // stop music
        SceneManager.LoadScene(0);
    }
}


