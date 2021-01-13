using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timerCredits : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        StartCoroutine(switchToEndScene(1f));
        

    }

    IEnumerator switchToEndScene(float time) //ienumerator to change to bonus phase
    {
        yield return new WaitForSeconds(10f); //for 10 seconds the bonus phase will last
        SceneManager.LoadScene("ExplanationEnd");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
