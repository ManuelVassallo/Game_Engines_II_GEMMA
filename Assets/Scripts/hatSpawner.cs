using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hatSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] hats; //setting arrays for the needs and wants (sprites)

    public Transform[] spawnPoints;

    private BoxCollider2D col; //collider object

    float x1, x2; //setting the far left and far right boundaries

    public static bool stopSpawning = false; //stop spawning variable just in case we need to stop the loop

    public static bool spawnAgain; //a global variable to determine if the spawner needs to work again or not

    private float minSpawnTime = 40;
    private float maxSpawnTime = 45;
    void Awake()
    {
        col = GetComponent<BoxCollider2D>(); //getting collision

        x1 = transform.position.x - col.bounds.size.x / 2f; //getting the boundaries from left and right
        x2 = transform.position.x + col.bounds.size.x / 2f;

    }

    public void spawnHats()
    {
        Vector3 temp = transform.position; //getting the boundaries set
        temp.x = Random.Range(x1, x2);

        int spawnIndex = Random.Range(0, spawnPoints.Length);

        Transform spawnPoint = spawnPoints[spawnIndex];

        Instantiate(hats[Random.Range(0, hats.Length)], spawnPoint.position, spawnPoint.rotation); //spawning the fruits imported by a random range depends on how many sprites are imported, setting the boundaries where to spawn

    }

    private void Update()
    {
        if (stopSpawning == true)
        {
            CancelInvoke("spawnHats"); //if the variable is true then the loop ends

            stopSpawning = false;
        }

        if (spawnAgain == true) //this update is constantly running to check if the spawnAgain is true which is turned on from the bonus Spawner script, then turned off again here
        {
            InvokeRepeating("spawnHats", minSpawnTime, maxSpawnTime); //re runs the function
            spawnAgain = false; //set back to false so the function doesnt run more than once
        }
    }
}
