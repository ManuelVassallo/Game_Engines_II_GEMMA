using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerBonus : MonoBehaviour
{
    [SerializeField]
    private GameObject[] wants; //array of wants

    private BoxCollider2D col; //collider initiated

    float x1, x2; //boundaries

    public static bool stopSpawning = false;

    public static bool spawnBonusAgain; //a global variable to determine if the spawner needs to work again or not

    private float minSpawnTime = 1;
    private float maxSpawnTime = 2;



    void Awake()
    {
        
        col = GetComponent<BoxCollider2D>();

        x1 = transform.position.x - col.bounds.size.x / 2f; //get the boundaries for the spawners
        x2 = transform.position.x + col.bounds.size.x / 2f; 

    }


    public void spawnWants()
    {
        Vector3 temp = transform.position; //get the boundaries
        temp.x = Random.Range(x1, x2);

        Instantiate(wants[Random.Range(0, wants.Length)], temp, Quaternion.identity); //spawning the wants at a random range and at restricted boundaries

    }

    private void Update()
    {
        if (stopSpawning == true)
        {
            CancelInvoke("spawnWants"); //if the variable is true then the loop ends

           // minSpawnTime = minSpawnTime - 0.15f;
            //maxSpawnTime = maxSpawnTime - .3f;

            stopSpawning = false;


        }

        if (spawnBonusAgain == true) //this update is constantly running to check if the spawnAgain is true which is turned on from the bonus Spawner script, then turned off again here
        {
            InvokeRepeating("spawnWants", minSpawnTime, maxSpawnTime); //re runs the function
            spawnBonusAgain = false; //set back to false so the function doesnt run more than once
        }
    }
}
