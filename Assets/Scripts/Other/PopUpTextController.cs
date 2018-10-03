using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpTextController : MonoBehaviour {

    public  GameObject popText;
    private  GameObject canvas;
    public int mileStone = 25;
    private int mileStoneIncr;
    public string[] Voices; // text added in unity editor ui.

    public SceneController sceneController;

    void Start()
    {
        mileStoneIncr = mileStone; //.. display text at what score interval.
        canvas = GameObject.Find("Canvas"); // where to spawn.
    }

    public void CreateFloatingText(string text)
    {
            GameObject instance = Instantiate(popText);
            instance.transform.SetParent(canvas.transform, false);
            instance.GetComponent<PopupText>().SetText(text);
    }

    private void Update()
    {

        if (Mathf.CeilToInt(sceneController.elapsedTime0) > mileStone)
        {         
            CreateFloatingText("+" + mileStone + "\n" + Voices[UnityEngine.Random.Range(0, Voices.Length)]);
            mileStone += mileStoneIncr;
        }
        
    }

}
