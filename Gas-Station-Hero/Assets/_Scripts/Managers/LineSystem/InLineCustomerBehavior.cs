using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InlineCustomerBehavior : MonoBehaviour
{
    public Vector2 TargetLoc;
    private Vector2 vector;
    public float speed = 3;
    private float turnSpeed = 100;
    private bool leaving = false;
    private bool moving = false;


    public void leave()
    {
        vector.x = -speed;
        vector.y = 0;
        leaving = true;
        Destroy(gameObject, 5);
    }
    public void init(Vector2 target)
    {
        TargetLoc = target;
        moving = true;
        Debug.Log(TargetLoc);
    }
    public void moveUP()
    {
        moving = true;
    }
    


    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)vector * Time.deltaTime;
        if (leaving)
        {
            if (vector.x < 0)
            {
                vector.x += speed / turnSpeed;
                vector.y -= speed / turnSpeed;
            }
        }
        else if (moving)
        {
            vector = Vector3.MoveTowards(transform.position, TargetLoc, speed) - transform.position;
            if (vector.magnitude < 0.1) 
            {
                moving = false;
                vector = Vector2.zero;
            }
        }
    }
}
