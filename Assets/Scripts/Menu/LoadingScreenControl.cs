﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreenControl : MonoBehaviour {

    public GameObject loadingObj;
    public Slider slider;

    //... Loaing in the bacmkground with a loading screen.
    AsyncOperation async;

    // Use this for initialization
    void Start () {

	}

    public void LoadLvlStart()
    {
        StartCoroutine(LoadingScreen());
    }
	// .. background loading.
    IEnumerator LoadingScreen()
    {
        loadingObj.SetActive(true);
        async = SceneManager.LoadSceneAsync(1);
        async.allowSceneActivation = false;

        while(async.isDone == false)
        {
            slider.value = async.progress;
            if(async.progress == 0.9f)
            {
                slider.value = 1f; // loading animation, see ui element.
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
