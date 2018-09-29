using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFCollider : MonoBehaviour {

    EnemyScript parentScript;
    private void Start()
    {
       parentScript = this.transform.parent.GetComponent<EnemyScript>();
       // parentScript.TurnLeft();
    }

    private void OnTriggerStay2D(Collider2D other)
    {

            if (other.tag == "rgrass" || other.tag == "lgrass" || other.tag == "enemy") // left grass, right grass or other enemy.
            {
                parentScript.ResetVelocity(); // Stop the enemy movement.
            }

    }
    /*
    private void OnTriggerEnter2D(Collider2D other)
    {


            if (other.tag == "rgrass" || other.tag == "lgrass" || other.tag == "enemy")
            {
                parentScript.ResetVelocity();
            }

    }


    private void OnTriggerExit2D(Collider2D other)
    {

            if (other.tag == "rgrass" || other.tag == "lgrass" || other.tag == "enemy")
            {
                parentScript.ResetVelocity();
            }

    }
    */

}
