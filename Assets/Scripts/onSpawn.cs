using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onSpawn : MonoBehaviour
{
    Rigidbody2D rb;

    private float startForce;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        int startForceRandom = Random.Range(5, 11);
        rb.AddForce(transform.up * startForceRandom, ForceMode2D.Impulse );

        rb.AddTorque(10, ForceMode2D.Impulse);


    }

    // Update is called once per frame
}
