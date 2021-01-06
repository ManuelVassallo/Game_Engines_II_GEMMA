using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{

    private Animator buttonAnim;
    private AudioSource buttonHoverNoise; //getting sources
    private AudioSource buttonClickNoise;

    public void Start()
    {
        

    }

    public void runGame()
    {
        Spawner.spawnAgain = true; //resetting the game started and spawn again variables to reset the game properly
        Spawner.gameStarted = false;
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

    public void playButtonClickSound()
    {
        buttonClickNoise = GameObject.FindGameObjectWithTag("buttonClickSound").GetComponent<AudioSource>(); //click noise on click

        buttonClickNoise.Play();

    }

    public void scoreBackAnim()
    {
        buttonAnim = GameObject.FindGameObjectWithTag("buttonBack").GetComponent<Animator>(); //getting the game object button and playing the animation and sound on hover and out hover
        buttonHoverNoise = GameObject.FindGameObjectWithTag("buttonHoverSound").GetComponent<AudioSource>();

        buttonAnim.Play("scoreBackAnim");
        buttonHoverNoise.Play();

    }

    public void scoreBackAnim2()
    {
        buttonAnim = GameObject.FindGameObjectWithTag("buttonBack").GetComponent<Animator>();//getting the game object button and playing the animation and sound on hover and out hover
        buttonAnim.Play("scoreBackAnim2");
        buttonHoverNoise = GameObject.FindGameObjectWithTag("buttonHoverSound").GetComponent<AudioSource>();
        buttonHoverNoise.Play();
    }

    public void scoreMenuButtonAnim()
    {
        buttonAnim = GameObject.FindGameObjectWithTag("menuButton").GetComponent<Animator>();//getting the game object button and playing the animation and sound on hover and out hover
        buttonHoverNoise = GameObject.FindGameObjectWithTag("buttonHoverSound").GetComponent<AudioSource>();

        buttonAnim.Play("scoreMenuButtonAnim");
        buttonHoverNoise.Play();

    }

    public void scoreMenuButtonAnim2()
    {
        buttonAnim = GameObject.FindGameObjectWithTag("menuButton").GetComponent<Animator>();//getting the game object button and playing the animation and sound on hover and out hover
        buttonAnim.Play("scoreMenuButtonAnim2");
        buttonHoverNoise = GameObject.FindGameObjectWithTag("buttonHoverSound").GetComponent<AudioSource>();
        buttonHoverNoise.Play();
    }

    public void playAgainButton()
    {
        buttonAnim = GameObject.FindGameObjectWithTag("againButton").GetComponent<Animator>();//getting the game object button and playing the animation and sound on hover and out hover
        buttonHoverNoise = GameObject.FindGameObjectWithTag("buttonHoverSound").GetComponent<AudioSource>();

        buttonAnim.Play("againButtonAnim");
        buttonHoverNoise.Play();

    }

    public void playAgainButton2()
    {
        buttonAnim = GameObject.FindGameObjectWithTag("againButton").GetComponent<Animator>();//getting the game object button and playing the animation and sound on hover and out hover
        buttonAnim.Play("againButtonAnim2");
        buttonHoverNoise = GameObject.FindGameObjectWithTag("buttonHoverSound").GetComponent<AudioSource>();
        buttonHoverNoise.Play();
    }

    public void playNextButtonAnim()
    {
        buttonAnim = GameObject.FindGameObjectWithTag("nextButton").GetComponent<Animator>();//getting the game object button and playing the animation and sound on hover and out hover
        buttonHoverNoise = GameObject.FindGameObjectWithTag("buttonHoverSound").GetComponent<AudioSource>();

        buttonAnim.Play("nextButtonAnim");
        buttonHoverNoise.Play();

    }

    public void playNextButtonAnim2()
    {
        buttonAnim = GameObject.FindGameObjectWithTag("nextButton").GetComponent<Animator>();//getting the game object button and playing the animation and sound on hover and out hover
        buttonAnim.Play("nextButtonAnim2");
        buttonHoverNoise = GameObject.FindGameObjectWithTag("buttonHoverSound").GetComponent<AudioSource>();
        buttonHoverNoise.Play();
    }

    public void playBackButtonAnim()
    {
        buttonAnim = GameObject.FindGameObjectWithTag("buttonBack").GetComponent<Animator>();//getting the game object button and playing the animation and sound on hover and out hover
        buttonHoverNoise = GameObject.FindGameObjectWithTag("buttonHoverSound").GetComponent<AudioSource>();

        buttonAnim.Play("backButtonAnim");
        buttonHoverNoise.Play();

    }

    public void playBackButtonAnim2()
    {
        buttonAnim = GameObject.FindGameObjectWithTag("buttonBack").GetComponent<Animator>();//getting the game object button and playing the animation and sound on hover and out hover
        buttonAnim.Play("backButtonAnim2");
        buttonHoverNoise = GameObject.FindGameObjectWithTag("buttonHoverSound").GetComponent<AudioSource>();
        buttonHoverNoise.Play();
    }

    public void playBackButtonAnim3()
    {
        buttonAnim = GameObject.FindGameObjectWithTag("buttonBack").GetComponent<Animator>();//getting the game object button and playing the animation and sound on hover and out hover
        buttonHoverNoise = GameObject.FindGameObjectWithTag("buttonHoverSound").GetComponent<AudioSource>();

        buttonAnim.Play("backButtonAnim3");
        buttonHoverNoise.Play();

    }

    public void playBackButtonAnim4()
    {
        buttonAnim = GameObject.FindGameObjectWithTag("buttonBack").GetComponent<Animator>();//getting the game object button and playing the animation and sound on hover and out hover
        buttonAnim.Play("backButtonAnim4");
        buttonHoverNoise = GameObject.FindGameObjectWithTag("buttonHoverSound").GetComponent<AudioSource>();
        buttonHoverNoise.Play();
    }

    public void playButtonAnim()
    {
        buttonAnim = GameObject.FindGameObjectWithTag("buttonHowTo").GetComponent<Animator>();//getting the game object button and playing the animation and sound on hover and out hover
        buttonHoverNoise = GameObject.FindGameObjectWithTag("buttonHoverSound").GetComponent<AudioSource>();

        buttonAnim.Play("buttonAnim");
        buttonHoverNoise.Play();

    }

    public void playButtonAnim2()
    {
        buttonAnim = GameObject.FindGameObjectWithTag("buttonHowTo").GetComponent<Animator>();//getting the game object button and playing the animation and sound on hover and out hover
        buttonAnim.Play("buttonAnim2");
        buttonHoverNoise = GameObject.FindGameObjectWithTag("buttonHoverSound").GetComponent<AudioSource>();
        buttonHoverNoise.Play();
    }

    public void playButtonAnim3()
    {
        buttonAnim = GameObject.FindGameObjectWithTag("buttonHelp").GetComponent<Animator>();//getting the game object button and playing the animation and sound on hover and out hover
        buttonAnim.Play("buttonAnim");
        buttonHoverNoise = GameObject.FindGameObjectWithTag("buttonHoverSound").GetComponent<AudioSource>();
        buttonHoverNoise.Play();

    }

    public void playButtonAnim4()
    {
        buttonAnim = GameObject.FindGameObjectWithTag("buttonHelp").GetComponent<Animator>();//getting the game object button and playing the animation and sound on hover and out hover
        buttonAnim.Play("buttonAnim2");
        buttonHoverNoise = GameObject.FindGameObjectWithTag("buttonHoverSound").GetComponent<AudioSource>();
        buttonHoverNoise.Play();

    }

    public void playButtonAnim5()
    {
        buttonAnim = GameObject.FindGameObjectWithTag("buttonPlay").GetComponent<Animator>();//getting the game object button and playing the animation and sound on hover and out hover
        buttonAnim.Play("buttonAnim");
        buttonHoverNoise = GameObject.FindGameObjectWithTag("buttonHoverSound").GetComponent<AudioSource>();
        buttonHoverNoise.Play();

    }

    public void playButtonAnim6()
    {
        buttonAnim = GameObject.FindGameObjectWithTag("buttonPlay").GetComponent<Animator>();//getting the game object button and playing the animation and sound on hover and out hover
        buttonAnim.Play("buttonAnim2");
        buttonHoverNoise = GameObject.FindGameObjectWithTag("buttonHoverSound").GetComponent<AudioSource>();
        buttonHoverNoise.Play();

    }
}
