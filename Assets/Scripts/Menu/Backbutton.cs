using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Backbutton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //...unnecessary to have a single script for this, oh well xD.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SoundManager.soundManager.StopPlaying();
            SceneManager.LoadScene(0);

        }
    }
}
