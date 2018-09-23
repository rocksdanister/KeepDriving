using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class track : MonoBehaviour {


    Vector2 startpos;
    // Use this for initialization
    void Start () {
        
        startpos = new Vector2();
        startpos = transform.position;
    }

    private void Update()
    {
       //float newPosition = Mathf.Repeat(Time.time * 4, 10);
       // transform.position = startpos + Vector2.down* newPosition;

    }
    // Update is called once per frame
    void FixedUpdate () {
       /*
        float newPosition = Mathf.Repeat(Time.time * 4, 10);
        transform.position = startpos + Vector2.down * newPosition;
        */
    }
}
