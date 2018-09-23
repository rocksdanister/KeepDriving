using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableHighScorePanel : MonoBehaviour {

    public SceneController sceneController;
    public HighScore scriptA;
    GameObject obj; //text obj
    Image img,imgPlayButton,imgExit,imgExit2,adImg; //canvas img
    Text text, adText;
    Button btn,btn2,btn3,adBtn;
    // Use this for initialization
    void Start () {
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

        /*
        //..ad
        obj = gameObject.transform.Find("AdButton").gameObject;
        adImg = obj.GetComponent<Image>();
        adBtn = obj.GetComponent<Button>();

        obj = gameObject.transform.Find("AdText").gameObject;
        adText = obj.GetComponent<Text>();
       // img = GetComponent<Image>();
        */

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

        /*
        // advertisement
        adBtn.interactable = false;
        adImg.enabled = false;
        adText.enabled = false;
        */
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

            /*
            // advertisement
            if ( (GameController.gameController.adCounter % 7 == 0 || GameController.gameController.adCounter % 7 == 1 ) && GameController.gameController.adCounter != 1 )
            {
                if (Advertisement.IsReady() == true) //not sure if this is how its done.
                {
                    adBtn.interactable = true;
                    adImg.enabled = true;
                    adText.enabled = true;
                }
            }
            */
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

            /*
            // advertisement
            adBtn.interactable = false;
            adImg.enabled = false;
            adText.enabled = false;
            */
        }
    }

    //int flag = 0;
	// Update is called once per frame
	void Update () {
        /*
        if (sceneController.gameRun == false)
        {
            //obj.SetActive(true);
            if (flag == 0)
            {
                flag = 1;
                text.enabled = true;
                img.enabled = true;
                scriptA.UpdateScore();
                imgPlayButton.enabled = true;
                imgExit.enabled = true;
                btn.interactable = true;
                btn2.interactable = true;
            }
        }
        else
        {
            flag = 0;
            // obj.SetActive(false);
            text.enabled = false;
            img.enabled = false;
            imgPlayButton.enabled = false;
            imgExit.enabled = false;
            btn.interactable = false;
            btn2.interactable = false;

        }
        */

    }
}
