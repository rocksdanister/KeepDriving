    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

    Text text;
    private float score;

    //avg score calculator
    int avg, no;

    public SceneController sceneController;

    void Start()
    {
        text = GetComponent<Text>();
        avg = GameController.gameController.userSettings.var2;
        no = GameController.gameController.userSettings.var3;
    }

    public void UpdateScore()
    {
        
            GameController.gameController.Load();
            score = sceneController.elapsedTime0;
            if (no > 9) // avg of 10.
                no = 0;

            if (Mathf.CeilToInt(score) > GameController.gameController.userSettings.highScore1)
            {
                GameController.gameController.userSettings.highScore1 = Mathf.CeilToInt(score);
                //avg calculation, avg for last 10 games.
                avg = (avg * no + GameController.gameController.userSettings.highScore1) / (no + 1);
                no++;
                GameController.gameController.userSettings.var2 = avg;
                GameController.gameController.userSettings.var3 = no;
                GameController.gameController.Save();      // saving new avg.
                text.text = "NEW HIGH SCORE: " + Mathf.CeilToInt(score) +"\n"+ "AVG SCORE: " + GameController.gameController.userSettings.var2;
            }
            else
            {
                avg = (avg * no + Mathf.CeilToInt(score) ) / (no + 1);
                no++;
                GameController.gameController.userSettings.var2 = avg;
                GameController.gameController.userSettings.var3 = no;
                GameController.gameController.Save();
                text.text = "SCORE: " + Mathf.CeilToInt(score) + "\n" + "HIGH SCORE: " + GameController.gameController.userSettings.highScore1 +"\n" + "AVG SCORE: " + GameController.gameController.userSettings.var2;
            }
        
    }
    // Update is called once per frame

    void Update () {


	}
}
