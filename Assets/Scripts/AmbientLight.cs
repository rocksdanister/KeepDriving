using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientLight : MonoBehaviour {
    public AmbientLight ambieLight;

    /*
    void Awake()
    {
        //Application.targetFrameRate = 24;
        //.. Singleton design, only one isntance.
        if (ambieLight == null)
        {
            DontDestroyOnLoad(gameObject);
            ambieLight = this;
        }
        else if (ambieLight != this)
        {
            Destroy(gameObject);
        }
    }
    */
    // Update is called once per frame
    void Update () {
		
	}
}
