using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsAnimation : MonoBehaviour
{
    float counter;
    bool endReached;
    public float speed = 1.0f;
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        endReached = false;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (endReached) 
            return;

        Vector3 pos = new Vector3(startPos.x + Mathf.Sin( Mathf.PI * 2 * counter / 360 ), 
            startPos.y + Mathf.Sin( Mathf.PI * 2 * counter / 360 ),
            startPos.z);

        transform.position = Vector3.Slerp( transform.position, pos, 1.0f );

        counter += speed;

        if (counter >= 180)
            endReached = true;
    }
}
