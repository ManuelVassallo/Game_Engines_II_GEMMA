using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class needSpawner : MonoBehaviour
{
    public GameObject needPrefab;
    public Transform[] spawnPoints;

    public float minDelay = .1f;
    public float maxDelay = 1f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnNeeds());
        
    }

    IEnumerator spawnNeeds()
    {
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            Instantiate(needPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
