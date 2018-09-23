using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveSettings : MonoBehaviour {


    //...Save Data Variables
    [Serializable]
    public class UserSettings
    {
        public int soundVol;
        public bool benchmarkDone;
        public float avgFPS;
        public int highScore1;
        public int highScore2;
        public int highScore3;

        public UserSettings()
        {
            soundVol = 100;
            benchmarkDone = false;
            avgFPS = -1.0f;
            highScore1 = 0;
            highScore2 = 0;
            highScore3 = 0;
        }
    }
    public UserSettings userSettings, loadData;

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

        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerSettings.dat", FileMode.Open);
            // PlayerData data = (PlayerData)bf.Deserialize(file);
            loadData = (UserSettings)bf.Deserialize(file);
            file.Close();
            userSettings.avgFPS = loadData.avgFPS;
            userSettings.benchmarkDone = loadData.benchmarkDone;
            userSettings.soundVol = loadData.soundVol;

        }

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
