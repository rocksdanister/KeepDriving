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
            text.text = "SCORE: " + Mathf.CeilToInt(sceneController.elapsedTime0);
        }
        else
        {
            text.enabled = false;
        }
        
    }

}
