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
          //  int w = Screen.width, h = Screen.height;

          //  GUIStyle style = new GUIStyle();

          //  Rect rect = new Rect(0, 0, w, h * 2 / 100);
           // style.alignment = TextAnchor.UpperRight;
            //style.fontSize = h * 2 / 100;
            //style.normal.textColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            //float msec = deltaTime * 1000.0f;
            float fps = 1.0f / deltaTime;
            //string text = string.Format("{0:0.0} ms {1:0.} fps", msec, fps);
            tmp = string.Format("{0:0} fps", fps);
            text.text = tmp;
           // GUI.Label(rect, text, style);
        }
    }

}

