using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptTurn : MonoBehaviour {
    public float speed;
    Rigidbody2D rb;
    public float turnSpeed;
    Vector2 tmp;
    float currTurn;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (Random.value <= 0.5) // go left or right, 50% chance.
            currTurn = turnSpeed;
        // tmp = new Vector2(turnSpeed, -1 * speed);
        else
            currTurn = -1 * turnSpeed;
           // tmp = new Vector2(-1 * turnSpeed, -1 * speed);

        tmp = new Vector2(currTurn, -1 * speed);
        rb.velocity = tmp;

    }



    public void ResetVelocity(int i = 0) // i =0 left grass, i =1 right grass
    {
        if (i == 0) //goin left, change to right
        {
            if (currTurn < 0) //make it go right
                currTurn = -1 * currTurn; //make it positive
        }
        else
        {
            if(currTurn > 0)
            currTurn = -1 * currTurn;
        }

        rb.velocity = new Vector2(currTurn, -1 * speed);
       // currTurn = -1 * currTurn;
    }

    // Update is called once per frame
    void Update()
    {

        // Debug.Log(transform.position.y);
    }
}
