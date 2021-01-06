using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopMusic2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        

    }

    private void Awake()
    {
        musicSceneChange2.Instance.gameObject.GetComponent<AudioSource>().Stop(); //stops the music from the other script
    }

    // Update is called once per frame
    void Update()
    {

    }
}
