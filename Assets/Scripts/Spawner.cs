using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] fruits;
    private GameObject[] wants;

    private BoxCollider2D col;

    float x1, x2;


    // Start is called before the first frame update
    void Awake()
    {
        col = GetComponent<BoxCollider2D>();

        x1 = transform.position.x - col.bounds.size.x / 2f;
        x2 = transform.position.x + col.bounds.size.x / 2f;

        StartCoroutine(spawnFruit(1f));

    }

    // Update is called once per frame
    void Start()
    {
        
    }

    IEnumerator spawnFruit(float time)
    {
        yield return new WaitForSeconds(time);
        Vector3 temp = transform.position;
        temp.x = Random.Range(x1, x2);

        Instantiate(fruits[Random.Range(0, fruits.Length)], temp, Quaternion.identity);

        StartCoroutine(spawnFruit(Random.Range(1f, 2f)));

    }
}