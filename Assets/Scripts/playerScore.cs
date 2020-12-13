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

    public GameObject timeClockText;


    // Start is called before the first frame update
    void Awake()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        scoreText.text = "0";

        chancesText = GameObject.Find("chancesText").GetComponent<Text>();
        chancesText.text = chances.ToString();

    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Bomb")
        {
            transform.position = new Vector2(0, 100);
            target.gameObject.SetActive(false);
            loseChance();

        }

        if(target.tag == "Fruit")
        {
            target.gameObject.SetActive(false);
            score++;
            checkBonusLevel();
            scoreText.text = score.ToString();
            
        }

        if (target.tag == "Want")
        {
            target.gameObject.SetActive(false);
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
        bonusLevelSpawner.SetActive(true);
        regularSpawner.SetActive(false);
        timeClockText.SetActive(true);


        yield return new WaitForSeconds(10);

        timeClockText.SetActive(false);
        bonusLevelSpawner.SetActive(false);
        regularSpawner.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
