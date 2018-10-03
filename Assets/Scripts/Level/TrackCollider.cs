using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCollider : MonoBehaviour
{

    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player" || other.tag == "enemy")
        {

            if (other.tag == "enemy")
            {
             //   Debug.Log(other.transform.position.y);
               if(other.transform.position.y>5f)
                 Destroy(other.gameObject);
            }
        }
    }
    */

    // .. destroy enemy cars entering track (Outside the view scene).
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "player" || other.tag == "enemy")
        {
            //Debug.Log("stay" + other.tag);
            if (other.tag == "enemy")
                if (other.transform.position.y > 5f)
                    Destroy(other.gameObject);
        }
    }
    
}
