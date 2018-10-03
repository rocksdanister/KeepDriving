using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableHighScorePanel : MonoBehaviour {

    public SceneController sceneController;
    public HighScore scriptA;
    GameObject obj; //text obj
    Image img,imgPlayButton,imgExit,imgExit2; //canvas img
    Text text;
    Button btn, btn2, btn3;
    // Use this for initialization
    void Start () {

        //.. there is probabily far better way to do this unlike this, I went this way.
        obj = gameObject.transform.Find("Text1").gameObject;
        text = obj.GetComponent<Text>();
        img = GetComponent<Image>();

        obj = gameObject.transform.Find("Play").gameObject;
        btn = obj.GetComponent<Button>();
        imgPlayButton = obj.GetComponent<Image>();

        obj = gameObject.transform.Find("Exit").gameObject;
        imgExit = obj.GetComponent<Image>();
        btn2 = obj.GetComponent<Button>();

        obj = gameObject.transform.Find("Exit2").gameObject;
        imgExit2 = obj.GetComponent<Image>();
        btn3 = obj.GetComponent<Button>();

        //... disable everything at first
        text.enabled = false;
        img.enabled = false;
        imgPlayButton.enabled = false;
        imgExit.enabled = false;
        btn.interactable = false;
        btn2.interactable = false;

        // top right
        btn3.interactable = true;
        imgExit2.enabled = true;

    }

    public void DisplayScore(bool state)
    {
        if (state == true) 
        {
            text.enabled = true;
            img.enabled = true;
            scriptA.UpdateScore();
            imgPlayButton.enabled = true;
            imgExit.enabled = true;
            btn.interactable = true;
            btn2.interactable = true;
            //...top exit button
            btn3.interactable = false;
            imgExit2.enabled = false;

        }
        else
        {
            text.enabled = false;
            img.enabled = false;
            imgPlayButton.enabled = false;
            imgExit.enabled = false;
            btn.interactable = false;
            btn2.interactable = false;
            //...top exit button
            btn3.interactable = true;
            imgExit2.enabled = true;

        }
    }

	void Update () {

    }
}
