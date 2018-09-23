using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtScript : MonoBehaviour {

    public float speed;
    Rigidbody2D rb;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        Vector2 tmp = new Vector2(0.0f, -1 * speed);
        rb.velocity = tmp;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
