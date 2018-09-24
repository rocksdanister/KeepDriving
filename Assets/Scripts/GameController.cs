using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {


    public static GameController gameController;

   // public int[] scores  = new int[5];


    //... Benchmarking & Save Data Variables
    [Serializable]
    public class UserSettings
    {
        public int quality;  // 0 -low, 1-high
        public int soundVol;  // 100-0 , 200 - 1vol
        public int highScore1;
        public bool fps_on; // 0-off, 1-on
        public bool firstRun;  // to decide to show tutorial?
        public bool vibrate;
        // for future use.
        public int var1;
        public int var2;
        public int var3;
        public UserSettings() // default settings
        {
            firstRun = true;
            quality = 0;
            soundVol = 200;  // 100% volume
            highScore1 = 0;
            fps_on = false;
            vibrate = true;
            var1 = 80;  //slider 10-100, existing users 0, new users 100
            var2 = 0;  // avg score
            var3 = 0;  // gamecount for avg score.
        }
    }
    [HideInInspector]public UserSettings userSettings, loadData;
    bool gameLaunch = true;
    public bool gameRun = false;

    void Awake()
    {
       //Application.targetFrameRate = 24;
        //.. Singleton design, only one isntance.
        if (gameController == null)
        {
            DontDestroyOnLoad(gameObject);
            gameController = this;
        }
        else if (gameController != this)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        userSettings = new UserSettings();
        Load();  // load save data
        //Application.targetFrameRate = 30;
    }


    public void Save()
    {
        //.. using binary for safety, so that user cant modify (well amateurs anyway xD )
        BinaryFormatter bf = new BinaryFormatter();

        // .. in windows this path is under user/appdata/LocalLow/...
        //Debug.Log(Application.persistentDataPath);
        FileStream file = File.Create(Application.persistentDataPath + "/playerSettings.dat");
        bf.Serialize(file, userSettings);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerSettings.dat"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/playerSettings.dat", FileMode.Open);             
                loadData = (UserSettings)bf.Deserialize(file);
                file.Close();
                userSettings.firstRun = loadData.firstRun;  
                userSettings.soundVol = loadData.soundVol;
                userSettings.quality = loadData.quality;
                userSettings.highScore1 = loadData.highScore1;
                userSettings.fps_on = loadData.fps_on;
                userSettings.vibrate = loadData.vibrate;
                userSettings.var1 = loadData.var1;
                userSettings.var2 = loadData.var2;
                userSettings.var3 = loadData.var3;

            if (userSettings.var1 < 10)  //control sensitivity ,before update var1=0 so a fix. now var1 is from 10-100
            {
                userSettings.var1 = 80;
            }

            if(userSettings.soundVol <10) // for old users, new range is 100-200. Old was 0-1
            {
                userSettings.soundVol = 200;
            }

        }

    }

    // Update is called once per frame
    void Update () {

    }

}
