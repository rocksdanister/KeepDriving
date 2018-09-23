using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGscroll : MonoBehaviour {


    public int seasonDuration;
    public GameObject[] bg;
    float scrollSpeed;
    public float tileSizeZ;
    private Vector3[] startPosition = new Vector3[10];

    void Start()
    {

        //Vector3 spawnPosition = new Vector3(0, 10, 0);
        //Quaternion spawnRotation = Quaternion.Euler(0f, 0f, 0f);
        //Instantiate(bg[0], spawnPosition, spawnRotation);
        /*
        int i = 0;
        foreach (Transform child in transform)
        {
            startPosition[i] = child.transform.position;
            i++;
        }
        */
    }

    public void NextBG()
    {

        int i = 0;

        Vector3 spawnPosition = new Vector3(0, 10, 0);
        Quaternion spawnRotation = Quaternion.Euler(0f, 0f, 0f);
        Instantiate(bg[i], spawnPosition, spawnRotation);

    }

    void Update()
    {

        /*
        scrollSpeed = 10 / TrackScript.trackScript.mTravelTime;
        int i = 0;
        foreach (Transform child in transform)
        {
                float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);      
                child.transform.position = startPosition[i] + Vector3.down * newPosition;
                i++;
           // Debug.Log("Mathf: " + newPosition);
        }
        */
    }

}
