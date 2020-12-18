using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class playerScore : MonoBehaviour
{
    private Text scoreText;
    private Text chancesText;

    private int score = 0;
    private int chances = 3;

    public GameObject bonusLevelSpawner;
    public GameObject regularSpawner;
    public GameObject clockScripterObject;

    private bool spawningCount;
    private bool spawnAgain;
    private bool spawnBonusAgain;


    public GameObject timeClockText;

    public float totalTime;

    public int clockSwitch = 0;

    public GameObject clockCountdownObject;

    public Text text;

    private float minutes;
    private float seconds;


    // Start is called before the first frame update


    void Awake()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        scoreText.text = "0";

        chancesText = GameObject.Find("chancesText").GetComponent<Text>();
        chancesText.text = chances.ToString();
    }

    private void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Bomb")
        {
            transform.position = new Vector2(0, 100);
            Destroy(target.gameObject);
            loseChance();

        }

        if(target.tag == "Fruit")
        {
            Destroy(target.gameObject);
            score++;
            checkBonusLevel();
            scoreText.text = score.ToString();
            
        }

        if (target.tag == "Want")
        {
            Destroy(target.gameObject);
            score = score + 2;
            checkBonusLevel();
            scoreText.text = score.ToString();
            
        }

    }

    void RestartGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void checkBonusLevel()
    {
        if (score == 5)
        {
            StartCoroutine(changeToBonusLevel(5f));      
        }
    }


    void loseChance()
    {
        chances = chances - 1;
        chancesText.text = chances.ToString();

        if (chances == 0)
        {
            RestartGame();
        }       
    }

    IEnumerator changeToBonusLevel(float time)
    {
        //bonusLevelSpawner.SetActive(true);
        //regularSpawner.SetActive(false);
        spawnBonusAgain = spawnerBonus.spawnBonusAgain = true;
        Spawner.stopSpawning = true;

        timeClockText.SetActive(true);
        clockSwitch = 1;


        yield return new WaitForSeconds(10);

        //bonusLevelSpawner.SetActive(false);
        //regularSpawner.SetActive(true);
        spawnAgain = Spawner.spawnAgain = true;
        spawnerBonus.stopSpawning = true;

        clockSwitch = 0;
        timeClockText.SetActive(false);
        totalTime = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (clockSwitch == 0)
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
