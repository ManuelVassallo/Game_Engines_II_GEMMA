using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onSpawn : MonoBehaviour
{
    Rigidbody2D rb;

    public float startForce = 15f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse );

        rb.AddTorque(10, ForceMode2D.Impulse);


    }

    // Update is called once per frame
}
