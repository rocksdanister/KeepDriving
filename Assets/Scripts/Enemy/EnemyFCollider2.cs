﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFCollider2 : MonoBehaviour {
    EnemyScriptTurn parentScript;
    private void Start()
    {
        parentScript = this.transform.parent.GetComponent<EnemyScriptTurn>();
        // parentScript.TurnLeft();
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.tag == "rgrass" || other.tag == "lgrass" || other.tag == "enemy")
        {
            // turn left or  right whether leftgrass or rgrass.
            if (other.tag == "rgrass")
                parentScript.ResetVelocity(1); 
            else if(other.tag == "lgrass")
                parentScript.ResetVelocity(0);
        }

    }

    
}
