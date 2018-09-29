using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettings : MonoBehaviour {

    //...not used.

    AudioSource src;
	// Use this for initialization
	void Start () {
        src = GetComponent<AudioSource>();
        if (GameController.gameController.userSettings.soundVol == 0)
            src.mute = true;
        else
            src.mute = false;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
