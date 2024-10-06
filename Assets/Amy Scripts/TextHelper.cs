using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextHelper : MonoBehaviour
{
    public static TextHelper instance;

    public TextMeshProUGUI mainUISlimesCleared;
    public TextMeshProUGUI mainUITime;
    public TextMeshProUGUI mainUILives;
    public TextMeshProUGUI gameOverTimePlayed;
    public TextMeshProUGUI gameOverSlimesCleared;
    public TextMeshProUGUI gameOverHighScore;

    // Start is called before the first frame update
    void Start()
    {
        TextHelper.instance = this;
    }

    // text adding functions
    public void SetSlimesClearedText(int num)
    {
        mainUISlimesCleared.text = "Slimes Cleared: " + num;
        gameOverSlimesCleared.text = "Slimes Cleared: " + num;
    }
    public void SetTimeText(float num)
    {
        int hr = (int)num / 3600;
        int min = (int)num / 60 % 60;
        int sec = (int)num % 60;

        string timeStr = "";
        if (hr != 0) // gotta show hour
        {
            timeStr = "" + hr + ":" + min.ToString("00") + ":" + sec.ToString("00");
        }
        else if (min != 0) // gotta show min
        {
            timeStr = "" + min + ":" + sec.ToString("00");
        }
        else // just show sec
        {
            timeStr = "" + sec;
        }

        mainUITime.text = "Time: " + timeStr;
        gameOverTimePlayed.text = "Time Played: " + timeStr;
    }
    public void SetLivesText(int num)
    {
        mainUILives.text = "Lives: " + num;
    }
    public void SetHighScoreText(int num)
    {
        gameOverHighScore.text = "High Score: " + num;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
