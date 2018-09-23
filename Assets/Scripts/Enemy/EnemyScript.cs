using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public float speed;
    //public float maxSpeed;
   // public float minSpeed;
    //public float tSpeed; //turning speed
    Rigidbody2D rb;
    Vector2 tmp;// = new Vector2(0.0f, -1 * speed);


    // Use this for initialization
    void Start()
    {        
      //  maxSpeed = Random.Range(minSpeed, maxSpeed);
        rb = GetComponent<Rigidbody2D>();
        tmp = new Vector2(0.0f, -1 * speed);
        rb.velocity = tmp;
        
    }


    int flag = 0;
    public void ResetVelocity()
    {
        
        if(flag==0)
            rb.velocity = new Vector2(0, -1 * 5);
        flag = 1;
       
    }
    
    // Update is called once per frame
    void Update()
    {

        // Debug.Log(transform.position.y);
    }

}
