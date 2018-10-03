using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GpuInfo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;
        GUIStyle style = new GUIStyle();
        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperRight;
        style.fontSize = h * 2 / 100;
        style.normal.textColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        string text = SystemInfo.graphicsDeviceName;
        GUI.Label(rect, text, style);
    }
}
