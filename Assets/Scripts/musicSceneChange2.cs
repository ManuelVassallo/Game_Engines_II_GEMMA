using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicSceneChange2 : MonoBehaviour
{
    private AudioSource playScoreScreenMusic; //get audio source
    public static bool scoreScreenStartedPlaying = false; //setting variable
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private static musicSceneChange2 instance = null;
    public static musicSceneChange2 Instance
    {
        get { return instance; } //this is to get the current instance of the game running
    }

    void Awake()
    {
        
        if (scoreScreenStartedPlaying == false) //checking if score screen is playing
        {
            playScoreScreenMusic = GameObject.FindGameObjectWithTag("scoreMusicBox").GetComponent<AudioSource>(); //get the music box and then play it and switch variable
            playScoreScreenMusic.Play();
            scoreScreenStartedPlaying = true;
        }

        if (instance != null && instance != this) //checking if the instance is playing or not
        {
            Destroy(this.gameObject); //else destroy the instance
            Debug.Log(instance);

            if (scoreScreenStartedPlaying == false) //if the instance is different it will recheck for the music
            {          
                playScoreScreenMusic = GameObject.FindGameObjectWithTag("scoreMusicBox").GetComponent<AudioSource>();
                playScoreScreenMusic.Play();
                scoreScreenStartedPlaying = true;
            }
            
            return;
        }

        else
        {
            instance = this; //if there is no instance then switch to current
        }
        DontDestroyOnLoad(this.gameObject); //dont destroy the instance
        
    }

}
