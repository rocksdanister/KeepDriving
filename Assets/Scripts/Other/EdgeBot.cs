using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeBot : MonoBehaviour {

    //... deleting prefabs going out of screen.
    private void OnTriggerExit2D(Collider2D other)
    {     
            Destroy(other.gameObject);
    }

}
