using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerBonus : MonoBehaviour
{
    [SerializeField]
    private GameObject[] wants;

    private BoxCollider2D col;

    float x1, x2;

    public static bool stopSpawning = false;

    public static bool spawnBonusAgain; //a global variable to determine if the spawner needs to work again or not



    void Awake()
    {
        
        col = GetComponent<BoxCollider2D>();

        x1 = transform.position.x - col.bounds.size.x / 2f;
        x2 = transform.position.x + col.bounds.size.x / 2f; 

    }

    // Update is called once per frame
    void Start()
    {
        //InvokeRepeating("spawnWants", 1f, 2f);

    }

    public void spawnWants()
    {
        Vector3 temp = transform.position;
        temp.x = Random.Range(x1, x2);

        Instantiate(wants[Random.Range(0, wants.Length)], temp, Quaternion.identity);


        if (stopSpawning)
        {
            //CancelInvoke("spawnWants");
            //stopSpawning = false;
        }

    }

    private void Update()
    {
        if (stopSpawning == true)
        {
            Debug.Log("checking for memes");
            CancelInvoke("spawnWants"); //if the variable is true then the loop ends
            stopSpawning = false;
        }

        if (spawnBonusAgain == true) //this update is constantly running to check if the spawnAgain is true which is turned on from the bonus Spawner script, then turned off again here
        {
            InvokeRepeating("spawnWants", 1f, 2f); //re runs the function
            spawnBonusAgain = false; //set back to false so the function doesnt run more than once
        }
    }
}
