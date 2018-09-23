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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           // GameController.gameController.adCounter = 1; //advertisement
            SoundManager.soundManager.StopPlaying();
            SceneManager.LoadScene(0);
           // GameController.gameController.ResetEverything();
           // Application.Quit();
        }
    }
}
