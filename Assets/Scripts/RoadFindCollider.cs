using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadFindCollider : MonoBehaviour {

    
     private void OnTriggerStay2D(Collider2D other)
     {
        // other.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
        if(other.tag=="leftside" )
        Debug.Log(other.bounds);
    }

}
