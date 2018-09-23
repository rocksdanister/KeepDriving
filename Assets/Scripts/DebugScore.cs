using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugScore : MonoBehaviour {

    private float elapsedTime = 0; // The amount of time that has elapsed.
    public SceneController sceneController;
    Text text;
                      
    void Start () {
        text = GetComponent<Text>();

    }

    private void Update()
    {
        if (sceneController.gameRun == true)
        {
            text.enabled = true;
            // GameController.gameController.elapsedTime0 += Time.deltaTime;
            text.text = "SCORE: " + Mathf.CeilToInt(sceneController.elapsedTime0);
        }
        else
        {
            text.enabled = false;
        }
        
    }

    /*
    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.font = font;
        style.fontSize = h * 2 / 100;
        style.normal.textColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        string text = string.Format("Score: {0}", Mathf.CeilToInt(elapsedTime));
        GUI.Label(rect, text, style);
    }
    */
}
