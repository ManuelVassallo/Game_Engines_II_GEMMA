using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class playerScore : MonoBehaviour
{
    private Text scoreText; //declaring score and chances text
    private Text chancesText; //declaring chances text

    public static bool playingAgain = false;

    public Animator hatAnimator;
    public Animator hatAnimator2;

    public Animator foodAnimator;

    public Animator scoreAnimator;

    public Animator bonusMusicAnim;

    private AudioSource hurtNoise;
    private AudioSource itemNoise;
    private AudioSource itemNoise2;
    private AudioSource chanceNoise;
    private AudioSource bonusMusic;
    private AudioSource musicBox;


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

    public GameObject pauseSquare;

    public GameObject normalBackground;
    public GameObject bonusBackground;

    public Image goldBorder;

    private bool spawningCount; //booleans for swapping of phases
    private bool spawnAgain;
    private bool spawnBonusAgain;

    private bool paused = false;

    private bool isImmune = false;


    public GameObject timeClockText; //stopwatch initiated

    public float totalTime;

    public int clockSwitch = 0;

    private int randomNeedNum;

    private bool bonusLevel1 = false;
    private bool bonusLevel2 = false;
    private bool bonusLevel3 = false;
    private bool bonusLevel4 = false;
    private bool bonusLevel5 = false;
    private bool bonusLevel6 = false;
    private bool bonusLevel7 = false;
    private bool bonusLevel8 = false;
    private bool bonusLevel9 = false;

    private bool isBonusActive = false;

    public GameObject clockCountdownObject;

    public GameObject chipHat1;
    public GameObject chipHat2;
    public GameObject chipHat3;

    public GameObject chipTheMonkey;

    public GameObject pauseText;
    public GameObject escText;
    public GameObject startText;

    public Text text;

    private float minutes;
    private float seconds; //floats for minutes and seconds


    void Awake()
    {
        //Debug.Log(musicSceneChange2.scoreScreenStartedPlaying);
        goldBorder.canvasRenderer.SetAlpha(0.0f);

        scoreText = GameObject.Find("ScoreText").GetComponent<Text>(); //get the score and chances objects
        scoreText.text = "0";
        score = 0;

        hurtNoise = GameObject.FindGameObjectWithTag("HurtSound").GetComponent<AudioSource>(); //getting audio sources from game objects
        itemNoise = GameObject.FindGameObjectWithTag("ItemSound").GetComponent<AudioSource>();
        itemNoise2 = GameObject.FindGameObjectWithTag("ItemSound2").GetComponent<AudioSource>();
        chanceNoise = GameObject.FindGameObjectWithTag("ChanceSound").GetComponent<AudioSource>();
        bonusMusic = GameObject.FindGameObjectWithTag("BonusSound").GetComponent<AudioSource>();
        musicBox = GameObject.FindGameObjectWithTag("musicBox").GetComponent<AudioSource>();

        musicBox.Play();
        

    }


    void fadeInFunction()
    {
        StartCoroutine(fadeInFadeOut(1f));   //gold fade fro mbonus phase
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Bomb") //if player collides with bomb, destroy bomb and lose chance
        {
            Destroy(target.gameObject);  
            if (isImmune == false) //if player is not immune then lose a chance
            {
                hurtNoise.Play();
                loseChance();
                StartCoroutine(isNowImmune(1f));
                StartCoroutine(isNowImmuneFlashing(1f));
            }

            else
            {

            }
        }

        if(target.tag == "Need") //if player collides with a need, destroy need and give a point and check if player reached a specific amount of points to enter bonus phase
        {
            itemNoise.Play();
            Destroy(target.gameObject);
            scoreAnimator.Play("Base Layer.scoreText", 0, 0.25f);
            randomNeedNum = UnityEngine.Random.Range(3, 6); //creatign a random number
            score = score + randomNeedNum;
            
            checkBonusLevel();
            scoreText.text = score.ToString();
            //chipTheMonkey.GetComponent<Renderer>().material.color = Color.red;
            StartCoroutine(textFlash(1f));
            


            

        }

        if (target.tag == "Want") //if player collides with a want, more points is awarded
        {
            if (isBonusActive == true)
            {
                itemNoise2.Play();
                StartCoroutine(textFlash(1f));
                Destroy(target.gameObject);
                scoreAnimator.Play("Base Layer.scoreText", 0, 0.25f);
                randomNeedNum = UnityEngine.Random.Range(3, 6); //creatign a random number
                score = score + randomNeedNum;
                scoreText.text = score.ToString();
            }
            else if(isBonusActive == false)
            {
                itemNoise.Play();
                StartCoroutine(textFlashRed(1f));
                Destroy(target.gameObject);
                scoreAnimator.Play("Base Layer.scoreText", 0, 0.25f);
                score = score - 1;
                scoreText.text = score.ToString();
            }
            

            
        }

        if (target.tag == "Chance") //if player collides with a chance, recover a chance
        {
            chanceNoise.Play();
            Destroy(target.gameObject);
            if (chances == 2)
            {
                chances = chances + 1;
                StartCoroutine(getHatAnimation2(1f));
            }

            else if(chances == 1)
            {
                chances = chances + 1;
                StartCoroutine(getHatAnimation1(1f));
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
        if (score >= 15 && bonusLevel1 == false)
        {         
            StartCoroutine(changeToBonusLevel1(1f));  //run coroutine to switch to bonus phase if certain points is reached    
            popUpPrefab1.gameObject.SetActive(true);
            isBonusActive = true;
            bonusLevel1 = true;
            musicSceneChange2.scoreScreenStartedPlaying = false;
            musicSceneChange.mainMenuStartedPlaying = false;
        }

        else if (score >= 75 && bonusLevel2 == false)
        {
            StartCoroutine(changeToBonusLevel2(1f));  //run coroutine to switch to bonus phase if certain points is reached  
            popUpPrefab2.gameObject.SetActive(true);
            bonusLevel2 = true;
            isBonusActive = true;
        }

        else if (score >= 150 && bonusLevel3 == false)
        {
            StartCoroutine(changeToBonusLevel3(1f));  //run coroutine to switch to bonus phase if certain points is reached 
            popUpPrefab3.gameObject.SetActive(true);
            bonusLevel3 = true;
            isBonusActive = true;
        }

        else if (score >= 250 && bonusLevel4 == false)
        {
            StartCoroutine(changeToBonusLevel4(1f));  //run coroutine to switch to bonus phase if certain points is reached 
            popUpPrefab1.gameObject.SetActive(true);
            bonusLevel4 = true;
            isBonusActive = true;
        }

        else if (score >= 400 && bonusLevel5 == false)
        {
            StartCoroutine(changeToBonusLevel5(1f));  //run coroutine to switch to bonus phase if certain points is reached  
            popUpPrefab2.gameObject.SetActive(true);
            bonusLevel5 = true;
            isBonusActive = true;
        }

        else if (score >= 550 && bonusLevel6 == false)
        {
            StartCoroutine(changeToBonusLevel6(1f));  //run coroutine to switch to bonus phase if certain points is reached 
            popUpPrefab3.gameObject.SetActive(true);
            bonusLevel6 = true;
            isBonusActive = true;
        }

        else if (score >= 700 && bonusLevel7 == false)
        {
            StartCoroutine(changeToBonusLevel7(1f));  //run coroutine to switch to bonus phase if certain points is reached  
            popUpPrefab1.gameObject.SetActive(true);
            bonusLevel7 = true;
            isBonusActive = true;
        }

        else if (score >= 900 && bonusLevel8 == false)
        {
            StartCoroutine(changeToBonusLevel8(1f));  //run coroutine to switch to bonus phase if certain points is reached  
            popUpPrefab2.gameObject.SetActive(true);
            bonusLevel8 = true;
            isBonusActive = true;
        }

        else if (score >= 1100 && bonusLevel9 == false)
        {
            StartCoroutine(changeToBonusLevel9(1f));  //run coroutine to switch to bonus phase if certain points is reached  
            popUpPrefab3.gameObject.SetActive(true);
            bonusLevel9 = true;
            isBonusActive = true;
        }
    }

    IEnumerator shrinkFoodAnimation(float time) //animation for the food
    {
        foodAnimator.SetBool("isTriggered", true);
        yield return new WaitForSeconds(0.75f);
    }

    IEnumerator lostHatAnimation(float time) //animation

    {
        hatAnimator.SetBool("lostLifeAnim", true);
        yield return new WaitForSeconds(0.75f);
    }

    IEnumerator getHatAnimation2(float time) //animation
    {
        
        hatAnimator.SetBool("getLifeAnim", true);
        yield return new WaitForSeconds(0.75f);
        hatAnimator.SetBool("getLifeAnim", false);
        hatAnimator.SetBool("lostLifeAnim", false);
    }

    IEnumerator getHatAnimation1(float time) //get animation
    {
        hatAnimator2.SetBool("getLifeAnim", true);
        yield return new WaitForSeconds(0.75f);
        hatAnimator2.SetBool("getLifeAnim", false);
        hatAnimator2.SetBool("lostLifeAnim", false);
    }

    IEnumerator lostHatAnimation2(float time) //ienumerator to change to bonus phase
    {
        hatAnimator2.SetBool("lostLifeAnim", true);
        yield return new WaitForSeconds(0.75f);
    }


    void loseChance() //lose a chance variable and update the text
    {
        
        chances = chances - 1;
        if (chances == 2)
        {
            StartCoroutine(lostHatAnimation(1f));        
        }

        else if (chances == 1)
        {
            StartCoroutine(lostHatAnimation2(1f));
            
        }

        else if (chances == 0)
        {
            endGame(); //end the game if 0
        }         
    }

    IEnumerator isNowImmuneFlashing(float time) //flashing color
    {
        chipTheMonkey.GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(.25f);
        chipTheMonkey.GetComponent<Renderer>().material.color = Color.white;
        yield return new WaitForSeconds(.25f);
        chipTheMonkey.GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(.25f);
        chipTheMonkey.GetComponent<Renderer>().material.color = Color.white;
        yield return new WaitForSeconds(.25f);
        chipTheMonkey.GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(.25f);
        chipTheMonkey.GetComponent<Renderer>().material.color = Color.white;
        yield return new WaitForSeconds(.25f);
        chipTheMonkey.GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(.25f);
        chipTheMonkey.GetComponent<Renderer>().material.color = Color.white;
        yield return new WaitForSeconds(.25f);
        chipTheMonkey.GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(.15f);
        chipTheMonkey.GetComponent<Renderer>().material.color = Color.white;
        yield return new WaitForSeconds(.15f);
        chipTheMonkey.GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(.15f);
        chipTheMonkey.GetComponent<Renderer>().material.color = Color.white;
        yield return new WaitForSeconds(.15f);
        chipTheMonkey.GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(.15f);
        chipTheMonkey.GetComponent<Renderer>().material.color = Color.white;
        yield return new WaitForSeconds(.15f);
        chipTheMonkey.GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(.15f);
        chipTheMonkey.GetComponent<Renderer>().material.color = Color.white;

    }

    IEnumerator textFlash(float time) //flashing color
    {
        scoreText.GetComponent<Text>().color = Color.green;
        yield return new WaitForSeconds(.5f);
        scoreText.GetComponent<Text>().color = new Color32(60, 17, 19, 255);
    }

    IEnumerator textFlashRed(float time) //flashing color
    {
        scoreText.GetComponent<Text>().color = Color.red;
        yield return new WaitForSeconds(.5f);
        scoreText.GetComponent<Text>().color = new Color32(60, 17, 19, 255);
    }




    IEnumerator isNowImmune(float time) //changing to immune
    {     
        isImmune = true;
        yield return new WaitForSeconds(3);
        isImmune = false;
    }

    IEnumerator fadeInFadeOut(float time) //fade animation
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

        //bonusMusicAnim.Play("Base Layer.audioFadeIn3", 0, 2f);
        normalBackground.SetActive(false);
        bonusBackground.SetActive(true);

        bonusMusic.Play();
        musicBox.Pause();
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

        bonusMusic.Pause();
        musicBox.Play();

        Spawner.spawnAgain = true; //this will tell the regular spawner to start spawning again
        Spawner2.spawnAgain= true;
        isBonusActive = false;

        clockSwitch = 0; //switching
        timeClockText.SetActive(false);


        totalTime = 10; //resetting the tick tock clock

        normalBackground.SetActive(true);
        bonusBackground.SetActive(false);


    }

    IEnumerator changeToBonusLevel2(float time) //ienumerator to change to bonus phase
    {
        bonusMusic.Play();
        musicBox.Pause();
        normalBackground.SetActive(false);
        bonusBackground.SetActive(true);

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

        bonusMusic.Pause();
        musicBox.Play();

        Spawner.spawnAgain = true; //this will tell the regular spawner to start spawning again
        Spawner2.spawnAgain = true; 
        
        bombSpawner.spawnAgain = true;
        isBonusActive = false;

        clockSwitch = 0; //switching
        timeClockText.SetActive(false);

        normalBackground.SetActive(true);
        bonusBackground.SetActive(false);

        totalTime = 10; //resetting the tick tock clock

        yield return new WaitForSeconds(2f); //for 3 seconds the bonus phase will last 
    }

    IEnumerator changeToBonusLevel3(float time) //ienumerator to change to bonus phase
    {
        bonusMusic.Play();
        musicBox.Pause();
        normalBackground.SetActive(false);
        bonusBackground.SetActive(true);

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

        bonusMusic.Pause();
        musicBox.Play();

        Spawner.spawnAgain = true; //this will tell the regular spawner to start spawning again
        Spawner2.spawnAgain = true;
        Spawner3.spawnAgain = true; 

        bombSpawner.spawnAgain = true;
        isBonusActive = false;

        clockSwitch = 0; //switching
        timeClockText.SetActive(false);

        normalBackground.SetActive(true);
        bonusBackground.SetActive(false);


        totalTime = 10; //resetting the tick tock clock
    }

    IEnumerator changeToBonusLevel4(float time) //ienumerator to change to bonus phase
    {
        bonusMusic.Play();
        musicBox.Pause();
        normalBackground.SetActive(false);
        bonusBackground.SetActive(true);

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

        bonusMusic.Pause();
        musicBox.Play();

        Spawner.spawnAgain = true; //this will tell the regular spawner to start spawning again
        Spawner2.spawnAgain = true;
        Spawner3.spawnAgain = true;

        bombSpawner.spawnAgain = true;
        isBonusActive = false;

        clockSwitch = 0; //switching
        timeClockText.SetActive(false);

        normalBackground.SetActive(true);
        bonusBackground.SetActive(false);

        totalTime = 10; //resetting the tick tock clock
    }

    IEnumerator changeToBonusLevel5(float time) //ienumerator to change to bonus phase
    {
        bonusMusic.Play();
        musicBox.Pause();
        normalBackground.SetActive(false);
        bonusBackground.SetActive(true);

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

        bonusMusic.Pause();
        musicBox.Play();

        Spawner.spawnAgain = true; //this will tell the regular spawner to start spawning again
        Spawner2.spawnAgain = true;
        Spawner3.spawnAgain = true;

        bombSpawner.spawnAgain = true;
        bombSpawner2.spawnAgain = true;
        isBonusActive = false;

        clockSwitch = 0; //switching
        timeClockText.SetActive(false);

        normalBackground.SetActive(true);
        bonusBackground.SetActive(false);

        totalTime = 10; //resetting the tick tock clock
    }

    IEnumerator changeToBonusLevel6(float time) //ienumerator to change to bonus phase
    {
        bonusMusic.Play();
        musicBox.Pause();
        normalBackground.SetActive(false);
        bonusBackground.SetActive(true);

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

        bonusMusic.Pause();
        musicBox.Play();

        Spawner.spawnAgain = true; //this will tell the regular spawner to start spawning again
        Spawner2.spawnAgain = true;
        Spawner3.spawnAgain = true;

        bombSpawner.spawnAgain = true;
        bombSpawner2.spawnAgain = true;
        bombSpawner3.spawnAgain = true;
        isBonusActive = false;

        clockSwitch = 0; //switching
        timeClockText.SetActive(false);

        normalBackground.SetActive(true);
        bonusBackground.SetActive(false);

        totalTime = 10; //resetting the tick tock clock
    }

    IEnumerator changeToBonusLevel7(float time) //ienumerator to change to bonus phase
    {
        bonusMusic.Play();
        musicBox.Pause();
        normalBackground.SetActive(false);
        bonusBackground.SetActive(true);

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

        bonusMusic.Pause();
        musicBox.Play();

        Spawner.spawnAgain = true; //this will tell the regular spawner to start spawning again
        Spawner2.spawnAgain = true;
        Spawner3.spawnAgain = true;
        Spawner4.spawnAgain = true;

        bombSpawner.spawnAgain = true;
        bombSpawner2.spawnAgain = true;
        bombSpawner3.spawnAgain = true;
        isBonusActive = false;

        clockSwitch = 0; //switching
        timeClockText.SetActive(false);

        normalBackground.SetActive(true);
        bonusBackground.SetActive(false);

        totalTime = 10; //resetting the tick tock clock
    }

    IEnumerator changeToBonusLevel8(float time) //ienumerator to change to bonus phase
    {
        bonusMusic.Play();
        musicBox.Pause();
        normalBackground.SetActive(false);
        bonusBackground.SetActive(true);

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

        bonusMusic.Pause();
        musicBox.Play();

        Spawner.spawnAgain = true; //this will tell the regular spawner to start spawning again
        Spawner2.spawnAgain = true;
        Spawner3.spawnAgain = true;
        Spawner4.spawnAgain = true;

        bombSpawner.spawnAgain = true;
        bombSpawner2.spawnAgain = true;
        bombSpawner3.spawnAgain = true;
        isBonusActive = false;

        clockSwitch = 0; //switching
        timeClockText.SetActive(false);

        normalBackground.SetActive(true);
        bonusBackground.SetActive(false);

        totalTime = 10; //resetting the tick tock clock
    }

    IEnumerator changeToBonusLevel9(float time) //ienumerator to change to bonus phase
    {
        bonusMusic.Play();
        musicBox.Pause();
        normalBackground.SetActive(false);
        bonusBackground.SetActive(true);

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

        popUpPrefab3.gameObject.SetActive(false);
        popUpPrefab6.gameObject.SetActive(true);

        popUpPrefab5.gameObject.SetActive(false);

        yield return new WaitForSeconds(2f); //for 3 seconds the bonus phase will last 

        bonusMusic.Pause();
        musicBox.Play();

        Spawner.spawnAgain = true; //this will tell the regular spawner to start spawning again
        Spawner2.spawnAgain = true;
        Spawner3.spawnAgain = true;
        Spawner4.spawnAgain = true;

        bombSpawner.spawnAgain = true;
        bombSpawner2.spawnAgain = true;
        bombSpawner3.spawnAgain = true;
        isBonusActive = false;

        clockSwitch = 0; //switching
        timeClockText.SetActive(false);

        normalBackground.SetActive(true);
        bonusBackground.SetActive(false);

        totalTime = 10; //resetting the tick tock clock
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //if space is pressed the game will pause by turning time scale off
        {
            if (paused == false)
            {
                paused = true;
                pauseSquare.gameObject.SetActive(true);
                pauseText.gameObject.SetActive(true);
                escText.gameObject.SetActive(true);
                Time.timeScale = 0;
            }

            else if (paused == true)
            {
                paused = false;
                pauseSquare.gameObject.SetActive(false);
                pauseText.gameObject.SetActive(false);
                escText.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
        }

        if (Input.GetKey("escape")) //if space is pressed the game will pause by turning time scale off
        {
            if (paused == true)
            {
                Time.timeScale = 1;
                stopMusic.cameFromGame = true;
                SceneManager.LoadScene("MainMenu");

            }
        }

        else if (clockSwitch == 1) //checking the clock to convert to the minutes and seconds and resetting to 0
        {
            totalTime -= Time.deltaTime;

            minutes = (int)(totalTime / 60);
            seconds = (int)(totalTime % 60);

            text.text = "0" + minutes.ToString() + ":0" + seconds.ToString();
        }

        
    }
}
