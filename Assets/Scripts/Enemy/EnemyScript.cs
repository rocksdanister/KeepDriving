using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public float speed;
    Rigidbody2D rb;
    Vector2 tmp;


    // Use this for initialization
    void Start()
    {        
      //  maxSpeed = Random.Range(minSpeed, maxSpeed); // decided constant speed instead.
        rb = GetComponent<Rigidbody2D>();
        tmp = new Vector2(0.0f, -1 * speed);
        rb.velocity = tmp;
        
    }


    int flag = 0;
    public void ResetVelocity() // stop moving if road infront.
    {
        
        if(flag==0)
            rb.velocity = new Vector2(0, -1 * 5);
        flag = 1;
       
    }
    

}
