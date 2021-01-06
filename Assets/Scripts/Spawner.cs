using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] needs; //setting arrays for the needs and wants (sprites)

    private BoxCollider2D col; //collider object

    float x1, x2; //setting the far left and far right boundaries

    public static bool stopSpawning; //stop spawning variable just in case we need to stop the loop

    public static bool spawnAgain = true; //a global variable to determine if the spawner needs to work again or not

    public static bool gameStarted = false;

    public static bool playAgain = false;

    private float minSpawnTime = 1;
    private float maxSpawnTime = 2;
    void Awake()
    {
        col = GetComponent<BoxCollider2D>(); //getting collision

        x1 = transform.position.x - col.bounds.size.x / 2f; //getting the boundaries from left and right
        x2 = transform.position.x + col.bounds.size.x / 2f;
        Debug.Log("Game is starting again");
        
        

    }

    private void Start()
    {
        
    }

    IEnumerator gameStartingUp(float time) //ienumerator to change to bonus phase
    {
        yield return new WaitForSeconds(3);
        gameStarted = true;

    }

    public void spawnNeeds()
    {
        Vector3 temp = transform.position; //getting the boundaries set
        temp.x = Random.Range(x1, x2);

        Instantiate(needs[Random.Range(0, needs.Length)], temp, Quaternion.identity); //spawning the fruits imported by a random range depends on how many sprites are imported, setting the boundaries where to spawn

    }

    private void Update()
    {
        Debug.Log("Right now the play again is: " + playAgain);
        if (playAgain == false) //checking if the player is playing again or not
        {
            Debug.Log("I got in");
            StartCoroutine(gameStartingUp(1f));
            playAgain = true;
        }

        if (stopSpawning == true)
        {
            CancelInvoke("spawnNeeds"); //if the variable is true then the loop ends

           minSpawnTime = minSpawnTime - 0.1f;
           maxSpawnTime = maxSpawnTime - .2f;

            stopSpawning = false;
        }

        if (gameStarted == true)
        {
            if (spawnAgain == true) //this update is constantly running to check if the spawnAgain is true which is turned on from the bonus Spawner script, then turned off again here
            {
                InvokeRepeating("spawnNeeds", minSpawnTime, maxSpawnTime); //re runs the function
                spawnAgain = false; //set back to false so the function doesnt run more than once

            }

        }
        
    }
}