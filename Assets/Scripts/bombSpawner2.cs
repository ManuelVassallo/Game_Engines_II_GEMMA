using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombSpawner2 : MonoBehaviour
{
    [SerializeField]
    private GameObject[] bombs; //setting arrays for the needs and wants (sprites)

    public Transform[] spawnPoints;

    private BoxCollider2D col; //collider object

    float x1, x2; //setting the far left and far right boundaries

    public static bool stopSpawning = false; //stop spawning variable just in case we need to stop the loop

    public static bool spawnAgain; //a global variable to determine if the spawner needs to work again or not

    private float minSpawnTime = 4;
    private float maxSpawnTime = 5;
    void Awake()
    {
        col = GetComponent<BoxCollider2D>(); //getting collision

        x1 = transform.position.x - col.bounds.size.x / 2f; //getting the boundaries from left and right
        x2 = transform.position.x + col.bounds.size.x / 2f;

    }

    public void spawnBombs()
    {
        Vector3 temp = transform.position; //getting the boundaries set
        temp.x = Random.Range(x1, x2);

        int spawnIndex = Random.Range(0, spawnPoints.Length);

        Transform spawnPoint = spawnPoints[spawnIndex];

        Instantiate(bombs[Random.Range(0, bombs.Length)], spawnPoint.position, spawnPoint.rotation); //spawning the fruits imported by a random range depends on how many sprites are imported, setting the boundaries where to spawn

    }

    private void Update()
    {
        if (stopSpawning == true)
        {
            CancelInvoke("spawnBombs"); //if the variable is true then the loop ends

            minSpawnTime = minSpawnTime - 0.5f;
            maxSpawnTime = maxSpawnTime - 0.5f;

            stopSpawning = false;
        }

        if (spawnAgain == true) //this update is constantly running to check if the spawnAgain is true which is turned on from the bonus Spawner script, then turned off again here
        {
            InvokeRepeating("spawnBombs", minSpawnTime, maxSpawnTime); //re runs the function
            spawnAgain = false; //set back to false so the function doesnt run more than once
        }
    }
}
