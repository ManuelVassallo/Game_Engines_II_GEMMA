using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clockScript : MonoBehaviour
{
    public float totalTime;

    public int clockSwitch = 0;

    public GameObject clockCountdownObject;

    public Text text;

    private float minutes;
    private float seconds;

    private void Update()
    {
        if (clockSwitch == 0)
        {
            Debug.Log("timer is off");
        }

        else if (clockSwitch == 1)
        {
            totalTime -= Time.deltaTime;

            minutes = (int)(totalTime / 60);
            seconds = (int)(totalTime % 60);

            text.text = minutes.ToString() + " : " + seconds.ToString();
        }
        
        
    }


}
