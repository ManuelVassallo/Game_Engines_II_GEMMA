﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class playerScore : MonoBehaviour
{
    private Text scoreText; //declaring score and chances text
    private Text chancesText; //declaring chances text

    private int score = 0;
    private int chances = 3; //variables for the score and chances

    public GameObject bonusLevelSpawner; //the game objects initiated
    public GameObject regularSpawner;
    public GameObject clockScripterObject;

    private bool spawningCount; //booleans for swapping of phases
    private bool spawnAgain;
    private bool spawnBonusAgain;


    public GameObject timeClockText; //stopwatch initiated

    public float totalTime;

    public int clockSwitch = 0;

    public GameObject clockCountdownObject;

    public Text text;

    private float minutes;
    private float seconds; //floats for minutes and seconds


    void Awake()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>(); //get the score and chances objects
        scoreText.text = "0";

        chancesText = GameObject.Find("chancesText").GetComponent<Text>();
        chancesText.text = chances.ToString();
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Bomb") //if player collides with bomb, destroy bomb and lose chance
        {
            Destroy(target.gameObject);       
            loseChance();

        }

        if(target.tag == "Fruit") //if player collides with a need, destroy need and give a point and check if player reached a specific amount of points to enter bonus phase
        {
            Destroy(target.gameObject);
            score++;
            checkBonusLevel();
            scoreText.text = score.ToString();
            
        }

        if (target.tag == "Want") //if player collides with a want, more points is awarded
        {
            Destroy(target.gameObject);
            score = score + 2;
            scoreText.text = score.ToString();
            
        }

        if (target.tag == "Chance") //if player collides with a chance, recover a chance
        {
            Destroy(target.gameObject);
            if (chances < 3)
            {
                chances = chances + 1;
                chancesText.text = chances.ToString();

            }

            else
            {
                chancesText.text = chances.ToString();
            }
            

        }
    }

    void endGame()
    {
        SceneManager.LoadScene("ScoreScreen"); //this will run when the player loses chances
    }

    void checkBonusLevel()
    {
        if (score == 5)
        {
            StartCoroutine(changeToBonusLevel(5f));  //run coroutine to switch to bonus phase if certain points is reached    
        }
    }


    void loseChance() //lose a chance variable and update the text
    {
        chances = chances - 1;
        chancesText.text = chances.ToString();

        if (chances == 0)
        {
            endGame(); //end the game if 0
        }       
    }

    IEnumerator changeToBonusLevel(float time) //ienumerator to change to bonus phase
    {
        spawnerBonus.spawnBonusAgain = true; //this will grab from another script and change it to true to start the bonus spawner
        Spawner.stopSpawning = true; //this will tell the main spawner to stop spawning by changing variable in that script

        timeClockText.SetActive(true); //updating the tick tock clock
        clockSwitch = 1; //switching

        yield return new WaitForSeconds(10); //for 10 seconds the bonus phase will last

        Spawner.spawnAgain = true; //this will tell the regular spawner to start spawning again
        spawnerBonus.stopSpawning = true; //this will tell the bonus spawner to stop spawning in another script

        clockSwitch = 0; //switching
        timeClockText.SetActive(false);


        totalTime = 10; //resetting the tick tock clock
    }
    void Update()
    {
        if (clockSwitch == 0) //ticking down the stopwatch on update
        {
            
        }

        else if (clockSwitch == 1)
        {
            totalTime -= Time.deltaTime;

            minutes = (int)(totalTime / 60);
            seconds = (int)(totalTime % 60);

            text.text = minutes.ToString() + " : " + seconds.ToString();
        }
    }
}
