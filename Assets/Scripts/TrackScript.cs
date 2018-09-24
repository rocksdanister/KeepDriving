using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackScript : MonoBehaviour {

    public BGscroll bgScroll;
    public int debug = 0;
    public int debug_1 = 0;
    public int debug_2 = 0;
    //public float trackSwitchPos;
    [HideInInspector] public int currentTrack;
    [HideInInspector] public int currentTrack2;

    //.. Road Speed/time
    public float mTravelTime;

    //.. Track Data such as sequence order etc
    [Serializable]
    public class Track
    {
        public int[] seq;
        public string ttype;
        public GameObject obj;

    }
    public Track[] trackData;

    private Vector2[] startPosition = new Vector2[50];
    private Vector2 tmp=  new Vector2(0.0f,9.984f);
   
    // Use this for initialization
    void Start()
    {
     //   if(GameController.gameController.gameRun == true)
            InitialSetup();
    }

    public void InitialSetup()
    {
        currentTrack = 0;
        currentTrack2 = 100;
        if (debug == 1)
        {
            currentTrack = debug_1;
        }
        bgScroll.NextBG();
        GiveVelocity(0);

    }


    int c = 1;  //.. make it 0 if you are starting from track0 on main camera pos
    public void NextTrackSelect(int i)//,int k)
    {
        int tmp = trackData[i].seq[UnityEngine.Random.Range(0, trackData[i].seq.Length)];
        GiveVelocity(tmp);

    }

    public void GiveVelocity(int i)
    {
        Vector3 spawnPosition = new Vector3(0,10,0);
        Quaternion spawnRotation = Quaternion.Euler(0f, 0f, 0f);
        Instantiate(trackData[i].obj, spawnPosition, spawnRotation);       
    }

    void Update()
    {

    }
}
