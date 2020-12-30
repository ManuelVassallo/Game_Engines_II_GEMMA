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

    public static int score = 0;
    private int chances = 3; //variables for the score and chances

    public GameObject bonusLevelSpawner; //the game objects initiated
    public GameObject regularSpawner;
    public GameObject clockScripterObject;

    public GameObject popUpPrefab1;
    public GameObject popUpPrefab2;
    public GameObject popUpPrefab3;
    public GameObject popUpPrefab4;
    public GameObject popUpPrefab5;
    public GameObject popUpPrefab6;

    public Image goldBorder;

    private bool spawningCount; //booleans for swapping of phases
    private bool spawnAgain;
    private bool spawnBonusAgain;

    private bool paused = false;


    public GameObject timeClockText; //stopwatch initiated

    public float totalTime;

    public int clockSwitch = 0;

    public GameObject clockCountdownObject;

    public GameObject chipHat1;
    public GameObject chipHat2;
    public GameObject chipHat3;

    public GameObject pauseText;

    public Text text;

    private float minutes;
    private float seconds; //floats for minutes and seconds


    void Awake()
    {
        goldBorder.canvasRenderer.SetAlpha(0.0f);

        scoreText = GameObject.Find("ScoreText").GetComponent<Text>(); //get the score and chances objects
        scoreText.text = "0";

        
    }

    private void Start()
    {
       
    }

    void fadeInFunction()
    {
        StartCoroutine(fadeInFadeOut(1f));   
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Bomb") //if player collides with bomb, destroy bomb and lose chance
        {
            Destroy(target.gameObject);       
            loseChance();

        }

        if(target.tag == "Need") //if player collides with a need, destroy need and give a point and check if player reached a specific amount of points to enter bonus phase
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
            if (chances == 2)
            {
                chances = chances + 1;
                chipHat3.gameObject.SetActive(true);
            }

            else if(chances == 1)
            {
                chances = chances + 1;
                chipHat2.gameObject.SetActive(true);
            }

            else
            {
                
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
            StartCoroutine(changeToBonusLevel1(1f));  //run coroutine to switch to bonus phase if certain points is reached    
            popUpPrefab1.gameObject.SetActive(true);
        }

        else if (score == 25)
        {
            StartCoroutine(changeToBonusLevel2(1f));  //run coroutine to switch to bonus phase if certain points is reached  
            popUpPrefab2.gameObject.SetActive(true);
        }

        else if (score == 70)
        {
            StartCoroutine(changeToBonusLevel3(1f));  //run coroutine to switch to bonus phase if certain points is reached 
            popUpPrefab3.gameObject.SetActive(true);
        }

        else if (score == 120)
        {
            StartCoroutine(changeToBonusLevel4(1f));  //run coroutine to switch to bonus phase if certain points is reached 
            popUpPrefab1.gameObject.SetActive(true);
        }

        else if (score == 175)
        {
            StartCoroutine(changeToBonusLevel5(1f));  //run coroutine to switch to bonus phase if certain points is reached  
            popUpPrefab2.gameObject.SetActive(true);
        }

        else if (score == 250)
        {
            StartCoroutine(changeToBonusLevel6(1f));  //run coroutine to switch to bonus phase if certain points is reached 
            popUpPrefab3.gameObject.SetActive(true);
        }

        else if (score == 320)
        {
            StartCoroutine(changeToBonusLevel7(1f));  //run coroutine to switch to bonus phase if certain points is reached  
            popUpPrefab1.gameObject.SetActive(true);
        }

        else if (score == 400)
        {
            StartCoroutine(changeToBonusLevel8(1f));  //run coroutine to switch to bonus phase if certain points is reached  
            popUpPrefab2.gameObject.SetActive(true);
        }

        else if (score == 500)
        {
            StartCoroutine(changeToBonusLevel9(1f));  //run coroutine to switch to bonus phase if certain points is reached  
            popUpPrefab3.gameObject.SetActive(true);
        }
    }


    void loseChance() //lose a chance variable and update the text
    {
        chances = chances - 1;
        if (chances == 2)
        {
            chipHat3.gameObject.SetActive(false);
        }

        else if (chances == 1)
        {
            chipHat2.gameObject.SetActive(false);
        }

        else if (chances == 0)
        {
            endGame(); //end the game if 0
        }         
    }

    

    IEnumerator fadeInFadeOut(float time) //ienumerator to change to bonus phase
    {
        goldBorder.CrossFadeAlpha(0.75f, 1, false);
        yield return new WaitForSeconds(1); 
        goldBorder.CrossFadeAlpha(0f, 1, false);

        yield return new WaitForSeconds(1); //for 2 seconds the bonus phase will last
        goldBorder.CrossFadeAlpha(0.75f, 1, false);
        yield return new WaitForSeconds(1); //for 2 seconds the bonus phase will last
        goldBorder.CrossFadeAlpha(0f, 1, false);

        yield return new WaitForSeconds(1); //for 2 seconds the bonus phase will last
        goldBorder.CrossFadeAlpha(0.75f, 1, false);
        yield return new WaitForSeconds(1); //for 2 seconds the bonus phase will last
        goldBorder.CrossFadeAlpha(0f, 1, false);

        yield return new WaitForSeconds(1); //for 2 seconds the bonus phase will last
        goldBorder.CrossFadeAlpha(0.75f, 1, false);
        yield return new WaitForSeconds(1); //for 2 seconds the bonus phase will last
        goldBorder.CrossFadeAlpha(0f, 1, false);

        yield return new WaitForSeconds(1); //for 2 seconds the bonus phase will last
        goldBorder.CrossFadeAlpha(0.75f, 1, false);
        yield return new WaitForSeconds(1); //for 2 seconds the bonus phase will last
        goldBorder.CrossFadeAlpha(0f, 1, false);
    }

    IEnumerator changeToBonusLevel1(float time) //ienumerator to change to bonus phase
    {
        Spawner.stopSpawning = true; //this will tell the main spawner to stop spawning by changing variable in that script

        yield return new WaitForSeconds(2f); //for 3 seconds the bonus phase will last
        fadeInFunction();

        spawnerBonus.spawnBonusAgain = true; //this will grab from another script and change it to true to start the bonus spawner
        
        timeClockText.SetActive(true); //updating the tick tock clock
        clockSwitch = 1; //switching

        yield return new WaitForSeconds(10); //for 10 seconds the bonus phase will last

        spawnerBonus.stopSpawning = true; //this will tell the bonus spawner to stop spawning in another script

        popUpPrefab1.gameObject.SetActive(false);
        popUpPrefab4.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f); //for 3 seconds the bonus phase will last  

        Spawner.spawnAgain = true; //this will tell the regular spawner to start spawning again
        Spawner2.spawnAgain= true;      

        clockSwitch = 0; //switching
        timeClockText.SetActive(false);


        totalTime = 10; //resetting the tick tock clock

          
    }

    IEnumerator changeToBonusLevel2(float time) //ienumerator to change to bonus phase
    {
        Spawner.stopSpawning = true; //this will tell the main spawner to stop spawning by changing variable in that script
        Spawner2.stopSpawning = true;

        yield return new WaitForSeconds(2f); //for 3 seconds the bonus phase will last
        fadeInFunction();

        spawnerBonus.spawnBonusAgain = true; //this will grab from another script and change it to true to start the bonus spawner
        spawnerBonus2.spawnBonusAgain = true;

        timeClockText.SetActive(true); //updating the tick tock clock
        clockSwitch = 1; //switching

        yield return new WaitForSeconds(10); //for 10 seconds the bonus phase will last

        spawnerBonus.stopSpawning = true; //this will tell the bonus spawner to stop spawning in another script
        spawnerBonus2.stopSpawning = true; //this will tell the bonus spawner to stop spawning in another script

        popUpPrefab2.gameObject.SetActive(false);
        popUpPrefab5.gameObject.SetActive(true);

        popUpPrefab4.gameObject.SetActive(false);

        yield return new WaitForSeconds(2f); //for 3 seconds the bonus phase will last  

        Spawner.spawnAgain = true; //this will tell the regular spawner to start spawning again
        Spawner2.spawnAgain = true; 
        
        bombSpawner.spawnAgain = true;

        clockSwitch = 0; //switching
        timeClockText.SetActive(false);


        totalTime = 10; //resetting the tick tock clock
    }

    IEnumerator changeToBonusLevel3(float time) //ienumerator to change to bonus phase
    {
        Spawner.stopSpawning = true; //this will tell the main spawner to stop spawning by changing variable in that script
        Spawner2.stopSpawning = true;
        bombSpawner.stopSpawning = true;

        yield return new WaitForSeconds(2f); //for 3 seconds the bonus phase will last
        fadeInFunction();

        spawnerBonus.spawnBonusAgain = true; //this will grab from another script and change it to true to start the bonus spawner
        spawnerBonus2.spawnBonusAgain = true;

        
        hatSpawner.spawnAgain = true;

        timeClockText.SetActive(true); //updating the tick tock clock
        clockSwitch = 1; //switching

        yield return new WaitForSeconds(10); //for 10 seconds the bonus phase will last

        spawnerBonus.stopSpawning = true; //this will tell the bonus spawner to stop spawning in another script
        spawnerBonus2.stopSpawning = true; //this will tell the bonus spawner to stop spawning in another script

        popUpPrefab3.gameObject.SetActive(false);
        popUpPrefab6.gameObject.SetActive(true);

        popUpPrefab5.gameObject.SetActive(false);

        yield return new WaitForSeconds(2f); //for 3 seconds the bonus phase will last  

        Spawner.spawnAgain = true; //this will tell the regular spawner to start spawning again
        Spawner2.spawnAgain = true;
        Spawner3.spawnAgain = true; 

        bombSpawner.spawnAgain = true;

        clockSwitch = 0; //switching
        timeClockText.SetActive(false);


        totalTime = 10; //resetting the tick tock clock
    }

    IEnumerator changeToBonusLevel4(float time) //ienumerator to change to bonus phase
    {
        Spawner.stopSpawning = true; //this will tell the main spawner to stop spawning by changing variable in that script
        Spawner2.stopSpawning = true;
        Spawner3.stopSpawning = true;
        bombSpawner.stopSpawning = true;

        yield return new WaitForSeconds(2f); //for 3 seconds the bonus phase will last
        fadeInFunction();

        spawnerBonus.spawnBonusAgain = true; //this will grab from another script and change it to true to start the bonus spawner
        spawnerBonus2.spawnBonusAgain = true;
        spawnerBonus3.spawnBonusAgain = true;

        

        timeClockText.SetActive(true); //updating the tick tock clock
        clockSwitch = 1; //switching

        yield return new WaitForSeconds(10); //for 10 seconds the bonus phase will last

        spawnerBonus.stopSpawning = true; //this will tell the bonus spawner to stop spawning in another script
        spawnerBonus2.stopSpawning = true;
        spawnerBonus3.stopSpawning = true;

        popUpPrefab1.gameObject.SetActive(false);
        popUpPrefab4.gameObject.SetActive(true);

        popUpPrefab6.gameObject.SetActive(false);

        yield return new WaitForSeconds(2f); //for 3 seconds the bonus phase will last 

        Spawner.spawnAgain = true; //this will tell the regular spawner to start spawning again
        Spawner2.spawnAgain = true;
        Spawner3.spawnAgain = true;

        bombSpawner.spawnAgain = true;

        clockSwitch = 0; //switching
        timeClockText.SetActive(false);

        totalTime = 10; //resetting the tick tock clock
    }

    IEnumerator changeToBonusLevel5(float time) //ienumerator to change to bonus phase
    {
        Spawner.stopSpawning = true; //this will tell the main spawner to stop spawning by changing variable in that script
        Spawner2.stopSpawning = true;
        Spawner3.stopSpawning = true;
        bombSpawner.stopSpawning = true;

        yield return new WaitForSeconds(2f); //for 3 seconds the bonus phase will last
        fadeInFunction();

        spawnerBonus.spawnBonusAgain = true; //this will grab from another script and change it to true to start the bonus spawner
        spawnerBonus2.spawnBonusAgain = true;
        spawnerBonus3.spawnBonusAgain = true;

        

        timeClockText.SetActive(true); //updating the tick tock clock
        clockSwitch = 1; //switching

        yield return new WaitForSeconds(10); //for 10 seconds the bonus phase will last

        spawnerBonus.stopSpawning = true; //this will tell the bonus spawner to stop spawning in another script
        spawnerBonus2.stopSpawning = true;
        spawnerBonus3.stopSpawning = true;

        popUpPrefab2.gameObject.SetActive(false);
        popUpPrefab5.gameObject.SetActive(true);

        popUpPrefab4.gameObject.SetActive(false);

        yield return new WaitForSeconds(2f); //for 3 seconds the bonus phase will last 

        Spawner.spawnAgain = true; //this will tell the regular spawner to start spawning again
        Spawner2.spawnAgain = true;
        Spawner3.spawnAgain = true;

        bombSpawner.spawnAgain = true;
        bombSpawner2.spawnAgain = true;

        clockSwitch = 0; //switching
        timeClockText.SetActive(false);

        totalTime = 10; //resetting the tick tock clock
    }

    IEnumerator changeToBonusLevel6(float time) //ienumerator to change to bonus phase
    {
        Spawner.stopSpawning = true; //this will tell the main spawner to stop spawning by changing variable in that script
        Spawner2.stopSpawning = true;
        Spawner3.stopSpawning = true;
        bombSpawner.stopSpawning = true;
        bombSpawner2.stopSpawning = true;

        yield return new WaitForSeconds(2f); //for 3 seconds the bonus phase will last
        fadeInFunction();

        spawnerBonus.spawnBonusAgain = true; //this will grab from another script and change it to true to start the bonus spawner
        spawnerBonus2.spawnBonusAgain = true;
        spawnerBonus3.spawnBonusAgain = true;

        

        timeClockText.SetActive(true); //updating the tick tock clock
        clockSwitch = 1; //switching

        yield return new WaitForSeconds(10); //for 10 seconds the bonus phase will last

        spawnerBonus.stopSpawning = true; //this will tell the bonus spawner to stop spawning in another script
        spawnerBonus2.stopSpawning = true;
        spawnerBonus3.stopSpawning = true;

        popUpPrefab3.gameObject.SetActive(false);
        popUpPrefab6.gameObject.SetActive(true);

        popUpPrefab5.gameObject.SetActive(false);

        yield return new WaitForSeconds(2f); //for 3 seconds the bonus phase will last 

        Spawner.spawnAgain = true; //this will tell the regular spawner to start spawning again
        Spawner2.spawnAgain = true;
        Spawner3.spawnAgain = true;

        bombSpawner.spawnAgain = true;
        bombSpawner2.spawnAgain = true;
        bombSpawner3.spawnAgain = true;

        clockSwitch = 0; //switching
        timeClockText.SetActive(false);

        totalTime = 10; //resetting the tick tock clock
    }

    IEnumerator changeToBonusLevel7(float time) //ienumerator to change to bonus phase
    {
        Spawner.stopSpawning = true; //this will tell the main spawner to stop spawning by changing variable in that script
        Spawner2.stopSpawning = true;
        Spawner3.stopSpawning = true;
        bombSpawner.stopSpawning = true;
        bombSpawner2.stopSpawning = true;
        bombSpawner3.stopSpawning = true;

        yield return new WaitForSeconds(2f); //for 3 seconds the bonus phase will last
        fadeInFunction();

        spawnerBonus.spawnBonusAgain = true; //this will grab from another script and change it to true to start the bonus spawner
        spawnerBonus2.spawnBonusAgain = true;
        spawnerBonus3.spawnBonusAgain = true;

        

        timeClockText.SetActive(true); //updating the tick tock clock
        clockSwitch = 1; //switching

        yield return new WaitForSeconds(10); //for 10 seconds the bonus phase will last

        spawnerBonus.stopSpawning = true; //this will tell the bonus spawner to stop spawning in another script
        spawnerBonus2.stopSpawning = true;
        spawnerBonus3.stopSpawning = true;

        popUpPrefab1.gameObject.SetActive(false);
        popUpPrefab4.gameObject.SetActive(true);

        popUpPrefab6.gameObject.SetActive(false);

        yield return new WaitForSeconds(2f); //for 3 seconds the bonus phase will last 

        Spawner.spawnAgain = true; //this will tell the regular spawner to start spawning again
        Spawner2.spawnAgain = true;
        Spawner3.spawnAgain = true;
        Spawner4.spawnAgain = true;

        bombSpawner.spawnAgain = true;
        bombSpawner2.spawnAgain = true;
        bombSpawner3.spawnAgain = true;

        clockSwitch = 0; //switching
        timeClockText.SetActive(false);

        totalTime = 10; //resetting the tick tock clock
    }

    IEnumerator changeToBonusLevel8(float time) //ienumerator to change to bonus phase
    {
        Spawner.stopSpawning = true; //this will tell the main spawner to stop spawning by changing variable in that script
        Spawner2.stopSpawning = true;
        Spawner3.stopSpawning = true;
        Spawner4.stopSpawning = true;
        bombSpawner.stopSpawning = true;
        bombSpawner2.stopSpawning = true;
        bombSpawner3.stopSpawning = true;

        yield return new WaitForSeconds(2f); //for 3 seconds the bonus phase will last
        fadeInFunction();

        spawnerBonus.spawnBonusAgain = true; //this will grab from another script and change it to true to start the bonus spawner
        spawnerBonus2.spawnBonusAgain = true;
        spawnerBonus3.spawnBonusAgain = true;
        spawnerBonus4.spawnBonusAgain = true;

        

        timeClockText.SetActive(true); //updating the tick tock clock
        clockSwitch = 1; //switching

        yield return new WaitForSeconds(10); //for 10 seconds the bonus phase will last

        spawnerBonus.stopSpawning = true; //this will tell the bonus spawner to stop spawning in another script
        spawnerBonus2.stopSpawning = true;
        spawnerBonus3.stopSpawning = true;
        spawnerBonus4.stopSpawning = true;

        popUpPrefab2.gameObject.SetActive(false);
        popUpPrefab5.gameObject.SetActive(true);

        popUpPrefab4.gameObject.SetActive(false);

        yield return new WaitForSeconds(2f); //for 3 seconds the bonus phase will last 

        Spawner.spawnAgain = true; //this will tell the regular spawner to start spawning again
        Spawner2.spawnAgain = true;
        Spawner3.spawnAgain = true;
        Spawner4.spawnAgain = true;

        bombSpawner.spawnAgain = true;
        bombSpawner2.spawnAgain = true;
        bombSpawner3.spawnAgain = true;

        clockSwitch = 0; //switching
        timeClockText.SetActive(false);

        totalTime = 10; //resetting the tick tock clock
    }

    IEnumerator changeToBonusLevel9(float time) //ienumerator to change to bonus phase
    {
        Spawner.stopSpawning = true; //this will tell the main spawner to stop spawning by changing variable in that script
        Spawner2.stopSpawning = true;
        Spawner3.stopSpawning = true;
        Spawner4.stopSpawning = true;
        bombSpawner.stopSpawning = true;
        bombSpawner2.stopSpawning = true;
        bombSpawner3.stopSpawning = true;

        yield return new WaitForSeconds(2f); //for 3 seconds the bonus phase will last
        fadeInFunction();

        spawnerBonus.spawnBonusAgain = true; //this will grab from another script and change it to true to start the bonus spawner
        spawnerBonus2.spawnBonusAgain = true;
        spawnerBonus3.spawnBonusAgain = true;
        spawnerBonus4.spawnBonusAgain = true;

        

        timeClockText.SetActive(true); //updating the tick tock clock
        clockSwitch = 1; //switching

        yield return new WaitForSeconds(10); //for 10 seconds the bonus phase will last

        spawnerBonus.stopSpawning = true; //this will tell the bonus spawner to stop spawning in another script
        spawnerBonus2.stopSpawning = true;
        spawnerBonus3.stopSpawning = true;
        spawnerBonus3.stopSpawning = true;

        popUpPrefab3.gameObject.SetActive(false);
        popUpPrefab6.gameObject.SetActive(true);

        popUpPrefab5.gameObject.SetActive(false);

        yield return new WaitForSeconds(2f); //for 3 seconds the bonus phase will last 

        Spawner.spawnAgain = true; //this will tell the regular spawner to start spawning again
        Spawner2.spawnAgain = true;
        Spawner3.spawnAgain = true;
        Spawner4.spawnAgain = true;

        bombSpawner.spawnAgain = true;
        bombSpawner2.spawnAgain = true;
        bombSpawner3.spawnAgain = true;

        clockSwitch = 0; //switching
        timeClockText.SetActive(false);

        totalTime = 10; //resetting the tick tock clock
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (paused == false)
            {
                paused = true;
                pauseText.gameObject.SetActive(true);
                Time.timeScale = 0;
            }

            else if (paused == true)
            {
                paused = false;
                pauseText.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
        }

        else if (clockSwitch == 1)
        {
            totalTime -= Time.deltaTime;

            minutes = (int)(totalTime / 60);
            seconds = (int)(totalTime % 60);

            text.text = "0" + minutes.ToString() + ":0" + seconds.ToString();
        }

        
    }
}
