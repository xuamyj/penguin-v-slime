using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIController : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject instructionsScreen;
    public GameObject mainGame;
    public GameObject mainUIScreen;
    public GameObject GameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        ShowTitleScreen();
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
        HideAllScreensHelper();
        mainGame.gameObject.SetActive(true);
        mainUIScreen.gameObject.SetActive(true);
    }
    public void ShowGameOverScreen()
    {
        HideAllScreensHelper();
        GameOverScreen.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
