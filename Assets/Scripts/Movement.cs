using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() //updating all the time
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //getting the cursor position from the input
        transform.position = new Vector2(cursorPos.x, -4); //changing the position of the game object to the new set cursor position but deducting the y value
    }
}
