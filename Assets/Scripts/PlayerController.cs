using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {

   // public GameObject player;
    SpriteRenderer playerSprite;
    private Rigidbody2D rb;

    public SceneController sceneController;

    public float accel;
    float tmpSpeed;
    public float zRotate;
    private float tmpRotate; // not used for now
    public float speed;
    [HideInInspector] public int debug1 = 1;  // =1 accelerometer only on, =0 off
    Vector3 plStartPos = new Vector3();

    //...lights
    public GameObject headlight;
    public GameObject highlight;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (sceneController.disable_collission== 0)
        {
            if (other.tag == "enemy" || other.tag == "lgrass" || other.tag == "rgrass")
            {

                sceneController.ChangeGameRun(0); // set gameRun=0 to dispaly score etc
                if(GameController.gameController.userSettings.vibrate== true)
                    Handheld.Vibrate();  // vibrate device

            }
        }
    }

    // Use this for initialization
    void Start () {
        playerSprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        plStartPos = transform.position;
        
        //if (sceneController.gameRun == true)
        //{
            debug1 = 1;

            tmpSpeed = speed;
        //}
        
    }


    public void AccelerometerMove()
    {

        float x = Input.acceleration.x;
        //accel = 0f;
        //zRotate = 10f;
        accel = x * (float)GameController.gameController.userSettings.var1/100f;

        //.. capping value of accel
        if (accel < -0.7f)
            accel = -0.7f;
        else if (accel > 0.7f)
            accel = 0.7f;

       // Debug.Log("x= " + accel);

        if (x <-0.05f)
        {
            TouchStay(0);
        }
        else if(x >0.05f)
        {
            TouchStay(1);
        }
        else
        {
            TouchEnd();
        }
        
    }
    
    public void TouchDown(int i) // i=0 left, 1 right buttonh
    {

    }

    
    public void TouchStay(int i)
    {
        if (i == 0)
        {
            rb.velocity = new Vector2( (tmpSpeed*accel), 0f);
            rb.rotation = -1*zRotate*accel/1.2f;
           
        }
        else
        {
            rb.velocity = new Vector2(tmpSpeed*accel, 0f);
            rb.rotation = -1*zRotate*accel/1.2f;
        }
    }

    public void TouchEnd()
    {
        tmpSpeed = speed;
        tmpRotate = rb.rotation;
        if(tmpRotate > 0)
            tmpRotate -= 0.5f;
        else if(tmpRotate < 0)
            tmpRotate += 0.5f;
        else
            tmpRotate = 0;
        rb.velocity = new Vector2(0f, 0f);
        rb.rotation = tmpRotate;

    }

    public void PlayerPosClamp()
    {
        // player position
        Vector3 clampedPosition = transform.position;
        // Restricting player pos on X axis
        clampedPosition.x = Mathf.Clamp(transform.position.x, -2.5f, 2.5f);
        transform.position = clampedPosition;
    }

    void Update () {

        if (debug1 == 1)
           AccelerometerMove();

        PlayerPosClamp();
        if (sceneController.gameRun == true)
        {
            //.. Lighting control
            if (sceneController.currentTimeState == 1 || sceneController.midwayNighttoMorning == 1)
            {
                headlight.SetActive(true);
                // highlight.SetActive(true);
            }
            else
            {
                headlight.SetActive(false);
                highlight.SetActive(false);
            }
        }

       

    }
}
