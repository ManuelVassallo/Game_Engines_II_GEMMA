﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        musicSceneChange.Instance.gameObject.GetComponent<AudioSource>().Stop();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
