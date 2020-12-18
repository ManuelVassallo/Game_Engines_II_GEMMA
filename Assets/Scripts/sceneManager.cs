using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    //All of these codes is basically running each scene by click

    public void runGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void runHowToPlay()
    {
        SceneManager.LoadScene("howToPlay");
    }

    public void runMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void runExplainMenu()
    {
        SceneManager.LoadScene("ExplanationStart");
    }

    public void runExplainEnd()
    {
        SceneManager.LoadScene("ExplanationEnd");
    }

    public void runScoreScreen()
    {
        SceneManager.LoadScene("ScoreScreen");
    }
}
