using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D target) //this code basically destroys objects that are falling off the map to keep the timeline tidy
    { 
        if (target.tag == "Bomb") //if bomb, destroy
        {
            Destroy(target.gameObject);

        }

        if (target.tag == "Need") //if a need, destroy
        {
            Destroy(target.gameObject);

        }

        if (target.tag == "Want") //if a want, destroy
        {
            Destroy(target.gameObject);

        }

    }
}
