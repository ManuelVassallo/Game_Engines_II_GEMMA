using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicSceneChange : MonoBehaviour
{

    private AudioSource playMainMenuMusic;
    public static bool mainMenuStartedPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private static musicSceneChange instance = null;
    public static musicSceneChange Instance //this is to get the current instance of the game running
    {
        get { return instance; }
    }

    void Awake()
    {
        if (mainMenuStartedPlaying == false) //checking if score screen is playing
        {
            playMainMenuMusic = GameObject.FindGameObjectWithTag("mainMenuMusicBox").GetComponent<AudioSource>(); //play music if the main menu isnt playing
            playMainMenuMusic.Play();
            mainMenuStartedPlaying = true;
        }

        if (instance != null && instance != this) //checking if the instance is playing or not
        {
            Destroy(this.gameObject);

            if (mainMenuStartedPlaying == false)
            {
                playMainMenuMusic = GameObject.FindGameObjectWithTag("scoreMusicBox").GetComponent<AudioSource>();
                playMainMenuMusic.Play(); //play music
                mainMenuStartedPlaying = true;
            }
            return;
        }



        else
        {
            instance = this; //change the instance to this
            

        }

        DontDestroyOnLoad(this.gameObject);
        Debug.Log(instance);
    }

}
