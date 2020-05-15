using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InLineCustomerBehavior : MonoBehaviour
{
    public Vector2 TargetLoc;
    private Vector2 vector;
    public float speed = 3;
    private float turnSpeed = 100;
    private bool leaving = false;
    public bool moving = false;
	public bool ordering = false;

    /*=================================
    fucntion to have the customer leave the line and self destroy after 5 secs,
    which should be adjusted depending on the speed of the customer and the size of the screen
    ==================================*/
    public void leave()
    {
        vector.x = -speed;
        vector.y = 0;
        leaving = true;
		ordering = false;
        Destroy(gameObject, 5);
    }

    /*=================================
     * sets the target location to the parameter, and enables movement.
    ==================================*/
    public void moveUp(Vector2 target)
    {
        TargetLoc = target;
        moving = true;
    }
    
	

    /*=================================
     Update is called once per frame
    ==================================*/
    void Update()
    {
        
        transform.position += (Vector3)vector * Time.deltaTime;



        if (leaving)        //if the customer is leaving, it will gradually turn depending on the turn speed, 
        {                   //until x component of the vector becomes 0, leave head straight down.
            if (vector.x < 0)
            {
                vector.x += speed / turnSpeed;
                vector.y += speed / turnSpeed;
            }
        }
        else if (moving)    //if the customer is not leaving, but moving is enabled, customer will move toward the targetLocation
        {
            vector = Vector3.MoveTowards(transform.position, TargetLoc, speed) - transform.position;//part to stop moving the customer once it reaches the proximity of the target location.
            if (vector.magnitude < 0.1) 
            {
                moving = false;
                vector = Vector2.zero;
            }
        }
    }
}
