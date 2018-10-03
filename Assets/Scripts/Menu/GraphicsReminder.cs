using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsReminder : MonoBehaviour {

    int flag = 0;
    Text text;
    public string[] gpuNames;  // tested gpu names, add entry in Unity Editor.
    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();
        
        //.. Initially I made a benchmark script to test performance, decided to scrap that & just use tested gpu list.
        foreach(string str in gpuNames)
        {
            if (SystemInfo.graphicsDeviceName == str)
            {
                text.text = SystemInfo.graphicsDeviceName + " Detected\nSuggested Setting: Turn On";
                flag = 1;
            }
        }
        if(flag==0)   
            text.text = SystemInfo.graphicsDeviceName + " Detected\nSuggested Setting: Turn Off";
            
      //  text.text = "hello";
    }
	
	// Update is called once per frame
	void Update () {

    }
}
