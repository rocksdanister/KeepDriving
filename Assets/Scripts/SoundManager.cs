using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour {

    public static SoundManager soundManager;

    //audio clips
    public AudioClip[] trk;

    Coroutine co,co2,co3,chMusic;

    AudioSource audioSource;
    public float trackVolume;
    public bool loop;
    public float speed;

    private bool keepFadingIn;
    private bool keepFadingOut;
    [HideInInspector]public float maxVolume = 1;


    void Awake()  
    {
        //.. Singleton design, only one isntance; Doing this eliminates loading time the 2nd run from menu screen since sound assets already loaded.
        if (soundManager == null)
        {
            DontDestroyOnLoad(gameObject);
            soundManager = this;
        }
        else if (soundManager != this)
        {
            Destroy(gameObject);
        }
    }

    public void CallMusicChanger(int now,int next)
    {
        if (co3 != null)
            StopCoroutine(co3);
        if (chMusic != null)
            StopCoroutine(chMusic);

        if (GameController.gameController.userSettings.soundVol != 100)
            chMusic = StartCoroutine(ChangeMusic(now, next));
    }
    
    public void StopPlaying()
    {
        keepFadingIn = false;
        keepFadingOut = false;
        audioSource.Stop();
        if (co != null)
            StopCoroutine(co);  //fadein
        if (co2 != null)
            StopCoroutine(co2); //fadeout?
        if (co3 != null)
            StopCoroutine(co3);
        if (chMusic != null)
            StopCoroutine(chMusic);
    }
    
    public void StartPlaying(int track)
    {
        if(GameController.gameController.userSettings.soundVol != 100) // 100-0 , 200- 100vol lvl xD
            co = StartCoroutine(FadeIn(track));
    }

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();      
	}
    
	// Update is called once per frame
	void Update () {
        
    }
    // music transition 
    IEnumerator FadeIn(int track)
    {
        keepFadingIn = true;
        keepFadingOut = false;

        trackVolume = 0;

        audioSource.clip = trk[track];
        audioSource.volume = trackVolume;
        audioSource.Play();

        float audioVolume = trackVolume;
        maxVolume = (float)(GameController.gameController.userSettings.soundVol - 100)/100f; // slider volume 100-200

        while(trackVolume < maxVolume && keepFadingIn)
        {
            audioVolume += speed;
            trackVolume = audioVolume;
            audioSource.volume = trackVolume;
            yield return new WaitForSeconds(0.1f);
        }
        

    }

    IEnumerator FadeOut(int track)
    {
        keepFadingIn = false;
        keepFadingOut = true;

        float audioVolume = trackVolume;

        while (trackVolume >=  speed && keepFadingOut)
        {
            audioVolume -= speed;
            trackVolume = audioVolume;
            audioSource.volume = trackVolume;
            yield return new WaitForSeconds(0.1f);
        }

    }

    IEnumerator ChangeMusic(int now,int next)
    {

        co3 = StartCoroutine(FadeOut(now));

        while (audioSource.volume >= speed)
        {
            yield return new WaitForSeconds(0.01f);
        }
        audioSource.Stop();
        co2 = StartCoroutine(FadeIn(next));
    }


}
