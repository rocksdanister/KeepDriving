using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialText : MonoBehaviour {

    public LoadingScreenControl loading;
    public GameObject loadingScr;
    public Text btn;

    public float delay = 0.1f;
    public float instructionDelay = 0.2f;
    public float delayBetweenDialog = 2f;
    public string fullText;
    public string fullText2;
    public string fullText3;
    private string currentText = "";


	// Use this for initialization
	void Start () {
        fullText = fullText.Replace("NEWLINE", "\n"); // \n not working in Unity Inspector
        fullText2 = fullText2.Replace("NEWLINE", "\n");
        fullText3 = fullText3.Replace("NEWLINE", "\n");
        StartCoroutine(Showtest());
	}

    IEnumerator Showtest()
    {
        for(int i=0;i<=fullText.Length;i++)
        {
            currentText = fullText.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(delayBetweenDialog);

        for (int i = 0; i <= fullText2.Length; i++)
        {
            currentText = fullText2.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(delayBetweenDialog);

        for (int i = 0; i <= fullText3.Length; i++)
        {
            currentText = fullText3.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(instructionDelay);
        }
        btn.text = "Continue";
        yield return new WaitForSeconds(delayBetweenDialog);


        //.. cutscene over Save
        GameController.gameController.userSettings.firstRun = false;
        GameController.gameController.Save();
        
       
    }

    public void SkipButton()
    {
        //.. cutscene over Save
        GameController.gameController.userSettings.firstRun = false;
        GameController.gameController.Save();

        // loading screen
        loadingScr.SetActive(true);
        loading.LoadLvlStart();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
