using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMovement : MonoBehaviour {

    public TrackScript trackScript;
    //Lerp variables
    float mTravelTime;
    Vector3 mStartingPos;
    Vector3 mTargetPos;
    float mTimer;
    Vector3 tempPos;


    private Vector3 velocity = Vector3.zero;

    // Use this for initialization
    void Start () {
        InitialVal();
	}

    public void InitialVal()
    {
        mTravelTime = trackScript.mTravelTime;
        tempPos = transform.position;
        mStartingPos = transform.position;
        mTargetPos = new Vector3(0, 0, 0);
        mTimer = 0.0f;

    }
	
	// Update is called once per frame
	void Update () {

        mTimer += Time.deltaTime;
        transform.position = Vector3.Lerp(mStartingPos, mTargetPos, mTimer / mTravelTime);
        //transform.position = Vector3.SmoothDamp(transform.position, mTargetPos,ref velocity ,2.0f);


        if (transform.position.y == 0) // road reached exactly screen position, from top.
        {
            mTimer = 0.0f;
            mTargetPos = new Vector3(0, -10, 0);
            mStartingPos = transform.position;
            trackScript.NextTrackSelect(int.Parse(gameObject.tag)); // start moving nexttrack from top.
        }

        if(transform.position.y == -10)  // road outside screen.
        {
            mTimer = 0.0f;
            mTargetPos = new Vector3(0, -20, 0);
            mStartingPos = transform.position;

        }
    }
}
