using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class Movement : MonoBehaviour
{
    private Vector2 screenBounds;



    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update() //updating all the time
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //getting the cursor position from the input
        transform.position = new Vector2(cursorPos.x, -4); //changing the position of the game object to the new set cursor position but deducting the y value
    }
}
*/

public class Movement : MonoBehaviour
{
    public Camera cam;
    private float mouseX;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update() //updating all the time
    {
        Vector3 mouse = cam.ScreenToWorldPoint(Input.mousePosition);
        mouseX = mouse.x;
        if (mouseX < -10.48f) //If reaches far left, keep the player stuck there unless moving other direction
        {
            mouseX = -10.48f;
        }
        if (mouseX > 10.46f) //If reaches far right, keep the player stuck there unless moving other direction
        {
            mouseX = 10.46f;
        }
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(mouseX, transform.position.y, transform.position.z), speed * Time.deltaTime); //move towards mouse position with the use of time and speed
    }
}