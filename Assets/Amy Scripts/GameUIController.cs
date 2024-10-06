using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIController : MonoBehaviour
{
    public static GameUIController instance;

    public GameObject titleScreen;
    public GameObject instructionsScreen;
    public GameObject mainGame;
    public GameObject mainUIScreen;
    public GameObject GameOverScreen;

    public int totalLives; // set in editor, shouldn't change
    private int numLivesStat;
    private int numSlimesClearedStat;
    private float startTime; // set at beginning, shouldn't change
    private float timeStat;
    private int highScoreStat;

    // Start is called before the first frame update
    void Start()
    {
        // setup
        GameUIController.instance = this;
        highScoreStat = 0;

        // play game
        ShowTitleScreen();
    }

    /* ---- STATUS ---- */
    public void EditSlimesCleared(int slimesToAdd)
    {
        // edit data
        numSlimesClearedStat += slimesToAdd;

        // edit UI
        TextHelper.instance.SetSlimesClearedText(numSlimesClearedStat);
    }
    public void EditNumLives(int livesToAdd)
    {
        // edit data
        numLivesStat += livesToAdd;

        // edit UI
        TextHelper.instance.SetLivesText(numLivesStat);
    }
    public bool IsGameOver()
    {
        return numLivesStat <= 0;
    }

    /* ---- SCREENS ---- */
    void HideAllScreensHelper()
    {
        titleScreen.gameObject.SetActive(false);
        instructionsScreen.gameObject.SetActive(false);
        mainGame.gameObject.SetActive(false);
        mainUIScreen.gameObject.SetActive(false);
        GameOverScreen.gameObject.SetActive(false);
    }
    public void ShowTitleScreen()
    {
        HideAllScreensHelper();
        titleScreen.gameObject.SetActive(true);
    }
    public void ShowInstructionsScreen()
    {
        HideAllScreensHelper();
        instructionsScreen.gameObject.SetActive(true);
    }
    public void ShowMainScreens()
    {
        // edit data
        startTime = Time.time;
        numLivesStat = totalLives;
        numSlimesClearedStat = 0;
        timeStat = 0;

        // edit UI
        TextHelper.instance.SetLivesText(numLivesStat);
        TextHelper.instance.SetSlimesClearedText(numSlimesClearedStat);
        TextHelper.instance.SetTimeText(timeStat);

        // play
        HideAllScreensHelper();
        mainGame.gameObject.SetActive(true);
        mainUIScreen.gameObject.SetActive(true);
    }
    public void ShowGameOverScreen()
    {
        // edit data
        if (numSlimesClearedStat > highScoreStat)
        {
            highScoreStat = numSlimesClearedStat;
        }

        // edit UI
        TextHelper.instance.SetTimeText(timeStat);
        TextHelper.instance.SetSlimesClearedText(numSlimesClearedStat);
        TextHelper.instance.SetHighScoreText(highScoreStat);

        // play
        HideAllScreensHelper();
        GameOverScreen.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsGameOver())
        {
            // edit data
            timeStat = Time.time - startTime;

            // edit UI
            TextHelper.instance.SetTimeText(timeStat);
        }
    }
}
