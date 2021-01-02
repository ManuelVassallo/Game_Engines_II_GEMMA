using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{

    private Animator buttonAnim;
    private AudioSource buttonHoverNoise;
    private AudioSource buttonClickNoise;

    public void Start()
    {
        

    }

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

    public void playButtonClickSound()
    {
        buttonClickNoise = GameObject.FindGameObjectWithTag("buttonClickSound").GetComponent<AudioSource>();

        buttonClickNoise.Play();

    }

    public void scoreBackAnim()
    {
        buttonAnim = GameObject.FindGameObjectWithTag("buttonBack").GetComponent<Animator>();
        buttonHoverNoise = GameObject.FindGameObjectWithTag("buttonHoverSound").GetComponent<AudioSource>();

        buttonAnim.Play("scoreBackAnim");
        buttonHoverNoise.Play();

    }

    public void scoreBackAnim2()
    {
        buttonAnim = GameObject.FindGameObjectWithTag("buttonBack").GetComponent<Animator>();
        buttonAnim.Play("scoreBackAnim2");
        buttonHoverNoise = GameObject.FindGameObjectWithTag("buttonHoverSound").GetComponent<AudioSource>();
        buttonHoverNoise.Play();
    }

    public void scoreMenuButtonAnim()
    {
        buttonAnim = GameObject.FindGameObjectWithTag("menuButton").GetComponent<Animator>();
        buttonHoverNoise = GameObject.FindGameObjectWithTag("buttonHoverSound").GetComponent<AudioSource>();

        buttonAnim.Play("scoreMenuButtonAnim");
        buttonHoverNoise.Play();

    }

    public void scoreMenuButtonAnim2()
    {
        buttonAnim = GameObject.FindGameObjectWithTag("menuButton").GetComponent<Animator>();
        buttonAnim.Play("scoreMenuButtonAnim2");
        buttonHoverNoise = GameObject.FindGameObjectWithTag("buttonHoverSound").GetComponent<AudioSource>();
        buttonHoverNoise.Play();
    }

    public void playAgainButton()
    {
        buttonAnim = GameObject.FindGameObjectWithTag("againButton").GetComponent<Animator>();
        buttonHoverNoise = GameObject.FindGameObjectWithTag("buttonHoverSound").GetComponent<AudioSource>();

        buttonAnim.Play("againButtonAnim");
        buttonHoverNoise.Play();

    }

    public void playAgainButton2()
    {
        buttonAnim = GameObject.FindGameObjectWithTag("againButton").GetComponent<Animator>();
        buttonAnim.Play("againButtonAnim2");
        buttonHoverNoise = GameObject.FindGameObjectWithTag("buttonHoverSound").GetComponent<AudioSource>();
        buttonHoverNoise.Play();
    }

    public void playNextButtonAnim()
    {
        buttonAnim = GameObject.FindGameObjectWithTag("nextButton").GetComponent<Animator>();
        buttonHoverNoise = GameObject.FindGameObjectWithTag("buttonHoverSound").GetComponent<AudioSource>();

        buttonAnim.Play("nextButtonAnim");
        buttonHoverNoise.Play();

    }

    public void playNextButtonAnim2()
    {
        buttonAnim = GameObject.FindGameObjectWithTag("nextButton").GetComponent<Animator>();
        buttonAnim.Play("nextButtonAnim2");
        buttonHoverNoise = GameObject.FindGameObjectWithTag("buttonHoverSound").GetComponent<AudioSource>();
        buttonHoverNoise.Play();
    }

    public void playBackButtonAnim()
    {
        buttonAnim = GameObject.FindGameObjectWithTag("buttonBack").GetComponent<Animator>();
        buttonHoverNoise = GameObject.FindGameObjectWithTag("buttonHoverSound").GetComponent<AudioSource>();

        buttonAnim.Play("backButtonAnim");
        buttonHoverNoise.Play();

    }

    public void playBackButtonAnim2()
    {
        buttonAnim = GameObject.FindGameObjectWithTag("buttonBack").GetComponent<Animator>();
        buttonAnim.Play("backButtonAnim2");
        buttonHoverNoise = GameObject.FindGameObjectWithTag("buttonHoverSound").GetComponent<AudioSource>();
        buttonHoverNoise.Play();
    }

    public void playBackButtonAnim3()
    {
        buttonAnim = GameObject.FindGameObjectWithTag("buttonBack").GetComponent<Animator>();
        buttonHoverNoise = GameObject.FindGameObjectWithTag("buttonHoverSound").GetComponent<AudioSource>();

        buttonAnim.Play("backButtonAnim3");
        buttonHoverNoise.Play();

    }

    public void playBackButtonAnim4()
    {
        buttonAnim = GameObject.FindGameObjectWithTag("buttonBack").GetComponent<Animator>();
        buttonAnim.Play("backButtonAnim4");
        buttonHoverNoise = GameObject.FindGameObjectWithTag("buttonHoverSound").GetComponent<AudioSource>();
        buttonHoverNoise.Play();
    }

    public void playButtonAnim()
    {
        buttonAnim = GameObject.FindGameObjectWithTag("buttonHowTo").GetComponent<Animator>();
        buttonHoverNoise = GameObject.FindGameObjectWithTag("buttonHoverSound").GetComponent<AudioSource>();

        buttonAnim.Play("buttonAnim");
        buttonHoverNoise.Play();

    }

    public void playButtonAnim2()
    {
        buttonAnim = GameObject.FindGameObjectWithTag("buttonHowTo").GetComponent<Animator>();
        buttonAnim.Play("buttonAnim2");
        buttonHoverNoise = GameObject.FindGameObjectWithTag("buttonHoverSound").GetComponent<AudioSource>();
        buttonHoverNoise.Play();
    }

    public void playButtonAnim3()
    {
        buttonAnim = GameObject.FindGameObjectWithTag("buttonHelp").GetComponent<Animator>();
        buttonAnim.Play("buttonAnim");
        buttonHoverNoise = GameObject.FindGameObjectWithTag("buttonHoverSound").GetComponent<AudioSource>();
        buttonHoverNoise.Play();

    }

    public void playButtonAnim4()
    {
        buttonAnim = GameObject.FindGameObjectWithTag("buttonHelp").GetComponent<Animator>();
        buttonAnim.Play("buttonAnim2");
        buttonHoverNoise = GameObject.FindGameObjectWithTag("buttonHoverSound").GetComponent<AudioSource>();
        buttonHoverNoise.Play();

    }

    public void playButtonAnim5()
    {
        buttonAnim = GameObject.FindGameObjectWithTag("buttonPlay").GetComponent<Animator>();
        buttonAnim.Play("buttonAnim");
        buttonHoverNoise = GameObject.FindGameObjectWithTag("buttonHoverSound").GetComponent<AudioSource>();
        buttonHoverNoise.Play();

    }

    public void playButtonAnim6()
    {
        buttonAnim = GameObject.FindGameObjectWithTag("buttonPlay").GetComponent<Animator>();
        buttonAnim.Play("buttonAnim2");
        buttonHoverNoise = GameObject.FindGameObjectWithTag("buttonHoverSound").GetComponent<AudioSource>();
        buttonHoverNoise.Play();

    }
}
