using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] fruits; //setting arrays for the needs and wants (sprites)
    private GameObject[] wants;

    private BoxCollider2D col; //collider object

    float x1, x2; //setting the far left and far right boundaries

    public static bool stopSpawning; //stop spawning variable just in case we need to stop the loop

    public static bool spawnAgain = true; //a global variable to determine if the spawner needs to work again or not
    void Awake()
    {
        col = GetComponent<BoxCollider2D>(); //getting collision

        x1 = transform.position.x - col.bounds.size.x / 2f; //getting the boundaries from left and right
        x2 = transform.position.x + col.bounds.size.x / 2f;
        
    }

    // Update is called once per frame
    void Start()
    {
        //InvokeRepeating("spawnNeeds", 1f, 2f); //this will call the spawner function and stays on loop until disabled by (isActive) or the variable

    }

    public void spawnNeeds()
    {
        Vector3 temp = transform.position; //getting the boundaries set
        temp.x = Random.Range(x1, x2);

        Instantiate(fruits[Random.Range(0, fruits.Length)], temp, Quaternion.identity); //spawning the fruits imported by a random range depends on how many sprites are imported, setting the boundaries where to spawn

        
        if (stopSpawning)
        {
            //CancelInvoke("spawnNeeds"); //if the variable is true then the loop ends
            //stopSpawning = false;
        }

    }

    private void Update()
    {
        if (stopSpawning == true)
        {
            CancelInvoke("spawnNeeds"); //if the variable is true then the loop ends
            stopSpawning = false;
        }

        if (spawnAgain == true) //this update is constantly running to check if the spawnAgain is true which is turned on from the bonus Spawner script, then turned off again here
        {
            InvokeRepeating("spawnNeeds", 1f, 2f); //re runs the function
            spawnAgain = false; //set back to false so the function doesnt run more than once
        }
    }
}