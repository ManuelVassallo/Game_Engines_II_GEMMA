using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scoreController : MonoBehaviour
{
    private int playerFinalScore;
    private Text scoreText; //declaring score and chances text
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("finalScore").GetComponent<Text>(); //get the score and chances objects

        playerFinalScore = playerScore.score;
        scoreText.text = playerFinalScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
