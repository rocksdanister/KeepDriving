using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour {

    public LayerMask touchInputMask;
    private List<GameObject> touchList = new List<GameObject>();
    private GameObject[] touchesOld;
    private RaycastHit hit;

    // Use this for initialization
    void Start () {
        Screen.sleepTimeout = SleepTimeout.NeverSleep; // nevertimeout for accelearometer
    }

    // Update is called once per frame
    void Update () {
	 // Not using it, decided to only use accelerometer input.
        /*
        if (Input.touchCount > 0)
        {
            touchesOld = new GameObject[touchList.Count];
            touchList.CopyTo(touchesOld);
            touchList.Clear();

            foreach (Touch touch in Input.touches)
            {
                Ray ray = GetComponent<Camera>().ScreenPointToRay(touch.position);

                if (Physics.Raycast(ray, out hit, touchInputMask))
                {
                    GameObject recipient = hit.transform.gameObject;
                    touchList.Add(recipient);
                    if (touch.phase == TouchPhase.Began)
                    {
                        // Debug.Log("began" + recipient.tag);
                        if (recipient.tag == "left" && PlayerController.playerController.debug1==0)
                            PlayerController.playerController.TouchDown(0);
                        // recipient.SendMessage("PlayerTouchDownLeft", hit.point, SendMessageOptions.DontRequireReceiver);
                        else if (recipient.tag == "right" && PlayerController.playerController.debug1 == 0)
                            PlayerController.playerController.TouchDown(1);
                        // recipient.SendMessage("PlayerTouchDownRight", hit.point, SendMessageOptions.DontRequireReceiver);
                        else if (recipient.tag == "debug1")  // switch control debugging.
                        {
                            if (PlayerController.playerController.debug1 == 0)
                                PlayerController.playerController.debug1 = 1;
                            else
                                PlayerController.playerController.debug1 = 0;
                        }
                    }
                    if (touch.phase == TouchPhase.Ended)
                    {
                        PlayerController.playerController.TouchEnd();
                        //   if (recipient.tag == "left")
                        // recipient.SendMessage("PlayerTouchUpLeft", hit.point, SendMessageOptions.DontRequireReceiver);
                        // else if (recipient.tag == "right")
                        // recipient.SendMessage("PlayerTouchUpRight", hit.point, SendMessageOptions.DontRequireReceiver);
                        // Debug.Log("Ended" + recipient.tag);
                    }
                    if (touch.phase == TouchPhase.Stationary)
                    {

                        if (recipient.tag == "left" && PlayerController.playerController.debug1 == 0)
                            PlayerController.playerController.TouchStay(0);
                        //  recipient.SendMessage("PlayerTouchStayLeft", hit.point, SendMessageOptions.DontRequireReceiver);
                        else if (recipient.tag == "right" && PlayerController.playerController.debug1 == 0)
                            PlayerController.playerController.TouchStay(1);
                        //  recipient.SendMessage("PlayerTouchStayRight", hit.point, SendMessageOptions.DontRequireReceiver);
                        // Debug.Log("stationary" + recipient.tag);
                    }

                }
            }
            foreach ( GameObject g in touchesOld)
            {
                if (!touchList.Contains(g))
                {
                    Debug.Log("NOT CONTAINED");
                }
            }
        }
        */
	}
}
