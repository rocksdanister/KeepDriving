using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMovement : MonoBehaviour {

    public BGscroll bgScroll;
    public TrackScript trackScript;
    //Lerp variables
    float mTravelTime;
    Vector3 mStartingPos;
    Vector3 mTargetPos;
    float mTimer;
    Vector3 tempPos;

    // Use this for initialization
    void Start()
    {
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
    void Update()
    {
        mTimer += Time.deltaTime;
        transform.position = Vector3.Lerp(mStartingPos, mTargetPos, mTimer / mTravelTime);
        //transform.position = Vector3.SmoothDamp(mStartingPos, mTargetPos, ref velocity, 2);
        if (transform.position.y == 0)
        {
            mTimer = 0.0f;
            mTargetPos = new Vector3(0, -10, 0);
            mStartingPos = transform.position;
            //  TrackScript.trackScript.NextTrackSelect(int.Parse(gameObject.tag));
            bgScroll.NextBG();
        }

        if (transform.position.y == -10)
        {
            mTimer = 0.0f;
            mTargetPos = new Vector3(0, -20, 0);
            mStartingPos = transform.position;

        }
    }
}
