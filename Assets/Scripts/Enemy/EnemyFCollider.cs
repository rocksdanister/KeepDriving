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
     //   if (parentScript.transform.position.y <= 4.6f)
      //  {
            if (other.tag == "rgrass" || other.tag == "lgrass" || other.tag == "enemy")
            {
                parentScript.ResetVelocity();
            }
    //    }
       // else
   //     {
        //    if(other.tag=="enemy")
        //        Destroy(other.gameObject);
      //  }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

      //  if (parentScript.transform.position.y <= 4.6f)
     //   {
            if (other.tag == "rgrass" || other.tag == "lgrass" || other.tag == "enemy")
            {
                parentScript.ResetVelocity();
            }
      //  }
        // else
        //     {
        //    if(other.tag=="enemy")
        //        Destroy(other.gameObject);
        //  }
    }


    private void OnTriggerExit2D(Collider2D other)
    {

//        if (parentScript.transform.position.y <= 4.6f)
    //    {
            if (other.tag == "rgrass" || other.tag == "lgrass" || other.tag == "enemy")
            {
                parentScript.ResetVelocity();
            }
      //  }
        // else
        //     {
        //    if(other.tag=="enemy")
        //        Destroy(other.gameObject);
        //  }
    }


    /*
    private void OntriggerExit2D(Collider2D other)
    {
        Debug.Log("exit");
        if (other.tag == "rgrass")
        {
            Debug.Log("exit");
            parentScript.ResetVelocity();
        }
    }
    */
}
