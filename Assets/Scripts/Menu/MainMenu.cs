﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class MainMenu : MonoBehaviour {

    public LoadingScreenControl loading;
    public GameObject loadingScr;
    public void LoadScene(int sceneIndex)
    {
        if (SplashScreen.isFinished == true)  // to prevent accidental clicks
        {
            if (sceneIndex == 1)
            {
                if (GameController.gameController.userSettings.firstRun == true) // first time launch
                {
                    SceneManager.LoadScene(3);  // tutorial/cutscene
                }
                else  // display loading screen/ui. 
                {
                    loadingScr.SetActive(true);
                    loading.LoadLvlStart();
                }
            }
            else if (sceneIndex == -1)  // exit button
                Application.Quit();
            else
                UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
        }
    }
    
    public void GoBackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex == 0) // if menu screen
            Application.Quit();
        else if(Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex == 4) // if credits scene go back
            SceneManager.LoadScene(0);
    }

}
