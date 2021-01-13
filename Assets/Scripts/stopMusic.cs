using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopMusic : MonoBehaviour
{
    public static bool cameFromGame = false;
    private void Awake()
    {
        //Debug.Log(musicSceneChange.mainMenuStartedPlaying);
        //Debug.Log(musicSceneChange2.scoreScreenStartedPlaying);

        if (musicSceneChange2.scoreScreenStartedPlaying == true && musicSceneChange.mainMenuStartedPlaying == false) //if player is coming from scorescreen this will stop the scorescreen music 
        {
            //Debug.Log("it got here tho");
            musicSceneChange2.Instance.gameObject.GetComponent<AudioSource>().Stop();
        }

        else if (musicSceneChange.mainMenuStartedPlaying == true) //if player is coming from main menu will stop the main menu music
        {
            //Debug.Log("it got here");
            musicSceneChange.Instance.gameObject.GetComponent<AudioSource>().Stop();
        }

        else
        {

        }
    }
}
