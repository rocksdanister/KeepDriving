using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class QualityMenuControl : MonoBehaviour {

    public GameObject fps, quality, vibration, slider1, audioSlider;
    public Image high, low;
    float tmp;

    private void Start()
    {
        Debug.Log(GameController.gameController.userSettings.soundVol);
        if (GameController.gameController.userSettings.fps_on == true)
        {
            fps.GetComponent<Toggle>().isOn = true;
        }
        else
            fps.GetComponent<Toggle>().isOn = false;

        if (GameController.gameController.userSettings.quality == 1)  //high
        {
            high.enabled = true;
            low.enabled = false;
            quality.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            low.enabled = true;
            high.enabled = false;
            quality.GetComponent<Toggle>().isOn = false;
        }

        /*
        if (GameController.gameController.userSettings.soundVol == 1)  //ON
            audio1.GetComponent<Toggle>().isOn = true;
        else
            audio1.GetComponent<Toggle>().isOn = false;
        */

        if (GameController.gameController.userSettings.vibrate == true)
        {
            vibration.GetComponent<Toggle>().isOn = true;
        }
        else
            vibration.GetComponent<Toggle>().isOn = false;

        //slider
        
        slider1.GetComponent<Slider>().value = GameController.gameController.userSettings.var1;
        audioSlider.GetComponent<Slider>().value = GameController.gameController.userSettings.soundVol;

    }

    public void LoadScene(int sceneIndex)
    {
        GameController.gameController.Save(); // saving settings
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void FPSToggle(bool state)
    {
        if(state==true)
            GameController.gameController.userSettings.fps_on = true;
        else
            GameController.gameController.userSettings.fps_on = false;
    }

    public void QualityToggle(bool state)
    {
        if (state == true)
        {
            low.enabled = false;
            high.enabled = true;
            GameController.gameController.userSettings.quality = 1; //high
        }
        else
        {
            high.enabled = false;
            low.enabled = true;
            GameController.gameController.userSettings.quality = 0; //low
        }
    }

    /*
    public void AudioToggle(bool state)
    {
        
        if (state == true)
            GameController.gameController.userSettings.soundVol = 1;
        else
            GameController.gameController.userSettings.soundVol = 0;
        
    }
    */

    public void VibrateToggle(bool state)
    {
        if (state == true)
            GameController.gameController.userSettings.vibrate = true;
        else
            GameController.gameController.userSettings.vibrate = false;
    }

    public void SliderChange(float val)
    {
        //Debug.Log(val);
        GameController.gameController.userSettings.var1 = (int)val;
    }

    public void AudioSlider(float val)
    {
        
        GameController.gameController.userSettings.soundVol = (int)val;
    }

}
