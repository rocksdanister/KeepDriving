using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    public GameObject player;
    public PlayerController playerController;
    public EnableHighScorePanel highScorePanel;
    public int disable_collission;
    public Vector3 spawnValues;
    public GameObject[] enemyCars;
    public float startWait;
    public float waveWait;
    public float spawnWait;
    public float spawnWait2;
    public float spawnWait3;
    public float spawnWait4;
    public int enemyCount;
    public int enemyCount2;
    public int enemyCount3;
    public int enemyCount4;

    [HideInInspector] public int state_Restarting = 0;
    int restarted;
    Coroutine co;

    //..score
    public float elapsedTime0 = 0;
    //public float score;

    //.. not sure I need this
    bool gameLaunch = true;
    public bool gameRun = false;

    //.. Day/Night Cycle variables
    [HideInInspector] public int currentTimeState = 0;  // 0-day,1-evening,2-night,3-morning
    public float secondsInFullDay = 120f;
    float secondsInFullDayBackup;
    private float elapsedTime = 0;
    public SpriteRenderer ambientLight;
    public Color[] cycle = { new Color(1f, 1f, 1f, 0.784f), new Color(0.784f, 0.254f, 0.172f, 0.69f), new Color(0.0588f, 0.0588f, 0.0588f, 1f), new Color(0.898f, 0.0709f, 0.223f, 0.745f) }; //day-sunset-night-sunrise-day,ie 0-1-2-3-0
    public float rateAtColorChange;
    float rateAtColorChangeBackup;
    [HideInInspector] public int midwayNighttoMorning = 0;


    public void StartEnemyWave()
    {
        co = StartCoroutine(SpawnWaves());
    }

    int whatWave, prevWave, nightTime;
    float prevXPos;
    IEnumerator SpawnWaves()
    {
        GameObject enemy1;
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            prevXPos = 10;  // fix
            whatWave = Random.Range(0, enemyCars.Length - 1);  // excluding max, also length-1 since car1&2 are part of wave 0
            if (restarted == 1)
            {
                //.. logic for enemy selection, trying not to repeat waves
                if (whatWave == prevWave)
                {
                    if (prevWave == 0)
                        whatWave = prevWave + 1;
                    else
                        whatWave = prevWave - 1;
                }
            }

            nightTime = 0; //default,not night
            // setting wave to 0 at nighttime, atleast trying to xD
            if (currentTimeState == 1)  //evening to night
            {
                if (elapsedTime >= 15) // half of seasonchangerate?
                {
                    //Debug.Log("NOW");
                    nightTime = 1;
                    if (Random.value <= 0.5)
                        whatWave = 0;
                    else
                        whatWave = 3;
                }
            }
            
            if (gameRun == false)
                whatWave = 0; // display only wave 0 when gameover
            //.. enemy selection end

            // wave delay control
            if (restarted == 1)
            {
                if (whatWave == 2) // straight car
                {
                    if (prevWave == 1) //zig zag speed ie if prev zig zag speed then wait 1second
                        yield return new WaitForSeconds(1);
                    else
                        yield return new WaitForSeconds(2);
                }
                else if (whatWave == 1) //zig zag speed
                {
                    if (prevWave == 2)
                        yield return new WaitForSeconds(0.5f);
                    else
                        yield return new WaitForSeconds(1.5f);
                }
                else
                    yield return new WaitForSeconds(0.1f);
            }
            restarted = 1;
            prevWave = whatWave;

            //..debugging
            //whatWave = 2;

            //Debug.Log("wave:"+whatWave);
            if (whatWave == 0)
            {
                for (int i = 0; i < enemyCount; i++)   // normal enemy car
                {
                    Vector3 spawnPosition;
                    enemy1 = enemyCars[UnityEngine.Random.Range(0, 2)];
                    if (UnityEngine.Random.value >= 0.4f)  // 60% chance for random
                        spawnPosition = new Vector3(UnityEngine.Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                    else
                        spawnPosition = new Vector3(playerController.transform.position.x, spawnValues.y, spawnValues.z);
                    Quaternion spawnRotation = Quaternion.Euler(0f, 0f, 180f);
                    Instantiate(enemy1, spawnPosition, spawnRotation);
                    if(nightTime==0)
                        yield return new WaitForSeconds(spawnWait);
                    else if(nightTime==1)
                        yield return new WaitForSeconds(spawnWait+0.2f); //nighttime easier
                }
               // yield return new WaitForSeconds(waveWait);
            }
            else if (whatWave == 1)
            {
                for (int i = 0; i < enemyCount3; i++)   // zig zag
                {
                    enemy1 = enemyCars[3];
                    //  Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                    Vector3 spawnPosition = new Vector3(playerController.transform.position.x, spawnValues.y, spawnValues.z);
                    Quaternion spawnRotation = Quaternion.Euler(0f, 0f, 180f);
                    Instantiate(enemy1, spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait3);
                }
               // yield return new WaitForSeconds(waveWait);
            }
            else if (whatWave == 2)
            {
                for (int i = 0; i < enemyCount2; i++)  // straight
                {
                    enemy1 = enemyCars[2];

                    if (Mathf.Abs(prevXPos - playerController.transform.position.x) < 0.3f)
                    {
                        // i--;
                        //Debug.Log("NOP");
                    }
                    else
                    {
                        Vector3 spawnPosition = new Vector3(playerController.transform.position.x, spawnValues.y, spawnValues.z);
                        Quaternion spawnRotation = Quaternion.Euler(0f, 0f, 180f);
                        Instantiate(enemy1, spawnPosition, spawnRotation);
                    }
                    prevXPos = playerController.transform.position.x;
                    yield return new WaitForSeconds(spawnWait2);
                }
               // yield return new WaitForSeconds(waveWait);
            }
            else if(whatWave==3)
            {
                for (int i = 0; i < enemyCount2; i++)  // zig zag same speed
                {
                    enemy1 = enemyCars[4];
                    //  Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                    Vector3 spawnPosition = new Vector3(playerController.transform.position.x, spawnValues.y, spawnValues.z);
                    Quaternion spawnRotation = Quaternion.Euler(0f, 0f, 180f);
                    Instantiate(enemy1, spawnPosition, spawnRotation);
                    if (nightTime == 0)
                        yield return new WaitForSeconds(spawnWait4);
                    else
                        yield return new WaitForSeconds(spawnWait4 + 0.2f);
                }
              //  yield return new WaitForSeconds(waveWait);
            }

        }
    }

    void DayNightCycle()
    {
        //Debug.Log(elapsedTime);

        if (elapsedTime > secondsInFullDay)
        {
           // Debug.Log("cycle change");
            elapsedTime = 0;  // dont forget to reset it to 0 when lvl restarts
            if (currentTimeState < 4)
                currentTimeState += 1;
            else
                currentTimeState = 0;
        }
        if (currentTimeState == 0)  // day - evening
        {
            ambientLight.color = Color.Lerp(cycle[0], cycle[1], elapsedTime / rateAtColorChange);
        }
        else if (currentTimeState == 1)
        {
            if(gameRun==true)
                ambientLight.color = Color.Lerp(cycle[1], cycle[2], elapsedTime / rateAtColorChange);
            else
                ambientLight.color = Color.Lerp(cycle[1], cycle[4], elapsedTime / rateAtColorChange);
            midwayNighttoMorning = 1;
        }
        else if (currentTimeState == 2)
        {
            if(gameRun==true)
                ambientLight.color = Color.Lerp(cycle[2], cycle[3], elapsedTime / rateAtColorChange);
            else
                ambientLight.color = Color.Lerp(cycle[4], cycle[3], elapsedTime / rateAtColorChange);
            if (elapsedTime > (secondsInFullDay * 0.15))
            {
                //Debug.Log(elapsedTime);
                midwayNighttoMorning = 0;
            }

        }
        else if (currentTimeState == 3)
        {
            ambientLight.color = Color.Lerp(cycle[3], cycle[0], elapsedTime / rateAtColorChange);
        }
    }


    void CommunicateWithController()
    {

    }

    // Use this for initialization
    void Start () {
        restarted = 0;
        StartEnemyWave();
        secondsInFullDayBackup = secondsInFullDay;
        rateAtColorChangeBackup = rateAtColorChange;
        SoundManager.soundManager.StartPlaying(0);
    }

    public void RestartScene()
    {
        SoundManager.soundManager.StopPlaying();
       // SoundManager.soundManager.StartPlaying(0); // Start is calling it already
        SceneManager.LoadScene(1);
    }

    public void ChangeGameRun(int i)
    {
        if (i == 0)
        {
            player.SetActive(false);
            secondsInFullDay = 8;  // fast animation of day/cycle 
            rateAtColorChange = 4;
            gameRun = false;
            highScorePanel.DisplayScore(true);
        }
        else
        {
            gameRun = true;
        }
    }

    int flag = 0;
    void MusicChanger()
    {
        if (gameRun == true) // since after gameover, ther is fast animation of day/night
        {
            //Debug.Log(currentTimeState);
            if (currentTimeState == 1)
            {
                if (rateAtColorChange <= elapsedTime % secondsInFullDay && flag == 0)
                {
                    flag = 1;
                    SoundManager.soundManager.CallMusicChanger(0, 1); // night time music
                }
            }
            else if (currentTimeState == 2 && flag == 1)
            {
                flag = 0;
                SoundManager.soundManager.CallMusicChanger(1, 0); // daytime
            }
        }
    }

	// Update is called once per frame
	void Update () {
        if(gameRun==true)
            elapsedTime0 += Time.deltaTime; //score
        //... Day/night cycle
        elapsedTime += Time.deltaTime;
        DayNightCycle();
        MusicChanger();

    }
}
