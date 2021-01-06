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

    private float mouseXTotal;
    private float playerX;


    public float speed;
    public bool isFacingRight = true;

    public Animator animator;

    void Start()
    {
        transform.localEulerAngles = new Vector3(0, 180, 0); //getting the facing right position
    }

    void Update() //updating all the time
    {
        
        playerX = transform.position.x; //setting the x position all the time

        Vector3 mouse = cam.ScreenToWorldPoint(Input.mousePosition);
        mouseX = mouse.x; //getting the cursor x position at all time


        if (mouseX > transform.position.x) //checking if mouse x is higher than player position, that means the cursor is at the right of the player else on the left
        {
            isFacingRight = true;
            transform.localEulerAngles = new Vector3(0, 0, 0);
            mouseXTotal = mouseX - 0.1f;

        }
        else
        {
            isFacingRight = false;
            transform.localEulerAngles = new Vector3(0, 180, 0);
            mouseXTotal = mouseX + 0.1f;

        }

        if (mouseX < -7.3f) //If reaches far left, keep the player stuck there unless moving other direction
        {
            mouseX = -7.3f;
        }
        if (mouseX > 7.3f) //If reaches far right, keep the player stuck there unless moving other direction
        {
            mouseX = 7.3f;
        }

        if(isFacingRight == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(mouseX - .1f, transform.position.y, transform.position.z), speed * Time.deltaTime); //move towards mouse position with the use of time and speed
        }

        else if(isFacingRight == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(mouseX + .1f, transform.position.y, transform.position.z), speed * Time.deltaTime); //move towards mouse position with the use of time and speed
        }


        







    }
}