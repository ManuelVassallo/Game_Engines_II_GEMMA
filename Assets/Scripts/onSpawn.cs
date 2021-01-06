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
        rb = GetComponent<Rigidbody2D>(); //getting rigid body

        int startForceRandom = Random.Range(5, 10); //creatign a random number
        rb.AddForce(transform.up * startForceRandom, ForceMode2D.Impulse ); //random number to that force

        rb.AddTorque(10, ForceMode2D.Impulse); //adding torque/rotation to the object


    }

    // Update is called once per frame
}
