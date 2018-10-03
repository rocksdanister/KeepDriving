using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
    float deltaTime = 0.0f;
    Text text;
    string tmp;

    private void Start()
    {
        text = GetComponent<Text>();
    }
    void Update()
    {
      
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        if (GameController.gameController.userSettings.fps_on == true)
        {
            float fps = 1.0f / deltaTime;
            tmp = string.Format("{0:0} fps", fps);
            text.text = tmp;
        }
    }

}

