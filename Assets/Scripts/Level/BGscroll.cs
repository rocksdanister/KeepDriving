using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGscroll : MonoBehaviour {

    public GameObject[] bg;  // array for different seasons, currently not implemented.

    //.. Next background prefab instantiated.
    public void NextBG() //  not used
    {
        int i = 0;
        Vector3 spawnPosition = new Vector3(0, 10, 0);
        Quaternion spawnRotation = Quaternion.Euler(0f, 0f, 0f);
        Instantiate(bg[i], spawnPosition, spawnRotation);

    }


}
