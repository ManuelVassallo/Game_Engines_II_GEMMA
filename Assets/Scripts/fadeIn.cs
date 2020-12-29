using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeIn : MonoBehaviour
{
    public Image goldBorder;
    // Start is called before the first frame update
    void Start()
    {
        goldBorder.canvasRenderer.SetAlpha(0.0f);

        fadeInFunction();
       
        
    }

    void fadeInFunction()
    {
        goldBorder.CrossFadeAlpha(1, 2, false);
    }

}
